using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using System.Globalization;

namespace JHobby.Repository.Implements
{
	public class ProfileSettingService : IProfileSettingService //繼承介面
	{
		private readonly IProfileSettingRepository _iProfileSettingRepository; //int _a;  將介面定義一個變數接口
		private readonly ICommonService _iCommonService;

        public ProfileSettingService(IProfileSettingRepository iProfileSettingRepository, ICommonService iCommonService)//public int abc(int b)
		{
			_iProfileSettingRepository = iProfileSettingRepository; //_a = b;
			_iCommonService = iCommonService;

        }

		public ProfileSettingModel GetById(int id)
		{
			//.後面就是方法或屬性
			var result = _iProfileSettingRepository.GetById(id);

			return new ProfileSettingModel
			{
				HeadShot = result.HeadShot,
				Account = result.Account,
				Status = _iCommonService.ConvertStatus(result.Status),
				MemberId = result.MemberId,
				MemberName = result.MemberName,
				NickName = result.NickName,
				Gender =result.Gender,
				IdentityCard = result.IdentityCard,
				Birthday = result.Birthday.Value.ToString("yyyy-MM-dd"),
                ActiveCity = result.ActiveCity,
				ActiveArea = result.ActiveArea,
				Address = result.Address,
				Phone = result.Phone,
				PersonalProfile = result.PersonalProfile,

                // 其他需要的資料
            };
		}
	}
}
