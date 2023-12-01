using AutoMapper.Execution;
using AutoMapper;
using JHobby.Repository.Models.Dto;
using JHobby.Repository.Models.Entity;
using JHobby.Service.Implements;
using JHobby.Service.Interfaces;
using JHobby.Service.Models;
using JHobby.Service.Models.Dto;
using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers.Api
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ActivityApiController : ControllerBase
    {
        private readonly IActivityService _activityService;
        string _Path;

        public ActivityApiController(IActivityService activityService, IWebHostEnvironment webHostEnvironment)
        {
            _activityService = activityService;
            _Path = $@"{webHostEnvironment.WebRootPath}\profile\";
        }


        FileInfo[] GetFiles()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(_Path);
            FileInfo[] files = directoryInfo.GetFiles();
            return files;
        }

        //[HttpPost]
        //public IActionResult InsertActivity(ActivityBuildViewModel activityBuildViewModel)
        //{
        //    var mapper = new ActivityBuildModel
        //    {
        //        ActivityName = activityBuildViewModel.ActivityName,
        //        ActivityCity = activityBuildViewModel.ActivityCity,
        //        ActivityArea = activityBuildViewModel.ActivityArea,
        //        ActivityLocation = activityBuildViewModel.ActivityLocation,
        //        StartTime = activityBuildViewModel.StartTime,
        //        MaxPeople = activityBuildViewModel.MaxPeople,
        //        CategoryId = activityBuildViewModel.CategoryId,
        //        CategoryTypeId = activityBuildViewModel.CategoryTypeId,
        //        JoinDeadLine = activityBuildViewModel.JoinDeadLine,
        //        JoinFee = activityBuildViewModel.JoinFee,
        //        ActivityNotes = activityBuildViewModel.ActivityNotes,
        //        MemberId = activityBuildViewModel.MemberId,
        //        ActivityStatus = activityBuildViewModel.ActivityStatus,
        //        Payment = activityBuildViewModel.Payment,
        //        Created = activityBuildViewModel.Created

        //    };

        //    var result = _activityService.CreateActivityBuild(mapper);

        //    return Ok(result);
        //}




        [HttpPost]
        public bool InsertActivity(ActivityBuildViewModel activityBuildViewModel)
        {
            //        foreach (var activityBuildViewModel.File in activityBuildViewModel)
            //{
            if (activityBuildViewModel.File != null)
            {
                if (activityBuildViewModel.File.Length > 0)
                {
                    string SavePath = $@"{_Path}\{activityBuildViewModel.File.FileName}";
                    using (var steam = new FileStream(SavePath, FileMode.Create))
                    {
                        activityBuildViewModel.File.CopyToAsync(steam);
                        //ActivityCity = activityBuildViewModel.ActivityCity,
                        //ActivityArea = activityBuildViewModel.ActivityArea,
                        //ActivityLocation = activityBuildViewModel.ActivityLocation,
                        //StartTime = activityBuildViewModel.StartTime,
                        //MaxPeople = activityBuildViewModel.MaxPeople,
                        //CategoryId = activityBuildViewModel.CategoryId,
                        //CategoryTypeId = activityBuildViewModel.CategoryTypeId,
                        //JoinDeadLine = activityBuildViewModel.JoinDeadLine,
                        //JoinFee = activityBuildViewModel.JoinFee,
                        //ActivityNotes = activityBuildViewModel.ActivityNotes,
                        //MemberId = activityBuildViewModel.MemberId,
                        //ActivityStatus = activityBuildViewModel.ActivityStatus,
                        //Payment = activityBuildViewModel.Payment,
                        //Created = activityBuildViewModel.Created


                    }
                }
            }
        
            return true;
        }




}
}
