using MediatR;

namespace SignalRDemo.Server.Application.Dto;

public class UpdateDeclarationDto : IRequest<DeclarationDto>
{
    public string Id { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Jurisdiction { get; set; } = null!;
}