using JHobby.Repository.Models.Dto;

namespace JHobby.Repository.Interfaces
{
    public interface IWishListRepository
    {
        public IEnumerable<WishListDto> GetWishListAll();

        public bool WishListDelete(int memberId, int wishId);

        public IEnumerable<WishListDto> GetWishListById(int memberId);

        public PageFilterDto<WishListDto> GetWishListById(int memberId, int pageNumber, int countPerPage);
    }
}