using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IApplicationService;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        public LoginController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        private IUserApplication _userApplication { get; set; }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(LoginDto loginDto)
        {
            return View();
        }

        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await _userApplication.CreatedUser(1, registerDto.UserName, registerDto.UserPwd, "12345678910");
            return Json(result);
        }

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <returns></returns>
        public IActionResult ForgetPassword()
        {
            return View();
        }
    }
}