using JHobby.Repository.Interfaces;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Implements
{
    public class WishListService : IWishListService
    {
        private readonly IWishListRepository _iWishListRepository;
        private readonly ICommonService _commonService;

        public WishListService(IWishListRepository wishListRepository, ICommonService commonService)
        {
            _iWishListRepository = wishListRepository;
            _commonService = commonService;
        }

        public IEnumerable<WishListModel> GetWishListAll()
        {
            return _iWishListRepository.GetWishListAll().Select(gw => new WishListModel
            {
                ActivityStatus = _commonService.ConvertActivityStatus(gw.ActivityStatus),
                ActivityName = gw.ActivityName,
                SurplusQuota = _commonService.CountSurplusQuota(gw.MaxPeople, gw.CurrentPeople)
            });
        }

        public IEnumerable<WishListModel> GetWishListById(int memberId)
        {
            return _iWishListRepository.GetWishListById(memberId).Select(gw => new WishListModel
            {
                WishId = gw.WishId,
                MemberId = gw.MemberId,
                ActivityStatus = _commonService.ConvertActivityStatus(gw.ActivityStatus),
                ActivityName = gw.ActivityName,
                SurplusQuota = _commonService.CountSurplusQuota(gw.MaxPeople, gw.CurrentPeople)
            });
        }

        public bool WishListDelete(int memberId,int wishId)
        {
            var wishListDto = _iWishListRepository.GetWishListById(memberId);

            if (wishListDto != null)
            {
                _iWishListRepository.WishListDelete(memberId,wishId);
                return true;
            }
            else { return false; }
        }
    }
}
