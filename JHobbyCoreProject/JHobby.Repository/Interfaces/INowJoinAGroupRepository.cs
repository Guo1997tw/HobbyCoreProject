using JHobby.Repository.Models.Dto;

namespace JHobby.Repository.Interfaces
{
    public interface INowJoinAGroupRepository
    {
        public IEnumerable<NowJoinAGroupDto> GetNowJoinAGroupAll();
        public IEnumerable<NowJoinAGroupDto> GetNowJoinAGroupById(int memberId);

        public bool NowJoinAGroupCancel(int activityUserId, int memberId, NowJoinAGroupCancelDto aGroupCancelDto);
    }
}