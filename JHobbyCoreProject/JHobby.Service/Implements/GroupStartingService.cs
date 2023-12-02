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

        public GroupStartingService(IGroupStartingRepository groupStartingRepository, ICommonService commonService)
		{

			_groupStartingRepository = groupStartingRepository;
            _iCommonService = commonService;
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
		public bool Delete(int id)
		{
			var queryResult = _groupStartingRepository.GetByIdNow(id);

			if (queryResult == null) return false;

			_groupStartingRepository.Delete(id);

			return true;
		}

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
				ActivityStatus = a.ActivityStatus,
				StartTime = a.StartTime,
				MaxPeople = a.MaxPeople,
				IsCover = a.IsCover,
				ImageName = a.ImageName,
				ActivityImageId = a.ActivityImageId,

			});

			return queryResult;
		}
        public IEnumerable<GroupStartingCurrentModel> CurrentById(int id, int ActivityId)
        {
            var resultDto = _groupStartingRepository.CurrentById(id, ActivityId);


            var reviewModel = resultDto.OrderByDescending(dto => dto.ReviewTime).Select(dto => new GroupStartingCurrentModel
            {
                ActivityId = dto.ActivityId,
                LeaderId = dto.LeaderId,
                ActivityName = dto.ActivityName.Trim(),
                ReviewStatus = _iCommonService.ConvertReviewStatus(dto.ReviewStatus),
                ReviewTime = dto.ReviewTime.ToString("yyyy-MM-dd HH:mm:ss"),
                ApplicantId = dto.ApplicantId,
                ActivityImageId = dto.ActivityImageId,
                ImageName = dto.ImageName,
                IsCover = dto.IsCover,
                NickName = dto.NickName,
                HeadShot = dto.HeadShot,
                DateConvert = _iCommonService.ConvertTime(dto.ReviewTime).First().DateConvert,
                TimeConvert = _iCommonService.ConvertTime(dto.ReviewTime).First().TimeConvert
            });

            return reviewModel;
        }
    }
}







