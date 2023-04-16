using AutoMapper;
using FluentValidation;
using SignalRDemo.Server.Data;
using SignalRDemo.Server.Dto;
using SignalRDemo.Server.Models;

namespace SignalRDemo.Server.Services;

public class DeclarationsService
{
    private readonly IValidator<CreateDeclarationRequest> _validator;
    private readonly IMapper _mapper;
    private readonly SignalRDemoDbContext _dbContext;

    public DeclarationsService(SignalRDemoDbContext dbContext, IValidator<CreateDeclarationRequest> validator, IMapper mapper)
    {
        _dbContext = dbContext;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<DeclarationDto> CreateDeclarationAsync(CreateDeclarationRequest request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var newDeclaration = new Declaration()
        {
            Description = request.Description,
            Jurisdiction = new Jurisdiction(request.Jurisdiction),
            DeclarantId = request.DeclarantId
        };

        await _dbContext.Declarations.AddAsync(newDeclaration, cancellationToken);

        return _mapper.Map<DeclarationDto>(newDeclaration);
    }
}