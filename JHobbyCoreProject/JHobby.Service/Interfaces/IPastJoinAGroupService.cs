using JHobby.Repository.Models.Dto;
using JHobby.Service.Models;

namespace JHobby.Service.Implements
{
    public interface IPastJoinAGroupService
    {
        IEnumerable<PastJoinAGroupModel> GetPastJoinAGroupAll();

        //public IEnumerable<PastJoinAGroupModel> GetPastJoinAGroupById(int memberId);

        public PageFilterDto<PastJoinAGroupModel> GetPastJoinAGroupById(int memberId, int pageNumber, int pageSize);

    }
}
