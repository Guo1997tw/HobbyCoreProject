using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers.Api
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProfileSettingApiController : ControllerBase
    {
        private readonly IProfileSettingService _iProfileSettingService;
        private readonly IUpdateProfileSettingService _iUpdateProfileSettingService;


        string _Path;

        public ProfileSettingApiController(IProfileSettingService iProfileSettingService,
                                           IUpdateProfileSettingService iUpdateProfileSettingService,
                                           IWebHostEnvironment hostEnvironment)
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
                Account = serviceModel.Account,
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

        ////[HttpPut("{id}")]
        //public ActionResult<UpdateProfileSettingViewModel> UpdateProfileSettingA(int id, UpdateProfileSettingViewModel updateProfileSettingViewModel)
        //{
        //    var mapper = new UpdateProfileSettingModel
        //    {
        //        HeadShot = updateProfileSettingViewModel.HeadShot,
        //        Status = updateProfileSettingViewModel.Status,
        //        MemberName = updateProfileSettingViewModel.MemberName,
        //        NickName = updateProfileSettingViewModel.NickName,
        //        Gender = updateProfileSettingViewModel.Gender,
        //        IdentityCard = updateProfileSettingViewModel.IdentityCard,
        //        Birthday = updateProfileSettingViewModel.Birthday,
        //        ActiveCity = updateProfileSettingViewModel.ActiveCity,
        //        ActiveArea = updateProfileSettingViewModel.ActiveArea,
        //        Address = updateProfileSettingViewModel.Address,
        //        Phone = updateProfileSettingViewModel.Phone,
        //        PersonalProfile = updateProfileSettingViewModel.PersonalProfile,
        //    };
        //    return Ok(_iUpdateProfileSettingService.Update(id, mapper));
        //}

        FileInfo[] GetFiles()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(_Path);
            FileInfo[] files = directoryInfo.GetFiles();
            return files;
        }

        [HttpPut("{id}")] //服務讓定義的方法成立
        public bool UpdateProfileSetting(int id, [FromForm] UpdateProfileSettingViewModel updateProfileSettingViewModel)
        {

            var mapper = new UpdateProfileSettingModel();
            string fileNamePath = $"/profile/HeadShot{id}.jpg";
            mapper.HeadShot = fileNamePath;
            mapper.Status = updateProfileSettingViewModel.Status;
            mapper.MemberName = updateProfileSettingViewModel.MemberName;
            mapper.NickName = updateProfileSettingViewModel.NickName;
            mapper.Gender = updateProfileSettingViewModel.Gender;
            mapper.IdentityCard = updateProfileSettingViewModel.IdentityCard;
            mapper.Birthday = updateProfileSettingViewModel.Birthday;
            mapper.ActiveCity = updateProfileSettingViewModel.ActiveCity;
            mapper.ActiveArea = updateProfileSettingViewModel.ActiveArea;
            mapper.Address = updateProfileSettingViewModel.Address;
            mapper.Phone = updateProfileSettingViewModel.Phone;
            mapper.PersonalProfile = updateProfileSettingViewModel.PersonalProfile;
 
            _iUpdateProfileSettingService.Update(id, mapper);

            if (updateProfileSettingViewModel.File != null)
            {
                if (updateProfileSettingViewModel.File.Length > 0)
                {
                    string fileName = $"HeadShot{id}.jpg";
                    string SavePath = $@"{_Path}{fileName}";
                    using (var steam = new FileStream(SavePath, FileMode.Create))
                    {
                        updateProfileSettingViewModel.File.CopyTo(steam);
                    }
                }
            }
            return true;
        }

    }
}