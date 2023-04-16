using AutoMapper;
using SignalRDemo.Server.Application.Commands;
using SignalRDemo.Server.Application.Dto;
using SignalRDemo.Server.Application.Models;

namespace SignalRDemo.Server.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Declaration, DeclarationDto>()
            .ForMember(x => x.Jurisdiction,
                opt => opt.MapFrom(src => src.Jurisdiction.Code)
            )
            .ForMember(x => x.DeclarantEmail,
                opt => opt.MapFrom(src => src.Declarant.Email)
            )
            .ForMember(x => x.DeclarantId,
                opt => opt.MapFrom(src => src.Declarant.Id)
            )
            .ForMember(x => x.DisplayColor,
                opt => opt.MapFrom(src => src.Jurisdiction.DisplayColor)
            );

        CreateMap<CreateDeclarationDto, CreateDeclaration.Command>();
        CreateMap<UpdateDeclarationDto, UpdateDeclaration.Command>();
    }
}