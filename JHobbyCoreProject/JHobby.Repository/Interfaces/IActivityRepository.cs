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
        /// <summary>
        /// 團主建立
        /// </summary>
        /// <param name="activityCreateDto"></param>
        /// <returns></returns>
		public bool ActivityBuild(ActivityCreateDto activityCreateDto);

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

        /// <summary>
        /// 會員留言板新增
        /// </summary>
        /// <param name="memberInsertMsgDto"></param>
        /// <returns></returns>
        public bool InsertMsg(MemberInsertMsgDto memberInsertMsgDto);

        /// <summary>
        /// 查詢會員活動申請者是否已參團或本身是開團者
        /// </summary>
        /// <returns></returns>
        public bool GetStatusById(int _memberId, int _activityId);

        /// <summary>
        /// 活動申請
        /// </summary>
        /// <returns></returns>
        public bool InsertActivityUser(ActivityUserInsertDto activityUserInsert);
    }
}