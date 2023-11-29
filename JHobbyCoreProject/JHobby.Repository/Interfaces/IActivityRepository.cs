using JHobby.Repository.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Interfaces
{
	public interface IActivityRepository		
	{
		public bool InsertActivityBuild(ActivityBuildDto activityBuildDto);

		/// <summary>
		/// 活動頁面查詢
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ActivityPageDto GetActivityPageById(int id);

        /// <summary>
        /// 會員留言板查詢
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MemberMsgDto> GetMsgList(int id);
    }
}