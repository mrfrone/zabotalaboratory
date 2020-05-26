using System.Threading.Tasks;
using AutoMapper;
using zabotalaboratory.Auth.Database.Repository.Identities;
using System.Collections.Generic;
using zabotalaboratory.Auth.Datamodel.Identities;
using zabotalaboratory.Common.Result;
using zabotalaboratory.Auth.Datamodel.Roles;
using zabotalaboratory.Common.Result.ErrorCodes;
using zabotalaboratory.Auth.Forms.Identity;

namespace zabotalaboratory.Auth.Services.Identities
{
    internal class IdentityService : IIdentityService
    {
        private readonly IIdentitiesRepository _identitiesRepository;
        private readonly IMapper _mapper;

        public IdentityService(IIdentitiesRepository identitiesRepository, IMapper mapper)
        {
            _identitiesRepository = identitiesRepository;
            _mapper = mapper;
        }

        public async Task<ZabotaResult<IEnumerable<ZabotaIdentity>>> GetIdentities()
        {
            var result = await _identitiesRepository.Get();
            var mappedIdentities =  _mapper.Map<IEnumerable<ZabotaIdentity>>(result);

            return new ZabotaResult<IEnumerable<ZabotaIdentity>>(mappedIdentities);
        }

        public async Task<ZabotaResult<ZabotaIdentity>> GetIdentityById(int id)
        {
            var model = await _identitiesRepository.IdentityById(id);
            if (model == null)
                return ZabotaErrorCodes.CannotFindIdentityById;

            var mappedModel = _mapper.Map<Database.Entities.Identities, ZabotaIdentity>(model);
            return new ZabotaResult<ZabotaIdentity>(mappedModel);
        }

        public async Task<ZabotaIdentity> GetIdentityByTokenId(int id)
        {
            var model = await _identitiesRepository.IdentityByTokenId(id);
            if (model == null)
                return null;

            var mappedModel = _mapper.Map<Database.Entities.Identities, ZabotaIdentity>(model);
            return mappedModel;
        }

        public async Task<ZabotaResult<IEnumerable<ZabotaRoles>>> GetRoles() 
        {
            var model = await _identitiesRepository.GetRoles();
            var mappedModel = _mapper.Map<IEnumerable<ZabotaRoles>>(model);

            return new ZabotaResult<IEnumerable<ZabotaRoles>>(mappedModel);
        }

        public async Task<ZabotaResult<IEnumerable<ZabotaSubRoles>>> GetSubRoles()
        {
            var model = await _identitiesRepository.GetSubRoles();
            var mappedModel = _mapper.Map<IEnumerable<ZabotaSubRoles>>(model);

            return new ZabotaResult<IEnumerable<ZabotaSubRoles>>(mappedModel);
        }

        public async Task<ZabotaResult<bool>> AddIdentity(AddIdentityForm form)
        {
            var model = await _identitiesRepository.IdentityByLogin(form.Login);
            if (model != null)
                return ZabotaErrorCodes.IdentityExists;

            await _identitiesRepository.Add(form);
            return new ZabotaResult<bool>(true);
        }

        public async Task<ZabotaResult<bool>> UpdateIdentity(UpdateIdentityForm form)
        {
            var result = await _identitiesRepository.Update(form);
            if (result != true)
                return ZabotaErrorCodes.CannotFindIdentityById;

            return new ZabotaResult<bool>(true);
        }

        public async Task<ZabotaResult<bool>> DeleteIdentity(int id, int actorId)
        {
            if (id == actorId)
                return ZabotaErrorCodes.CannotDeleteCurrentUser;

            var result = await _identitiesRepository.Delete(id, actorId);
            if (result != true)
                return ZabotaErrorCodes.CannotFindIdentityById;

            return new ZabotaResult<bool>(true);
        }
    }
}