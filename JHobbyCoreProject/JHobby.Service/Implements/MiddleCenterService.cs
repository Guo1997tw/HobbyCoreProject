using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Implements
{
	public class MiddleCenterService : IMiddleCenterService
	{
		private readonly IMiddleCenterRepository _middleCenterRepository;

		public MiddleCenterService(IMiddleCenterRepository middleCenterRepository)
		{
			_middleCenterRepository = middleCenterRepository;
		}


		public IEnumerable<QueryCategoryTypeModel> GetCategoryTypeResult(SearchModel search)
		{
			var resporitory = _middleCenterRepository.GetCategoryTypeAll();
			var query = resporitory.Where(res => res.JoinDeadLine >= DateTime.Now);
			if (search.categoyId != 0 && search.categoryTypeId != 0)
			{
				query = query.Where(res => res.CategoryId == search.categoyId && res.CategoryTypeId == search.categoryTypeId);
			}
			if (search.city !="0" && search.area !="0")
			{
				query = query.Where(res => res.ActivityCity == search.city && res.ActivityArea == search.area);
			}
			if (search.sort=="desc" )
			{
				query = query.OrderByDescending(res => res.JoinDeadLine);
			}
			return  query.Select(res => new QueryCategoryTypeModel
			{
				ActivityId = res.ActivityId,
				MemberId = res.MemberId,
				NickName = res.NickName,
				CategoryId = res.CategoryId,
				CategoryTypeId = res.CategoryTypeId,
				ActivityName = res.ActivityName.Trim(),
				ActivityStatus = res.ActivityStatus,
				ActivityLocation = res.ActivityLocation.Trim(),
				ActivityNotes = res.ActivityNotes?.Trim(),
				JoinDeadLine = res.JoinDeadLine.ToString("yyyy-MM-dd"),
				ActivityImages = res.ActivityImages.Where(ai => ai.IsCover == true).ToList()
			});

		}
	}
}
