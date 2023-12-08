using JHobby.Website.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JHobby.Website.Controllers
{
    public class ProfileSettingController : Controller
    {
        public IActionResult ProfileSetting()
        {
            return View();
        }

        /// <summary>
        /// 修改密碼
        /// </summary>
        /// <returns></returns>
        public IActionResult ChangePwd()
        {
            return View();
        }
    }
}