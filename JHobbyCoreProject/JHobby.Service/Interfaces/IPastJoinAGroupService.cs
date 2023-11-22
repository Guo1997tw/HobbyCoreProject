using JHobby.Service.Models;

namespace JHobby.Service.Implements
{
    public interface IPastJoinAGroupService
    {
        public IEnumerable<PastJoinAGroupModel> GetPastJoinAGroupsList(); 
    }
}
