using JHobby.Service.Models;

namespace JHobby.Service.Interfaces
{
    public interface INowJoinAGroupService
    {
        public IEnumerable<NowJoinAGroupModel> GetNowJoinAGroupAll();
    }
}