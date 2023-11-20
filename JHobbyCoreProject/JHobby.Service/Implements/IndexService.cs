using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Entity;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;

namespace JHobby.Service.Implements
{
	public class IndexService : IIndexService
	{
		private IIndexRepository _IidexResporitory;

		public IndexService(IIndexRepository IidexResporitory)
		{
			_IidexResporitory = IidexResporitory;
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
				MemberName = res.MemberName,
				ActivityName= res.ActivityName.Trim(),
				ActivityStatus=res.ActivityStatus,
				ActivityLocation=res.ActivityLocation.Trim(),
				ActivityNotes=res.ActivityNotes?.Trim(),
				JoinDeadLine=res.JoinDeadLine.ToString("yyyy-MM-dd"),
				ActivityImages = res.ActivityImages.Where(ai => ai.IsCover == true).ToList()
			});
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
		public IEnumerable<QueryWishModel> GetWishByIdResult(int id)
		{
			var resporitory = _IidexResporitory.GetWishById(id);
			var resultModel = resporitory.Where(s=>s.MemberId==id)
										.Select(res => new QueryWishModel
			{
				ActivityId=res.ActivityId,
			});
			return resultModel;
		}
	}
}
