using JHobby.Repository.Models.Dto;
using JHobby.Service.Models;

namespace JHobby.Service.Interfaces
{
    public interface INowJoinAGroupService
    {
        public IEnumerable<NowJoinAGroupModel> GetNowJoinAGroupAll();
        //public IEnumerable<NowJoinAGroupModel> GetNowJoinAGroupById(int memberId);

        public bool NowJoinAGroupCancel(int activityId, int memberId, NowJoinAGroupCancelModel nowJoinAGroupCancel);

        public PageFilterDto<NowJoinAGroupModel> GetNowJoinAGroupById(int memberId, int pageNumber, int countPerPage);

    }
}