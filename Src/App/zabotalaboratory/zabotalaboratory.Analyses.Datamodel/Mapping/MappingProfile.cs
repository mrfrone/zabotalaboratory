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
                .ForMember(u => u.Gender, opts => opts.MapFrom(u => u.Gender))
                .ForMember(u => u.Clinic, opts => opts.MapFrom(u => u.Clinic))
                .ForMember(u => u.PickUpDate, opts => opts.MapFrom(u => u.PickUpDate))
                .ForMember(u => u.Doctor, opts => opts.MapFrom(u => u.Doctor))
                .ForMember(u => u.Talons, opts => opts.MapFrom(u => u.Talons));

            CreateMap<Database.Entities.Talons, ZabotaTalons>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.AnalysesType, opts => opts.MapFrom(u => u.AnalysesType))
                .ForMember(u => u.AnalysesResult, opts => opts.MapFrom(u => u.AnalysesResult))
                .ForMember(u => u.PerformedBy, opts => opts.MapFrom(u => u.PerformedBy));

            CreateMap<Database.Entities.AnalysesResult, ZabotaAnalysesResult>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.Result, opts => opts.MapFrom(u => u.Result))
                .ForMember(u => u.LaboratoryAnalysesTest, opts => opts.MapFrom(u => u.LaboratoryAnalysesTests))
                .ForMember(u => u.Units, opts => opts.MapFrom(u => u.Units))
                .ForMember(u => u.ReferenceLimits, opts => opts.MapFrom(u => u.ReferenceLimits));

            CreateMap<Database.Entities.Clinics, ZabotaClinics>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.Name, opts => opts.MapFrom(u => u.Name))
                .ForMember(u => u.IsValid, opts => opts.MapFrom(u => u.IsValid));

            CreateMap<Database.Entities.AnalysesTypes, ZabotaAnalysesTypes>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.Name, opts => opts.MapFrom(u => u.Name))
                .ForMember(u => u.ExcelName, opts => opts.MapFrom(u => u.ExcelName))
                .ForMember(u => u.PDFName, opts => opts.MapFrom(u => u.PDFName))
                .ForMember(u => u.Number1C, opts => opts.MapFrom(u => u.Number1C))
                .ForMember(u => u.NumberInOrder, opts => opts.MapFrom(u => u.NumberInOrder))
                .ForMember(u => u.IsValid, opts => opts.MapFrom(u => u.IsValid))
                .ForMember(u => u.LaboratoryAnalysesTests, opts => opts.MapFrom(u => u.LaboratoryAnalysesTests))
                .ForMember(u => u.BioMaterial, opts => opts.MapFrom(u => u.BioMaterial));

            CreateMap<Database.Entities.LaboratoryAnalysesTests, ZabotaLaboratoryAnalysesTests>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.Name, opts => opts.MapFrom(u => u.Name))
                .ForMember(u => u.Number1C, opts => opts.MapFrom(u => u.Number1C))
                .ForMember(u => u.NumberInOrder, opts => opts.MapFrom(u => u.NumberInOrder))
                .ForMember(u => u.IsValid, opts => opts.MapFrom(u => u.IsValid))
                .ForMember(u => u.AnalysesTypesId, opts => opts.MapFrom(u => u.AnalysesTypesId))
                .ForMember(u => u.ExcelName, opts => opts.MapFrom(u => u.ExcelName))
                .ForMember(u => u.PDFName, opts => opts.MapFrom(u => u.PDFName));

            CreateMap<Database.Entities.AnalysesTypes, ZabotaAnalysesTypesAddForm>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.Name, opts => opts.MapFrom(u => u.Name))
                .ForMember(u => u.PDFName, opts => opts.MapFrom(u => u.PDFName))
                .ForMember(u => u.ExcelName, opts => opts.MapFrom(u => u.ExcelName))
                .ForMember(u => u.Number1C, opts => opts.MapFrom(u => u.Number1C))
                .ForMember(u => u.NumberInOrder, opts => opts.MapFrom(u => u.NumberInOrder))
                .ForMember(u => u.IsNeeded, opts => opts.MapFrom(u => false))
                .ForMember(u => u.LaboratoryAnalysesTests, opts => opts.MapFrom(u => u.LaboratoryAnalysesTests));

            CreateMap<Database.Entities.LaboratoryAnalysesTests, ZabotaLaboratoryAnalysesTestsAddForm>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.Name, opts => opts.MapFrom(u => u.Name))
                .ForMember(u => u.ExcelName, opts => opts.MapFrom(u => u.ExcelName))
                .ForMember(u => u.PDFName, opts => opts.MapFrom(u => u.PDFName))
                .ForMember(u => u.Number1C, opts => opts.MapFrom(u => u.Number1C))
                .ForMember(u => u.NumberInOrder, opts => opts.MapFrom(u => u.NumberInOrder))
                .ForMember(u => u.IsNeeded, opts => opts.MapFrom(u => false))
                .ForMember(u => u.AnalysesTypesId, opts => opts.MapFrom(u => u.AnalysesTypesId));

            CreateMap<Database.Entities.Gender, ZabotaGender>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.Name, opts => opts.MapFrom(u => u.Name))
                .ForMember(u => u.ShortName, opts => opts.MapFrom(u => u.ShortName));
        }
    }
}