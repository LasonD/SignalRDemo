using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SignalRDemo.Server.Application.Dto;
using SignalRDemo.Server.Application.Exceptions;
using SignalRDemo.Server.Application.Models;
using SignalRDemo.Server.Application.Services;
using SignalRDemo.Server.Infrastructure.Data;

namespace SignalRDemo.Server.Application.UseCases.Queries;

public static class GetDeclarations
{
    public class Query : IRequest<IEnumerable<DeclarationDto>>
    {
        public string UserId { get; set; } = null!;
    }

    public class Handler : IRequestHandler<Query, IEnumerable<DeclarationDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDeclarationsLockManager _declarationsLockManager;
        private readonly DeclarationsDbContext _dbContext;

        public Handler(IMapper mapper, DeclarationsDbContext dbContext, IDeclarationsLockManager declarationsDeclarationsLockManager)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _declarationsLockManager = declarationsDeclarationsLockManager;
        }

        public async Task<IEnumerable<DeclarationDto>> Handle(Query query, CancellationToken cancellationToken)
        {
            var user = _dbContext.Users
                    .Include(u => u.Jurisdictions)
                    .FirstOrDefault(u => u.Id == query.UserId);

            if (user == null)
            {
                throw new NotFoundException(query.UserId, nameof(User));
            }

            var jurisdictionCodes = user.Jurisdictions.Select(j => j.Code).ToList();

            var declarations = await _dbContext.Declarations
                .Include(d => d.Declarant)
                .Where(d => jurisdictionCodes.Contains(d.JurisdictionCode))
                .OrderByDescending(d => d.CreationDate)
                .ToListAsync(cancellationToken);

            var result = _mapper.Map<List<DeclarationDto>>(declarations);

            foreach (var dto in result)
            {
                dto.IsLocked = _declarationsLockManager.IsLocked(dto.Id);
            }

            return result;
        }
    }
}