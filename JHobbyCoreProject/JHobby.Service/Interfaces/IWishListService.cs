using JHobby.Service.Models;

namespace JHobby.Service.Interfaces
{
    public interface IWishListService
    {
        public IEnumerable<WishListModel> GetWishListAll();

        public IEnumerable<WishListModel> GetWishListById(int memberId);

        public bool WishListDelete(int memberId,int wishId);

    }
}