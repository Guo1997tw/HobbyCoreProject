using JHobby.Repository.Interfaces;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;

namespace JHobby.Repository.Implements
{
    //繼承介面
    public class ProfileSettingService : IProfileSettingService
    {
        //int _a;  將介面定義一個全域變數接口
        private readonly IProfileSettingRepository _iProfileSettingRepository;
        private readonly ICommonService _iCommonService;

        public ProfileSettingService(IProfileSettingRepository iProfileSettingRepository, ICommonService iCommonService)//public int abc(int b)
        {
            _iProfileSettingRepository = iProfileSettingRepository;
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
                Status = result.Status,
                MemberId = result.MemberId,
                MemberName = result.MemberName,
                NickName = result.NickName,
                Gender = result.Gender,
                IdentityCard = result.IdentityCard,
                Birthday = (result.Birthday != null) ? result.Birthday.Value.ToString("yyyy-MM-dd") : null,
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
