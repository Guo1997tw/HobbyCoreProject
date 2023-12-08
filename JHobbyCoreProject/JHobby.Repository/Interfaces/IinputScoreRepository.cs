using JHobby.Repository.Models.Dto;

namespace JHobby.Repository.Interfaces
{
    public interface IinputScoreRepository
    {
        public bool NewInputScoreById(InputScoreDto inputScoreDto);
    }
}