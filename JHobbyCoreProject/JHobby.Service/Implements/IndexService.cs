using JHobby.Repository.Interfaces;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Implements
{
	public class IndexService : IIndexService
	{
		private IIndexRepository _IidexResporitory;

		public IndexService(IIndexRepository IidexResporitory)
		{
			_IidexResporitory = IidexResporitory;
		}

		public IEnumerable<QueryMemberGenderModel> GetGenderResult()
		{
			var Resporitory=_IidexResporitory.GetGenderAll();
			var _total = Resporitory.Count();
			var _man = Resporitory.Where(res => res.Gender == "1" && res.Status != "99").Count();
			var _woman = Resporitory.Where(res => res.Gender == "0" && res.Status != "99").Count();
			var resultModel = new QueryMemberGenderModel();
			resultModel.Totle = _total;
			resultModel.Man =_man;
			resultModel.Woman=_woman;
			yield return resultModel;
		}
	}
}
