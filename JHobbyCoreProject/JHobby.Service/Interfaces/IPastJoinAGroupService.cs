using JHobby.Service.Models;

namespace JHobby.Service.Implements
{
    public interface IPastJoinAGroupService
    {
        public IQueryable<PastJoinAGroupModel> GetPastJoinAGroupsList(int page, int pageSize); 
    }
}
