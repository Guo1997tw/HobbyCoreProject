using JHobby.Repository.Models.Dto;

namespace JHobby.Repository.Interfaces;

public interface IWishRepository
{
    public IEnumerable<WishDto> GetById(int id);
    public bool Create(WishCreateDto dto);
    public bool Delete(int memberId, int activityId);
}