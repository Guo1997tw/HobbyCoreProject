using JHobby.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Interfaces
{
	public interface IWishService
	{
		public IEnumerable<QueryWishModel> GetWishByIdResult(int id);

		public bool DeleteWish(int memberId, int activityId);
	}
}
