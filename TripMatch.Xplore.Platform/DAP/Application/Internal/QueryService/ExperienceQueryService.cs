using TripMatch.Xplore.Platform.DAP.Domain.Models.Entities;
using TripMatch.Xplore.Platform.DAP.Domain.Models.Queries;
using TripMatch.Xplore.Platform.DAP.Domain.Repositories;
using TripMatch.Xplore.Platform.DAP.Domain.Services;
using TripMatch.Xplore.Platform.Profile.Domain;

namespace TripMatch.Xplore.Platform.DAP.Application.Internal.QueryService
{
    public class ExperienceQueryService(IExperienceRepository experienceRepository, IUserRepository userRepository) : IExperienceQueryService
    {
        private readonly IExperienceRepository _experienceRepository = experienceRepository;
        private readonly IUserRepository _userRepository = userRepository;
        public async Task<IEnumerable<Experience>> Handle(GetAllExperiencesQuery query)
        {
            return await experienceRepository.ListAsync();
        }
        public async Task<IEnumerable<Experience>> Handle(GetExperiencesByCategoryQuery query)
        {
            return await experienceRepository.ListByCategoryIdAsync(query.CategoryId);
        }
        public async Task<Experience?> Handle(GetExperienceByIdQuery query)
        {
            return await _experienceRepository.FindByIdAsync(query.ExperienceId);
        }
        
        public async Task<IEnumerable<Experience>> Handle(GetExperiencesByAgencyQuery query)
        {
            var agencyUser = await _userRepository.FindByGuidAsync(query.AgencyUserId);
            if (agencyUser == null || agencyUser.Agency == null)
            {
                return new List<Experience>(); 
            }
            
            return await _experienceRepository.FindByAgencyUserIdAsync(query.AgencyUserId);
        }
    }
    
}

