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
                ActivityId = gw.ActivityId,
                AddTime = gw.AddTime,
                MemberId = gw.MemberId,
                WishId = gw.WishId,
                ActivityStatus = _commonService.ConvertActivityStatus(gw.ActivityStatus),
                ActivityName = gw.ActivityName,
                JoinDeadLine = gw.JoinDeadLine,
                StartTime = gw.StartTime,
                NickName = gw.NickName,
                SurplusQuota = _commonService.CountSurplusQuota(gw.MaxPeople, gw.CurrentPeople)
            });
        }
    }
}
