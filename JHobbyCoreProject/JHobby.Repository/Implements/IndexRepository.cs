using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Implements
{
	public class IndexRepository : IIndexRepository
	{
		private JhobbyContext _JhobbyContext;
		public IndexRepository(JhobbyContext jhobbyContext)
		{
			_JhobbyContext = jhobbyContext;
		}
		public IEnumerable<QueryMemberGenderDto> GetGenderAll()
		{
			var dtoResult = _JhobbyContext.Members.Select(m => new QueryMemberGenderDto {
				MemberId=m.MemberId,
				Gender=m.Gender,
				Status=m.Status,
			});

			return dtoResult;
		}
	}
}
