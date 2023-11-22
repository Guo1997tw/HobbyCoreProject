using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
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

		public IEnumerable<QueryCategoryTypeModel> GetCategoryTypeResult(int categoyId, int categoryTypeId)
		{
			{
				var resporitory = _middleCenterRepository.GetCategoryTypeAll();
				var resultModel = resporitory.Where(res => res.JoinDeadLine >= DateTime.Now &&
											res.CategoryId== categoyId && res.CategoryTypeId== categoryTypeId)
											.Select(res => new QueryCategoryTypeModel
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
				return resultModel;
			}
		}

	}
}
