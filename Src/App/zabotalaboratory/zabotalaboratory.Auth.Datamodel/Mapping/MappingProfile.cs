using AutoMapper;
using zabotalaboratory.Auth.Database.Entities;
using zabotalaboratory.Auth.Datamodel.Identities;
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

            CreateMap<Auth.Database.Entities.Identities, ZabotaIdentity>()
                .IgnoreOther()
                .ForMember(u => u.Id, opts => opts.MapFrom(u => u.Id))
                .ForMember(u => u.Login, opts => opts.MapFrom(u => u.Login));

            CreateMap<Database.Entities.UsersProfiles, ZabotaUserProfile>()
                .IgnoreOther()
                .ForMember(u => u.IdentityId, opts => opts.MapFrom(u => u.IdentityId))
                .ForMember(u => u.FirstName, opts => opts.MapFrom(u => u.FirstName))
                .ForMember(u => u.PatronymicName, opts => opts.MapFrom(u => u.PatronymicName))
                .ForMember(u => u.LastName, opts => opts.MapFrom(u => u.LastName))
                .ForMember(u => u.Email, opts => opts.MapFrom(u => u.Email))
                .ForMember(u => u.Phone, opts => opts.MapFrom(u => u.Identity.Login))
                .ForMember(u => u.Role, opts => opts.MapFrom(u => u.Identity.Role));

        }
    }
}