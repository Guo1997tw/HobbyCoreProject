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
                  ActivityId = activityWish.A.ActivityId,
                  AddTime = activityWish.W.AddTime,
                  MemberId = member.MemberId,
                  WishId = activityWish.W.WishId,
                  ActivityStatus = activityWish.A.ActivityStatus,
                  ActivityName = activityWish.A.ActivityName,
                  CurrentPeople = activityWish.A.CurrentPeople,
                  JoinDeadLine = activityWish.A.JoinDeadLine,
                  MaxPeople = activityWish.A.MaxPeople,
                  StartTime = activityWish.A.StartTime,
                  NickName = member.NickName
              });
        }
    }
}
