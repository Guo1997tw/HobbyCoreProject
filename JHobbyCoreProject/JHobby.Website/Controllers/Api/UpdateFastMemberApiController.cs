using JHobby.Service.Implements;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers.Api
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UpdateFastMemberApiController : ControllerBase
    {
        private readonly IUpdateFastMemberService _iUpdateFastMemberService;
        string _Path;

        public UpdateFastMemberApiController(IUpdateFastMemberService iUpdateFastMemberService,
                                             IWebHostEnvironment hostEnvironment)
        {
            _iUpdateFastMemberService = iUpdateFastMemberService;
            _Path = $@"{hostEnvironment.WebRootPath}\profile\";
        }

        FileInfo[] GetFiles()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(_Path);
            FileInfo[] files = directoryInfo.GetFiles();
            return files;
        }

        [HttpPut("{id}")]
        public bool UpdateFastMember(int id, [FromForm] UpdateFastMemberViewModel updateFastMemberViewModel)
        {
            string fileNamePath = $"/profile/HeadShot{id}.jpg";
            var mapper = new UpdateFastMemberModel()
            {

                HeadShot = fileNamePath,
                MemberName = updateFastMemberViewModel.MemberName,
                NickName = updateFastMemberViewModel.NickName,
                Gender = updateFastMemberViewModel.Gender,
                IdentityCard = updateFastMemberViewModel.IdentityCard,
                Birthday = updateFastMemberViewModel.Birthday,
                ActiveCity = updateFastMemberViewModel.ActiveCity,
                ActiveArea = updateFastMemberViewModel.ActiveArea,
                Address = updateFastMemberViewModel.Address,
                Phone = updateFastMemberViewModel.Phone,
                PersonalProfile = updateFastMemberViewModel.PersonalProfile
            };
            _iUpdateFastMemberService.Update(id, mapper);

            if (updateFastMemberViewModel.File != null)
            {
                if (updateFastMemberViewModel.File.Length > 0)
                {
                    string fileName = $"HeadShot{id}.jpg";
                    string SavePath = $@"{_Path}{fileName}";
                    using (var steam = new FileStream(SavePath, FileMode.Create))
                    {
                        updateFastMemberViewModel.File.CopyTo(steam);
                    }
                }
            }

            return true;
        }
    }
}
