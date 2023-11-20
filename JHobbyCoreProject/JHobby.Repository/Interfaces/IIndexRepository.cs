using JHobby.Repository.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Interfaces
{
    public interface IIndexRepository
	{
		public IEnumerable<QueryMemberGenderDto> GetGenderAll();

		public IEnumerable<QueryActivityDto> GetActivityAll();

		public IEnumerable<QueryWishDto>GetWishById(int id);

		public IEnumerable<QueryHotMemberDto> GetHotMemberAll();

	}
}
