using JHobby.Repository.Models.Dto;
using JHobby.Service.Models;

namespace JHobby.Service.Interfaces
{
    public interface IProfileService
    {
        public ProfileModel GetProfileById(int id);
        public IEnumerable<ProfilePastActivityModel> GetPastActivity(int id);
    }
}