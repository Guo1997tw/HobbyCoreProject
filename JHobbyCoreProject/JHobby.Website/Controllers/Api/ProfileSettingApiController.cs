﻿using JHobby.Repository.Interfaces;
using JHobby.Repository.Models.Dto;
using JHobby.Service.Implements;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;

namespace JHobby.Website.Controllers.Api
{
    [Route("api/ProfileSetting/[action]")]
    [ApiController]
    public class ProfileSettingApiController : ControllerBase
    {
        private readonly IProfileSettingService _iProfileSettingService;
        private readonly IUpdateProfileSettingService _iUpdateProfileSettingService;

        string _Path;

        public ProfileSettingApiController(IProfileSettingService iProfileSettingService, IUpdateProfileSettingService iUpdateProfileSettingService, IWebHostEnvironment hostEnvironment)
        {
            _iProfileSettingService = iProfileSettingService;
            _iUpdateProfileSettingService = iUpdateProfileSettingService;

            _Path = $@"{hostEnvironment.WebRootPath}\profile\";
        }

        [HttpGet("{id}")]
        public ActionResult<ProfileSettingViewModel> GetById(int id)
        {
            var serviceModel = _iProfileSettingService.GetById(id); //GetByIdService

            var viewModel = new ProfileSettingViewModel
            {
                HeadShot = serviceModel.HeadShot,
                Status = serviceModel.Status,
                MemberId = serviceModel.MemberId,
                MemberName = serviceModel.MemberName,
                NickName = serviceModel.NickName,
                Gender = serviceModel.Gender,
                IdentityCard = serviceModel.IdentityCard,
                Birthday = serviceModel.Birthday,
                ActiveCity = serviceModel.ActiveCity,
                ActiveArea = serviceModel.ActiveArea,
                Address = serviceModel.Address,
                Phone = serviceModel.Phone,
                PersonalProfile = serviceModel.PersonalProfile
            };
            return Ok(viewModel);
        }

        //[HttpPut("{id}")]
        //public ActionResult<UpdateProfileSettingViewModel> UpdateProfileSetting(int id, UpdateProfileSettingViewModel updateProfileSettingViewModel)
        //{
        //    var mapper = new UpdateProfileSettingModel
        //    {
        //        UpdatedHeadShot = updateProfileSettingViewModel.UpdatedHeadShot,
        //        UpdatedNickName = updateProfileSettingViewModel.UpdatedNickName,
        //        UpdatedAcitveCity = updateProfileSettingViewModel.UpdatedAcitveCity,
        //        UpdatedActiveArea = updateProfileSettingViewModel.UpdatedActiveArea,
        //        UpdatedAddress = updateProfileSettingViewModel.UpdatedAddress,
        //        UpdatedPhone = updateProfileSettingViewModel.UpdatedPhone,
        //        UpdatedPersonalProfile = updateProfileSettingViewModel.UpdatedPersonalProfile,
        //    };
        //    return Ok(_iUpdateProfileSettingService.Update(id, mapper));
        //}

        FileInfo[] GetFiles()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(_Path);
            FileInfo[] files = directoryInfo.GetFiles();
            return files;
        }

        [HttpPut("{id}")]
        public bool UpdateProfileSetting(int id, [FromForm] UpdateProfileSettingIFormFileViewModel updateProfileSettingIFormFileViewModel)
        {
            if (updateProfileSettingIFormFileViewModel.File != null)
            {
                if (updateProfileSettingIFormFileViewModel.File.Length > 0)
                {
                    string SavePath = $@"{_Path}{updateProfileSettingIFormFileViewModel.File.FileName}";

                    using (var steam = new FileStream(SavePath, FileMode.Create))
                    {
                        updateProfileSettingIFormFileViewModel.File.CopyToAsync(steam);
                    }
                }
            }

            return true;
        }
    }
}