using JHobby.Service.Models;

namespace JHobby.Service.Interfaces
{
    public interface IProfileService
    {
        public IEnumerable<ProfileModel> GetList();
        public ProfileModel GetProfileById(int id);
    }
}