using JHobby.Service.Models;

namespace JHobby.Service.Implements
{
    internal interface IPastJoinAGroupService
    {
        public IEnumerable<PastJoinAGroupModel> GetPastJoinAGroupsList();
    }
}
