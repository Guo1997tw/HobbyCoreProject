using JHobby.Service.Models;

namespace JHobby.Service.Interfaces
{
    public interface IWishListService
    {
        public IEnumerable<WishListModel> GetWishListAll();
    }
}