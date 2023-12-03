using JHobby.Repository.Implements;
using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Service.Models.Dto;

namespace JHobby.Service.Implements
{
	public class GroupStartingService : IGroupStartingService
	{
		private readonly IGroupStartingRepository _groupStartingRepository;
        private readonly ICommonService _iCommonService;

        public GroupStartingService(IGroupStartingRepository groupStartingRepository, ICommonService  commonService)
		{
            _iCommonService = commonService;
            _groupStartingRepository = groupStartingRepository;
		}
		public IEnumerable<GroupStartingModel> GetGroupStartingAll()
		{
			return _groupStartingRepository.GetGroupStartingAll().Select(a => new GroupStartingModel
			{
				   ActivityId = a.ActivityId,
				   ActivityName = a.ActivityName,
				   CurrentPeople = a.CurrentPeople,
				   ActivityStatus = a.ActivityStatus,
				   StartTime = a.StartTime,
				   MaxPeople = a.MaxPeople,
				   IsCover = a.IsCover,
				   ImageName = a.ImageName,
				   ActivityImageId = a.ActivityImageId,

			   });

		}
		//public bool Delete(int id)
		//{
		//	var queryResult = _groupStartingRepository.GetByIdNow(id);

		//	if (queryResult == null) return false;

		//	_groupStartingRepository.Delete(id);

		//	return true;
		//}

		public bool Update(int id, GroupStartingModel GroupStartingModel)
		{
			var queryResult = _groupStartingRepository.GetByIdNow(id);

			if (queryResult == null) return false;

			var dto = new GroupStartingDto
			{
				CurrentPeople = GroupStartingModel.CurrentPeople
			};

			_groupStartingRepository.Update(id, dto);

			return true;
		}

		public IEnumerable<GroupStartingModel> GetByIdNow(int id)    /*IEnumerable多筆*/
		{
			var result = _groupStartingRepository.GetByIdNow(id);
			var queryResult = result.Select(a => new GroupStartingModel

			{
				MemberId = a.MemberId,
				ActivityId = a.ActivityId,
				ActivityName = a.ActivityName,
				CurrentPeople = a.CurrentPeople,
				ActivityStatus = _iCommonService.ConvertReviewStatus(a.ActivityStatus),
				StartTime = a.StartTime,
				MaxPeople = a.MaxPeople,
				IsCover = a.IsCover,
				ImageName = a.ImageName,
				ActivityImageId = a.ActivityImageId,
                DateConvert = _iCommonService.ConvertTime(a.StartTime).First().DateConvert,
                TimeConvert = _iCommonService.ConvertTime(a.StartTime).First().TimeConvert



            });

			return queryResult;
		}
	}
}







