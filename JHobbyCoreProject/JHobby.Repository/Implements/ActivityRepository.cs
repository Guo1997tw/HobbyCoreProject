using AutoMapper;
using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Implements
{
	public class ActivityRepository: IActivityRepository
	{
		private readonly JhobbyContext _jhobbyContext;
		private readonly IMapper _mapper;

		public ActivityRepository(JhobbyContext jhobbyContext, IMapper mapper)
		{
			_jhobbyContext = jhobbyContext;
			_mapper = mapper;
		}

		public bool InsertActivityBuild(ActivityBuildDto activityBuildDto)
		{
			var mapper = new Activity
            {
				ActivityName = activityBuildDto.ActivityName,
				ActivityCity = activityBuildDto.ActivityCity,
				ActivityArea = activityBuildDto.ActivityArea,
				ActivityLocation = activityBuildDto.ActivityLocation,
				StartTime = activityBuildDto.StartTime,
				MaxPeople = activityBuildDto.MaxPeople,
				CategoryId = activityBuildDto.CategoryId,
				CategoryTypeId = activityBuildDto.CategoryTypeId,
				JoinDeadLine = activityBuildDto.JoinDeadLine,
				JoinFee = activityBuildDto.JoinFee,
				ActivityNotes = activityBuildDto.ActivityNotes,
				MemberId = activityBuildDto.MemberId,
				ActivityStatus = activityBuildDto.ActivityStatus,
				Payment = activityBuildDto.Payment,
				Created = activityBuildDto.Created
			};

			_jhobbyContext.Activities.Add(mapper);
			_jhobbyContext.SaveChanges();

			return true;
		}

		/// <summary>
		/// 活動頁面查詢
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public ActivityPageDto GetActivityPageById(int id)
		{
			var queryResult = _jhobbyContext.Activities
				.Include(a => a.ActivityImages)
				.Where(a => a.ActivityId == id)
				.Select(a => new ActivityPageDto
				{
					ActivityId = a.ActivityId,
					MemberId = a.MemberId,
					ActivityLocation = a.ActivityLocation,
					CategoryId = a.CategoryId,
					CategoryTypeId = a.CategoryTypeId,
					ActivityName = a.ActivityName,
					StartTime = a.StartTime,
					JoinDeadLine = a.JoinDeadLine,
					ActivityNotes = a.ActivityNotes,
					ActivityImages = a.ActivityImages.Select(ai => new ActivityImageDto
					{
						ActivityImageId = ai.ActivityImageId,
						AiActivity = ai.ActivityImageId,
                        ImageName = ai.ImageName,
						IsCover = ai.IsCover,
						UploadTime = ai.UploadTime,
					}).ToList()
				}).FirstOrDefault();

            return queryResult;
        }

		/// <summary>
		/// 會員留言板查詢
		/// </summary>
		/// <returns></returns>
        public IEnumerable<MemberMsgDto> GetMsgList(int id)
		{
			var result = _jhobbyContext.Members.Join(_jhobbyContext.MsgBoards, m => m.MemberId, mb => mb.MemberId, (m, mb) => new MemberMsgDto
            {
				ActivityId = mb.ActivityId,
				HeadShot = m.HeadShot,
				MessageTime = mb.MessageTime,
				MessageText = mb.MessageText,
				NickName = m.NickName
			}).Where(f => f.ActivityId == id).ToList();

            return result;
        }
    }
}