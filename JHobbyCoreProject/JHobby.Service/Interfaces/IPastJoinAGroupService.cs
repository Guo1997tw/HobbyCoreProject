using JHobby.Service.Models;

namespace JHobby.Service.Implements
{
    public interface IPastJoinAGroupService
    {
        IEnumerable<PastJoinAGroupModel> GetAll();
        public IQueryable<PastJoinAGroupModel> GetPastJoinAGroupsList(int page, int pageSize); 
    }
}
