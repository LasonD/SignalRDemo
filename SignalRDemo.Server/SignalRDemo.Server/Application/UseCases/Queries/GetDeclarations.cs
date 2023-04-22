using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRDemo.Server.Api.Hubs;
using SignalRDemo.Server.Application.Dto;
using SignalRDemo.Server.Application.Exceptions;
using SignalRDemo.Server.Application.Models;
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
        private readonly DeclarationsDbContext _dbContext;
        private readonly IHubContext<DeclarationsHub, IDeclarationsHub> _declarationsHubContext;

        public Handler(IMapper mapper, DeclarationsDbContext dbContext, IHubContext<DeclarationsHub, IDeclarationsHub> declarationsHubContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _declarationsHubContext = declarationsHubContext;
        }

        public async Task<IEnumerable<DeclarationDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var user = _dbContext.Users
                    .Include(u => u.Jurisdictions)
                    .FirstOrDefault(u => u.Id == request.UserId);

            if (user == null)
            {
                throw new NotFoundException(request.UserId, nameof(User));
            }

            var jurisdictionCodes = user.Jurisdictions.Select(j => j.Code).ToList();

            var declarations = await _dbContext.Declarations
                .Include(d => d.Declarant)
                .Where(d => jurisdictionCodes.Contains(d.JurisdictionCode))
                .ToListAsync(cancellationToken);

            var result = _mapper.Map<List<DeclarationDto>>(declarations);

            return result;
        }
    }
}