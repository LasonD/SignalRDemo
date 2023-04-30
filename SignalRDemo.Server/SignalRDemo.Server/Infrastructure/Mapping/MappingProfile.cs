using AutoMapper;
using SignalRDemo.Server.Application.Dto;
using SignalRDemo.Server.Application.Models;
using SignalRDemo.Server.Application.UseCases.Commands;

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

        CreateMap<Jurisdiction, JurisdictionDto>();

        CreateMap<CreateDeclarationDto, CreateDeclaration.Command>();
        CreateMap<UpdateDeclarationDto, UpdateDeclaration.Command>();

        CreateMap<CreateDeclaration.Command, Declaration>()
            .ForMember(x => x.JurisdictionCode, opt => opt.MapFrom(x => x.Jurisdiction))
            .ForMember(x => x.Jurisdiction, opt => opt.Ignore());
        CreateMap<UpdateDeclaration.Command, Declaration>()
            .ForMember(x => x.JurisdictionCode, opt => opt.MapFrom(x => x.Jurisdiction))
            .ForMember(x => x.Jurisdiction, opt => opt.Ignore());
    }
}