using JHobby.Repository.Models.Dto;
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
        /// <summary>
        /// 團主建立
        /// </summary>
        /// <param name="activityCreateModel"></param>
        /// <returns></returns>
        public bool ActivityCreate(ActivityCreateModel activityCreateModel);

        /// <summary>
        /// 團主編輯
        /// </summary>
        /// <param name="activityUpdateModel"></param>
        /// <returns></returns>
        public bool ActivityUpdate(int id, ActivityUpdateModel activityUpdateModel);

        /// <summary>
        /// 取得開團資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActivityStatusModel GetActivityStatus(int id);

        /// <summary>
        /// 活動頁面查詢
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActivityPageModel GetActivityPageSearch(int id);

		/// <summary>
		/// 會員留言板查詢
		/// </summary>
		/// <returns></returns>
		public IEnumerable<MemberMsgModel> GetMemberMsg(int id);

        /// <summary>
        /// 會員留言板新增
        /// </summary>
        /// <param name="memberMsgModel"></param>
        /// <returns></returns>
        public bool CreateMsg(MemberInsertMsgModel memberInsertMsgDto);

        /// <summary>
        /// 回傳false代表活動頁面按鈕可以按
        /// </summary>
        /// <returns></returns>
        public JoinBtnCheckModel GetMemberStatus(int memberId, int activityId);

        /// <summary>
        /// 活動申請
        /// </summary>
        /// <returns></returns>
        public bool CreateActivityUser(ActivityUserInsertModel activityUserInsertModel);
    }
}