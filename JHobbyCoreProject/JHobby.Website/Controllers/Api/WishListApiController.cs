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
                    SurplusQuota = wl.SurplusQuota,
                });
        }

        [HttpGet]
        public IEnumerable<WishListViewModel> GetWishListById(int memberId)
        {
            return _iWishListService.GetWishListById(memberId)
                .Select(wl => new WishListViewModel
                {
                    ActivityName = wl.ActivityName,
                    ActivityStatus = wl.ActivityStatus,
                    SurplusQuota = wl.SurplusQuota,
                });
        }

        [HttpDelete]
        public IActionResult WishListDelete(int memberId,int wishId)
        {
            if (memberId >= 0)
            {
                var result = _iWishListService.WishListDelete(memberId, wishId);

                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
