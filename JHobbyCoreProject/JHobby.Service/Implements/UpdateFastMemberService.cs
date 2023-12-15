using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Service.Implements
{
    public class UpdateFastMemberService:IUpdateFastMemberService
    {
        private readonly IUpdateFastMemberRepository _iUpdateFastMemberRepository;
        public UpdateFastMemberService(IUpdateFastMemberRepository iUpdateFastMemberRepository)
        {
            _iUpdateFastMemberRepository= iUpdateFastMemberRepository;
        }

        public bool Update(int id, UpdateFastMemberModel updateFastMemberModel)
        {
            var mapper = new UpdateFastMemberDto
            {
                HeadShot = updateFastMemberModel.HeadShot,
                MemberName = updateFastMemberModel.MemberName,
                NickName = updateFastMemberModel.NickName,
                Gender = updateFastMemberModel.Gender,
                IdentityCard = updateFastMemberModel.IdentityCard,
                Birthday = updateFastMemberModel.Birthday,
                Status = "1",
                ActiveCity = updateFastMemberModel.ActiveCity,
                ActiveArea = updateFastMemberModel.ActiveArea,
                Address = updateFastMemberModel.Address,
                Phone = updateFastMemberModel.Phone,
                PersonalProfile = updateFastMemberModel.PersonalProfile,
            };
            //目的地.方法像船需要同個國家的船(承接乘客)乘客要轉變為同個國家，資料才能傳進去
            return _iUpdateFastMemberRepository.Update(id, mapper);
        }
    }
}
