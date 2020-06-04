using AutoMapper;
using zabotalaboratory.Auth.Database.Entities;
using zabotalaboratory.Auth.Datamodel.Identities;
using zabotalaboratory.Auth.Datamodel.Roles;
using zabotalaboratory.Auth.Datamodel.Tokens;
using zabotalaboratory.Auth.Datamodel.UserProfiles;
using zabotalaboratory.Common.AutoMapper.Extensions;

namespace zabotalaboratory.Auth.Datamodel.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Jwts, Jwt>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.Token, opts => opts.MapFrom(u => u.Token))
                .ForMember(u => u.Expires, opts => opts.MapFrom(u => u.Expires));

            CreateMap<Database.Entities.Identities, ZabotaIdentity>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.Login, opts => opts.MapFrom(u => u.Login))
                .ForMember(u => u.Role, opts => opts.MapFrom(u => u.Role))
                .ForMember(u => u.ClinicId, opts => opts.MapFrom(u => u.ClinicId))
                .ForMember(u => u.ClinicName, opts => opts.MapFrom(u => u.ClinicName));

            CreateMap<Database.Entities.UsersProfiles, ZabotaUserProfile>()
                .IgnoreOther()
                .ForMember(u => u.IdentityId, opts => opts.MapFrom(u => u.IdentityId))
                .ForMember(u => u.AbbreviatedNameOfCompany, opts => opts.MapFrom(u => u.AbbreviatedNameOfCompany))
                .ForMember(u => u.FullNameOfCompany, opts => opts.MapFrom(u => u.FullNameOfCompany))
                .ForMember(u => u.Email, opts => opts.MapFrom(u => u.Email))
                .ForMember(u => u.Address, opts => opts.MapFrom(u => u.Address));

            CreateMap<Database.Entities.Roles, ZabotaRoles>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.Name, opts => opts.MapFrom(u => u.Name));

        }
    }
}