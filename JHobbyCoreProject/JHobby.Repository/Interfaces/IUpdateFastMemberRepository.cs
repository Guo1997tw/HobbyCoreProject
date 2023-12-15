using JHobby.Repository.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHobby.Repository.Interfaces
{
    public interface IUpdateFastMemberRepository
    {
        public bool Update(int id, UpdateFastMemberDto updateFastMemberDto);
    }
}
