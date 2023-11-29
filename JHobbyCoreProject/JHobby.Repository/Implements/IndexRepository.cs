using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JHobby.Repository.Implements
{
	public class IndexRepository : IIndexRepository
	{
		private readonly JhobbyContext _JhobbyContext;
		public IndexRepository(JhobbyContext jhobbyContext)
		{
			_JhobbyContext = jhobbyContext;
		}

		public IEnumerable<QueryActivityDto> GetActivityAll()
		{
			var dtoResult = _JhobbyContext.Activities.Include(a => a.ActivityImages)
				.Join(_JhobbyContext.Members,a=>a.MemberId,m=>m.MemberId,(a,m)=>new QueryActivityDto
				{
					ActivityId=a.ActivityId,
					MemberId=a.MemberId,
					NickName = m.NickName,
					ActivityName=a.ActivityName,
					ActivityStatus=a.ActivityStatus,
					ActivityLocation=a.ActivityLocation,
                    ActivityNotes = a.ActivityNotes,
					JoinDeadLine=a.JoinDeadLine,
					ActivityImages = a.ActivityImages
                });
			return dtoResult;


        }

		public IEnumerable<QueryMemberGenderDto> GetGenderAll()
		{
			var dtoResult = _JhobbyContext.Members.Select(m => new QueryMemberGenderDto
			{
				MemberId = m.MemberId,
				Gender = m.Gender,
				Status = m.Status,
			});

			return dtoResult;
		}

		public IEnumerable<QueryHotMemberDto> GetHotMemberAll()
		{
			var dtoResult = _JhobbyContext.Members.Join(_JhobbyContext.Activities,
			m => m.MemberId, a => a.MemberId, (m, a) => new
			{
				MemberId=m.MemberId,
				NickName = m.NickName,
				HeadShot=m.HeadShot,
				ActivityId = a.ActivityId
			}).Join(_JhobbyContext.Scores,ma=>ma.ActivityId,s=>s.ActivityId,(ma,s)=>new QueryHotMemberDto
			{
				MemberId = ma.MemberId,
				NickName = ma.NickName,
				ActivityId = ma.ActivityId,
				HeadShot=ma.HeadShot,
				Fraction =s.Fraction,
			});
			return dtoResult;
		}
	}
}
