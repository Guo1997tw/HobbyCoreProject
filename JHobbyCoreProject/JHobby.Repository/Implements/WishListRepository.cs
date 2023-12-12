using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JHobby.Repository.Implements
{
    public class WishListRepository : IWishListRepository
    {
        private readonly JhobbyContext _jhobbyContext;

        public WishListRepository(JhobbyContext jhobbyContext)
        {
            _jhobbyContext = jhobbyContext;
        }

        public IEnumerable<WishListDto> GetWishListAll()
        {
            return _jhobbyContext.Activities
        .Join(_jhobbyContext.Wishes,
              a => a.ActivityId,
              w => w.ActivityId,
              (a, w) => new { A = a, W = w })
        .Join(_jhobbyContext.Members,
              aw => aw.W.MemberId,
              m => m.MemberId,
              (activityWish, member) => new WishListDto
              {
                  ActivityStatus = activityWish.A.ActivityStatus,
                  ActivityName = activityWish.A.ActivityName,
              });
        }

        //public IEnumerable<WishListDto> GetWishListById(int memberId)
        //{
        //    var imageName = _jhobbyContext.ActivityImages.Select(ai =>new { id = ai.ActivityId, imageName = ai.ImageName });

        //    return _jhobbyContext.Wishes.Where(w => w.MemberId == memberId)
        //        .Include(a => a.Activity)
        //        .Select(w => new WishListDto
        //        {
        //            WishId = w.WishId,
        //            MemberId = w.MemberId,
        //            ActivityId = w.ActivityId,
        //            ActivityName = w.Activity.ActivityName,
        //            ActivityStatus = w.Activity.ActivityStatus,
        //            MaxPeople = w.Activity.MaxPeople,
        //            CurrentPeople = w.Activity.CurrentPeople,
        //            ImageName = imageName.FirstOrDefault(iN => iN.id == w.ActivityId).imageName,
        //        });
        //}

        public bool WishListDelete(int memberId, int wishId)
        {
            var wishListDelectDto = _jhobbyContext.Wishes
                .FirstOrDefault(w => w.MemberId == memberId && w.WishId == wishId);

            if (wishListDelectDto != null)
            {
                _jhobbyContext.Wishes.Remove(wishListDelectDto);
                _jhobbyContext.SaveChanges();
                return true;
            }
            else { return false; }
        }

        public PageFilterDto<WishListDto> GetWishListById(int memberId, int pageNumber, int countPerPage)
        {
            var imageName = _jhobbyContext.ActivityImages.Select(ai => new { id = ai.ActivityId, imageName = ai.ImageName });

            var query = _jhobbyContext.Wishes.Where(w => w.MemberId == memberId)
                .Include(a => a.Activity)
                .Select(w => new WishListDto
                {
                    WishId = w.WishId,
                    MemberId = w.MemberId,
                    ActivityId = w.ActivityId,
                    ActivityName = w.Activity.ActivityName,
                    ActivityStatus = w.Activity.ActivityStatus,
                    MaxPeople = w.Activity.MaxPeople,
                    CurrentPeople = w.Activity.CurrentPeople,
                    ImageName = imageName.FirstOrDefault(iN => iN.id == w.ActivityId).imageName,
                });

            var totalItems = query.Count();
            var totalPage = (int)Math.Ceiling(totalItems / (decimal)countPerPage);
            var filterPage = query
                .Skip((pageNumber - 1) * countPerPage)
                .Take(countPerPage);

            return new PageFilterDto<WishListDto>
            {
                PageNumber = pageNumber,
                TotalPages = totalPage,
                Items = filterPage
            };
        }

        public IEnumerable<WishListDto> GetWishListById(int memberId)
        {
            return _jhobbyContext.Wishes.Where(w => w.MemberId == memberId)
                .Include(a => a.Activity)
                .Select(w => new WishListDto
                {
                    MemberId = w.MemberId,
                    ActivityId = w.ActivityId,
                });
        }
    }
}
