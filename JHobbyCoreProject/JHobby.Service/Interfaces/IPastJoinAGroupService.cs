using JHobby.Service.Models;

namespace JHobby.Service.Implements
{
    public interface IPastJoinAGroupService
    {
        IEnumerable<PastJoinAGroupModel> GetPastJoinAGroupAll();

        public IEnumerable<PastJoinAGroupModel> GetPastJoinAGroupById(int memberId);
    }
}
