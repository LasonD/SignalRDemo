using Microsoft.EntityFrameworkCore;
using SignalRDemo.Server.Dto;
using SignalRDemo.Server.Models;

namespace SignalRDemo.Server.Services;

public class DeclarationsService
{
    private readonly DbContext dbContext;

    public DeclarationsService(DbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Task<DeclarationDto> CreateDeclarationAsync(CreateDeclarationRequest request, CancellationToken cancellationToken)
    {
        var newDeclaration = new Declaration()
        {
            Description = request.Description,
        };
    }
}