using JHobby.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Interfaces
{
    public interface IIndexService
	{
		public IEnumerable<QueryMemberGenderModel> GetGenderResult();

		public IEnumerable<QueryActivityModel> GetActivityResult();
	}
}
