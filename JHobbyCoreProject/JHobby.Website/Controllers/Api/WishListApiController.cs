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
        public PageFilterViewModel<WishListViewModel> GetWishListById(int memberId, int pageNumber, int countPerPage = 5)
        {
            var queryResult = _iWishListService.GetWishListById(memberId, pageNumber, countPerPage);

            return new PageFilterViewModel<WishListViewModel>
            {
                PageNumber = queryResult.PageNumber,
                TotalPages = queryResult.TotalPages,
                Items = queryResult.Items.Select(wl => new WishListViewModel
                {
                    WishId = wl.WishId,
                    MemberId = wl.MemberId,
                    ActivityName = wl.ActivityName,
                    ActivityStatus = wl.ActivityStatus,
                    ActivityId = wl.ActivityId,
                    SurplusQuota = wl.SurplusQuota,
                    ImageName = wl.ImageName,
                })
            };
        }

        [HttpDelete]
        public IActionResult WishListDelete(int memberId, int wishId)
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
