using JHobby.Repository.Models.Dto;

namespace JHobby.Repository.Interfaces
{
    public interface INowJoinAGroupRepository
    {
        public IEnumerable<NowJoinAGroupDto> GetNowJoinAGroupAll();
    }
}