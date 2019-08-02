using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IApplicationService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        private IAccountApplication _accountApplication;

        public AccountController(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Register(string accountName, string password, string phoneNumber)
        {
            var result = await _accountApplication.CreatedAccount(1, accountName, password, phoneNumber);
            if (result.Success) return RedirectToAction("Index", "Home");
            return RedirectToAction("Index", "Error");
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public IActionResult Login(string userName, string userPwd, bool rmemberPwd = false)
        {
            return View();
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