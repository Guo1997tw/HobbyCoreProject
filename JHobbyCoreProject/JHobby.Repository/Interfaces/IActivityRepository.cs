using JHobby.Repository.Models.Dto;

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
        /// 團主修改
        /// </summary>
        /// <param name="activityUpdateDto"></param>
        /// <returns></returns>
        public bool ActivityUpdate(int id, ActivityUpdateDto activityUpdateDto);

        /// <summary>
        /// 取得開團資料
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ActivityStatusDto"></param>
        /// <returns></returns>
        public ActivityStatusDto ActivityStatus(int id);

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
        /// 回傳false代表活動頁面按鈕可以按
        /// </summary>
        /// <returns></returns>
        public JoinBtnCheckDto GetStatusById(int memberId, int activityId);

        /// <summary>
        /// 活動申請
        /// </summary>
        /// <returns></returns>
        public bool InsertActivityUser(ActivityUserInsertDto activityUserInsert);
    }
}