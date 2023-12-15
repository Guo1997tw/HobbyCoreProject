using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace JHobby.Service.Implements
//{
//    public class UpdateProfileSettingService : /*IUpdateProfileSettingService*/
//    {
//        private readonly IUpdateProfileSettingRepository _iUpdateProfileSettingRepository;

//        public UpdateProfileSettingService(IUpdateProfileSettingRepository iUpdateProfileSettingRepository)
//        {
//            _iUpdateProfileSettingRepository = iUpdateProfileSettingRepository;
//        }
//        public bool Update(int id, UpdateProfileSettingModel updateProfileSettingModel)
//        {
//            var mapper = new UpdateProfileSettingDto
//            {
//                HeadShot = updateProfileSettingModel.HeadShot,
//                MemberName = updateProfileSettingModel.MemberName,
//                NickName = updateProfileSettingModel.NickName,
//                Gender = updateProfileSettingModel.Gender,
//                IdentityCard = updateProfileSettingModel.IdentityCard,
//                Birthday = updateProfileSettingModel.Birthday,
//                ActiveCity = updateProfileSettingModel.ActiveCity,
//                ActiveArea = updateProfileSettingModel.ActiveArea,
//                Address = updateProfileSettingModel.Address,
//                Phone = updateProfileSettingModel.Phone,
//                PersonalProfile = updateProfileSettingModel.PersonalProfile,
//            };
//            //目的地.方法像船需要同個國家的船(承接乘客)乘客要轉變為同個國家，資料才能傳進去
//            return  _iUpdateProfileSettingRepository.Update(id, mapper);
//        }
//    }
//}
