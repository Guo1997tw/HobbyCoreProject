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
	public class ProfileSettingRepository : IProfileSettingRepository
	{
		private readonly JhobbyContext _jhobbyContext;

		public ProfileSettingRepository(JhobbyContext jhobbyContext)
		{
			_jhobbyContext = jhobbyContext;
		}

		public ProfileSettingDto GetById(int id)
		{
			var result = _jhobbyContext.Members.FirstOrDefault(m => m.MemberId == id);

			return new ProfileSettingDto
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
	}
}
	

