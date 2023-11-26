using JHobby.Service.Models;
using JHobby.Service.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Interfaces
{
	public interface IActivityService
	{
		public bool CreateActivityBuild(ActivityBuildModel activityBuildModel);

		/// <summary>
		/// 活動頁面查詢
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ActivityPageModel GetActivityPageSearch(int id);
	}
}