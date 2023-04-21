using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRDemo.Server.Api.Hubs;
using SignalRDemo.Server.Application.Dto;
using SignalRDemo.Server.Infrastructure.Data;

namespace SignalRDemo.Server.Application.UseCases.Queries;

public static class GetJurisdictions
{
    public class Query : IRequest<IEnumerable<JurisdictionDto>>
    {
    }

    public class Handler : IRequestHandler<Query, IEnumerable<JurisdictionDto>>
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

        public async Task<IEnumerable<JurisdictionDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var jurisdictions = await _dbContext.Jurisdictions.ToListAsync(cancellationToken);

            var result = _mapper.Map<List<JurisdictionDto>>(jurisdictions);

            return result;
        }
    }
}