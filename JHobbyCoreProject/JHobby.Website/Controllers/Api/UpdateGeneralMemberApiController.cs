using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers.Api
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UpdateGeneralMemberApiController : ControllerBase
    {
        private readonly IUpdateGeneralMemberService _iUpdateGeneralMemberService;
        string _Path;

        public UpdateGeneralMemberApiController(IUpdateGeneralMemberService iUpdateGeneralMemberService,
                                                IWebHostEnvironment hostEnvironment)
        {
            _iUpdateGeneralMemberService = iUpdateGeneralMemberService;
            _Path = $@"{hostEnvironment.WebRootPath}\profile\";
        }
        FileInfo[] GetFiles()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(_Path);
            FileInfo[] files = directoryInfo.GetFiles();
            return files;
        }
        //服務讓定義的方法成立
        [HttpPut("{id}")]
        public bool UpdateGeneralMember(int id, [FromForm] UpdateGeneralMemberViewModel updateGeneralMemberViewModel)
        {
            var mapper = new UpdateGeneralMemberModel();
            string fileNamePath = $"/profile/HeadShot{id}.jpg";
            mapper.HeadShot = fileNamePath;
            mapper.NickName = updateGeneralMemberViewModel.NickName;
            mapper.ActiveCity = updateGeneralMemberViewModel.ActiveCity;
            mapper.ActiveArea = updateGeneralMemberViewModel.ActiveArea;
            mapper.Address = updateGeneralMemberViewModel.Address;
            mapper.PersonalProfile = updateGeneralMemberViewModel.PersonalProfile;

            _iUpdateGeneralMemberService.Update(id, mapper);

            if (updateGeneralMemberViewModel.File != null)
            {
                if (updateGeneralMemberViewModel.File.Length > 0)
                {
                    string fileName = $"HeadShot{id}.jpg";
                    string SavePath = $@"{_Path}{fileName}";
                    using (var steam = new FileStream(SavePath, FileMode.Create))
                    {
                        updateGeneralMemberViewModel.File.CopyTo(steam);
                    }
                }
            }

            return true;
        }
    }
}
