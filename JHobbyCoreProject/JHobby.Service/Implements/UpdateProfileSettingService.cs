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

namespace JHobby.Service.Implements
{
    public class UpdateProfileSettingService : IUpdateProfileSettingService
    {
        private readonly IUpdateProfileSettingRepository _iUpdateProfileSettingRepository;

        public UpdateProfileSettingService(IUpdateProfileSettingRepository iUpdateProfileSettingRepository)
        {
            _iUpdateProfileSettingRepository = iUpdateProfileSettingRepository;
        }
        public bool Update(int id, UpdateProfileSettingModel updateProfileSettingModel)
        {
            var mapper = new UpdateProfileSettingDto
            {
                UpdatedHeadShot = updateProfileSettingModel.UpdatedHeadShot,
                UpdatedNickName = updateProfileSettingModel.UpdatedNickName,
                UpdatedAcitveCity = updateProfileSettingModel.UpdatedAcitveCity,
                UpdatedActiveArea = updateProfileSettingModel.UpdatedActiveArea,
                UpdatedAddress = updateProfileSettingModel.UpdatedAddress,
                UpdatedPhone = updateProfileSettingModel.UpdatedPhone,
                UpdatedPersonalProfile = updateProfileSettingModel.UpdatedPersonalProfile,
            };

            return  _iUpdateProfileSettingRepository.Update(id, mapper);
        }
    }
}
