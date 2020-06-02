using System;
using System.Threading.Tasks;
using AutoMapper;
using zabotalaboratory.Auth.Database.Entities;
using zabotalaboratory.Auth.Database.Repository.UserProfiles;
using zabotalaboratory.Auth.Datamodel.UserProfiles;
using zabotalaboratory.Auth.Forms.UsersProfiles;
using zabotalaboratory.Common.Result;
using zabotalaboratory.Common.Result.ErrorCodes;

namespace zabotalaboratory.Auth.Services.UserProfile
{
    internal class UserProfilesService : IUserProfileService
    {
        private readonly IUsersProfilesRepository _userProfilesRepository;
        private readonly IMapper _mapper;

        public UserProfilesService(IUsersProfilesRepository userProfilesRepository, IMapper mapper)
        {
            _userProfilesRepository = userProfilesRepository;
            _mapper = mapper;
        }

        public async Task<ZabotaResult<ZabotaUserProfile>> GetByIdentityId(int identityId)
        {
            var model = await _userProfilesRepository.GetByIdentityId(identityId);
            if (model == null)
                return ZabotaErrorCodes.CannotFindUserProfileByIdentityId;

            var mappedModel = _mapper.Map<UsersProfiles, ZabotaUserProfile>(model);
            return new ZabotaResult<ZabotaUserProfile>(mappedModel);
        }
        
        public async Task<ZabotaResult<bool>> UpdateUserProfile(UpdateUserProfileForm form) 
        {
            var model = await GetByIdentityId(form.IdentityId);
            if (model.IsNotCorrect)
                await _userProfilesRepository.AddByIdentityId(form.IdentityId);

            await _userProfilesRepository.Update(form);

            return new ZabotaResult<bool>(true);
        }

        public async Task<ZabotaResult<string>> GetAbbreviatedNameOfCompany(int identityId)
        {
            var model = await GetByIdentityId(identityId);
            if(model.IsNotCorrect)
                return new ZabotaResult<string>(String.Empty);

            return new ZabotaResult<string>(model.Result.AbbreviatedNameOfCompany);
        }
    }
}