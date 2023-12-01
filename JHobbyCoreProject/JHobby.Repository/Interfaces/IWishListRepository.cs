using JHobby.Repository.Models.Dto;

namespace JHobby.Repository.Interfaces
{
    public interface IWishListRepository
    {
        public IEnumerable<WishListDto> GetWishListAll();

        public IEnumerable<WishListDto> GetWishListById(int memberId);
    }
}