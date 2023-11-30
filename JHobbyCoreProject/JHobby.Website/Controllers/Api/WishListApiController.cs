using JHobby.Service.Interfaces;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers.Api
{
    [EnableCors("allowCors")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class WishListApiController : ControllerBase
    {
        private readonly IWishListService _iWishListService;

        public WishListApiController(IWishListService iWishListService)
        {
            _iWishListService = iWishListService;
        }

        [HttpGet]
        public IEnumerable<WishListViewModel> GetWishListAll()
        {
            return _iWishListService.GetWishListAll()
                .Select(wl => new WishListViewModel
                {
                    ActivityName = wl.ActivityName,
                    ActivityStatus = wl.ActivityStatus,
                    NickName = wl.NickName,
                    SurplusQuota = wl.SurplusQuota,
                });
        }
    }
}
