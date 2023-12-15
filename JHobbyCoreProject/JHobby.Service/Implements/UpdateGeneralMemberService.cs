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
    public class UpdateGeneralMemberService:IUpdateGeneralMemberService
    {
        private readonly IUpdateGeneralMemberRepository _iUpdateGeneralMemberRepository;
        public UpdateGeneralMemberService(IUpdateGeneralMemberRepository iUpdateGeneralMemberRepository)
        {
            _iUpdateGeneralMemberRepository= iUpdateGeneralMemberRepository;
        }

        public bool Update(int id, UpdateGeneralMemberModel updateGeneralMemberModel)
        {
            var mapper = new UpdateGeneralMemberDto
            {
                HeadShot = updateGeneralMemberModel.HeadShot,
                NickName = updateGeneralMemberModel.NickName,
                ActiveCity = updateGeneralMemberModel.ActiveCity,
                ActiveArea = updateGeneralMemberModel.ActiveArea,
                Address = updateGeneralMemberModel.Address,
                PersonalProfile = updateGeneralMemberModel.PersonalProfile,
            };
            return _iUpdateGeneralMemberRepository.Update(id, mapper);
        }
    }
}
