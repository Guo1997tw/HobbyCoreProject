using JHobby.Repository.Implements;
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
	public class WishSerive : IWishService
	{
		private readonly IWishRepository _WishRespository;

		public WishSerive(IWishRepository WhisResporitory)
		{
			_WishRespository = WhisResporitory;
		}

		public IEnumerable<QueryWishModel> GetWishByIdResult(int id)
		{
			var resporitory = _WishRespository.GetWishById(id);
			var resultModel = resporitory.Select(res => new QueryWishModel
										{
											ActivityId = res.ActivityId,
										});
			return resultModel;
		}

		public bool DeleteWish(int memberId, int activityId)
		{
			var queryResult = _WishRespository.GetWishById(memberId);

			if (queryResult == null) return false;

			_WishRespository.Delete(memberId, activityId);

			return true;
		}
	}
}
