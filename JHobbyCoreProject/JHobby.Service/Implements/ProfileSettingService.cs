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
            public IEnumerable<ProfileSettingModel> GetByIdService(int id)
            {
            var queryResult = _iProfileSettingRepository.GetById(id) //.後面就是方法或屬性
                .Where(m => m.MemberId == id) //
                .Select(m => new ProfileSettingModel
                {
                        HeadShot = m.HeadShot,
                        Status = m.Status,
                        MemberId = m.MemberId,
                        MemberName = m.MemberName,
                        NickName = m.NickName,
                        Gender = m.Gender,
                        IdentityCard = m.IdentityCard,
                        Birthday = m.Birthday,
                        AcitveCity = m.AcitveCity,
                        ActiveArea = m.ActiveArea,
                        Address = m.Address,
                        Phone = m.Phone,
                        PersonalProfile = m.PersonalProfile,

                        // 其他需要的資料
                    });

                return queryResult;
            }
        }
}
