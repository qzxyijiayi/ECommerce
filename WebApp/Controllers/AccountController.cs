using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IApplicationService;
using Infrastructur.InputDto.Account;
using Infrastructur.OutDto.Account;
using IQueryService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        private IAccountApplication _accountApplication;

        private IAccountQueryService _accountQueryService;

        private IGetId _getId;

        public AccountController(IAccountApplication accountApplication, IAccountQueryService accountQueryService, IGetId getId)
        {
            _accountApplication = accountApplication;
            _accountQueryService = accountQueryService;
            _getId = getId;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Register(RegisterInputDto registerInputDto)
        {
            var id = _getId.GetId(EntityType.Account);
            var result = await _accountApplication.CreatedAccount(id, registerInputDto.AccountName, registerInputDto.Password, registerInputDto.PhoneNumber);
            if (result.Success) return RedirectToAction("Index", "Home");
            return RedirectToAction("Index", "Error");
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Login(LoginInputDto loginInputDto)
        {
            var result = await _accountQueryService.Login(loginInputDto.AccountName, loginInputDto.AccountName);
            if (result.LoginType == LoginType.NotLoggedSuccessfully)
            {
                return Json(result);
            }
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