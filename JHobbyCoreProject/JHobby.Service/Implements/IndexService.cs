using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Entity;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;

namespace JHobby.Service.Implements
{
	public class IndexService : IIndexService
	{
		private readonly IIndexRepository _IidexResporitory;
		private readonly ICommonService _CommonService;
		public IndexService(IIndexRepository IidexResporitory,ICommonService commonService)
		{
			_IidexResporitory = IidexResporitory;
			_CommonService = commonService;
		}

		public IEnumerable<QueryActivityModel> GetActivityResult()
		{
			var resporitory = _IidexResporitory.GetActivityAll();
			//var _joinDeadline = resporitory.Where(res => res.JoinDeadLine > DateTime.Now);
			var resultModel = resporitory.Where(res=>res.JoinDeadLine>=DateTime.Now)
										.Select(res => new QueryActivityModel
			{
				ActivityId = res.ActivityId,
				MemberId = res.MemberId,
				NickName = res.NickName,
				HeadShot=res.HeadShot,
				ActivityName= res.ActivityName.Trim(),
				ActivityStatus=res.ActivityStatus,
				ActivityLocation=res.ActivityLocation.Trim(),
				ActivityNotes=res.ActivityNotes?.Trim(),
				ShotActivityNotes=res.ActivityNotes.Substring(0, _CommonService.ShotCheck(10,res.ActivityNotes)).Trim(),
				JoinDeadLine=res.JoinDeadLine.ToString("yyyy-MM-dd"),
				ActivityImages = res.ActivityImages.Where(ai => ai.IsCover == true).ToList()
			}).Take(6);
			return resultModel;
		}



		public IEnumerable<QueryMemberGenderModel> GetGenderResult()
		{
			var resporitory = _IidexResporitory.GetGenderAll();
			var _total = resporitory.Count();
			var _man = resporitory.Where(res => res.Gender == "1" && res.Status != "99").Count();
			var _woman = resporitory.Where(res => res.Gender == "0" && res.Status != "99").Count();
			var resultModel = new QueryMemberGenderModel();
			resultModel.Totle = _total;
			resultModel.Man = _man;
			resultModel.Woman = _woman;
			yield return resultModel;
		}

		public IEnumerable<QueryHotMemberModel> GetHotMemberResult()
		{
			var resporitory=_IidexResporitory.GetHotMemberAll();
			var resultModel = resporitory.GroupBy(s => new { s.MemberId, s.NickName,s.HeadShot })
				.Select(group => new QueryHotMemberModel
				{
					MemberId = group.Key.MemberId,
					NickName = group.Key.NickName,
					HeadShot= group.Key.HeadShot,
					Star = decimal.Round((decimal)group.Sum(s => s.Fraction) / group.Count(), 1)
				}).OrderByDescending(model => model.Star).Take(5);

			return resultModel;
		}

    }
}
