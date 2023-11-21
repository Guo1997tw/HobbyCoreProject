using JHobby.Repository.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Interfaces
{
	public interface IWishRepository
	{
		public IEnumerable< QueryWishDto> GetWishById(int id);
		public bool Delete(int memberId, int activityId);
	}
}
