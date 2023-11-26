using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;

namespace JHobby.Repository.Implements
{
	public class ProfileSettingService : IProfileSettingService //繼承介面
	{
		private readonly IProfileSettingRepository _iProfileSettingRepository; //int _a;  將介面定義一個變數接口

		public ProfileSettingService(IProfileSettingRepository iProfileSettingRepository)//public int abc(int b)
		{
			_iProfileSettingRepository = iProfileSettingRepository; //_a = b;
		}

		public ProfileSettingModel GetById(int id)
		{
			//.後面就是方法或屬性
			var result = _iProfileSettingRepository.GetById(id);

			return new ProfileSettingModel
			{
				HeadShot = result.HeadShot,
				Status = result.Status,
				MemberId = result.MemberId,
				MemberName = result.MemberName,
				NickName = result.NickName,
				Gender = result.Gender,
				IdentityCard = result.IdentityCard,
				Birthday = result.Birthday,
                ActiveCity = result.ActiveCity,
				ActiveArea = result.ActiveArea,
				Address = result.Address,
				Phone = result.Phone,
				PersonalProfile = result.PersonalProfile,

				// 其他需要的資料
			};
		}
		public bool Update(int id, ProfileSettingDto updateProfileSettingDto)
		{
			// 根据 id 获取现有的个人配置
			var result = _iProfileSettingRepository.GetById(id);

			if (result == null)
			{
				return false;
			}

			// 更新字符串类型的字段
			var dto = new ProfileSettingDto
			{
				HeadShot = updateProfileSettingDto.UpdatedHeadShot,
				NickName = updateProfileSettingDto.UpdatedNickName,
                ActiveCity = updateProfileSettingDto.UpdatedAcitveCity,
				ActiveArea = updateProfileSettingDto.UpdatedActiveArea,
				Address = updateProfileSettingDto.UpdatedAddress,
				Phone = updateProfileSettingDto.UpdatedPhone,
				PersonalProfile = updateProfileSettingDto.UpdatedPersonalProfile
			};

			// 其他类型的更新...

			_iProfileSettingRepository.Update(id, dto);

			return true;
		}
	}
}
