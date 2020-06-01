using AutoMapper;
using zabotalaboratory.Analyses.Datamodel.Analyses;
using zabotalaboratory.Analyses.Datamodel.Clinics;
using zabotalaboratory.Analyses.Datamodel.LaboratoryAnalyses;
using zabotalaboratory.Analyses.Datamodel.Talons;
using zabotalaboratory.Common.AutoMapper.Extensions;

namespace zabotalaboratory.Analyses.Datamodel.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Database.Entities.LaboratoryAnalyses, ZabotaLaboratoryAnalyses>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.FirstName, opts => opts.MapFrom(u => u.FirstName))
                .ForMember(u => u.LastName, opts => opts.MapFrom(u => u.LastName))
                .ForMember(u => u.PatronymicName, opts => opts.MapFrom(u => u.PatronymicName))
                .ForMember(u => u.DateOfBirth, opts => opts.MapFrom(u => u.DateOfBirth))
                .ForMember(u => u.Clinic, opts => opts.MapFrom(u => u.Clinic))
                .ForMember(u => u.PickUpDate, opts => opts.MapFrom(u => u.PickUpDate))
                .ForMember(u => u.Talons, opts => opts.MapFrom(u => u.Talons));

            CreateMap<Database.Entities.Talons, ZabotaTalons>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.AnalysesType, opts => opts.MapFrom(u => u.AnalysesType))
                .ForMember(u => u.AnalysesResult, opts => opts.MapFrom(u => u.AnalysesResult));

            CreateMap<Database.Entities.AnalysesResult, ZabotaAnalysesResult>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.Result, opts => opts.MapFrom(u => u.Result))
                .ForMember(u => u.LaboratoryAnalysesTest, opts => opts.MapFrom(u => u.LaboratoryAnalysesTests));

            CreateMap<Database.Entities.Clinics, ZabotaClinics>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.Name, opts => opts.MapFrom(u => u.Name))
                .ForMember(u => u.IsValid, opts => opts.MapFrom(u => u.IsValid));

            CreateMap<Database.Entities.AnalysesTypes, ZabotaAnalysesTypes>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.Name, opts => opts.MapFrom(u => u.Name))
                .ForMember(u => u.Number1C, opts => opts.MapFrom(u => u.Number1C))
                .ForMember(u => u.IsValid, opts => opts.MapFrom(u => u.IsValid))
                .ForMember(u => u.LaboratoryAnalysesTests, opts => opts.MapFrom(u => u.LaboratoryAnalysesTests));

            CreateMap<Database.Entities.LaboratoryAnalysesTests, ZabotaLaboratoryAnalysesTests>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.Name, opts => opts.MapFrom(u => u.Name))
                .ForMember(u => u.Number1C, opts => opts.MapFrom(u => u.Number1C))
                .ForMember(u => u.IsValid, opts => opts.MapFrom(u => u.IsValid))
                .ForMember(u => u.AnalysesTypesId, opts => opts.MapFrom(u => u.AnalysesTypesId));
        }
    }
}