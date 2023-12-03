using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerable<WishListDto> GetWishListById(int memberId)
        {
            return _jhobbyContext.Wishes.Where(w => w.MemberId == memberId)
                .Include(a => a.Activity)
                .Select(w => new WishListDto
                {
                    ActivityName = w.Activity.ActivityName,
                    ActivityStatus = w.Activity.ActivityStatus,
                    MaxPeople = w.Activity.MaxPeople,
                    CurrentPeople = w.Activity.CurrentPeople,
                });
        }

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
    }
}
