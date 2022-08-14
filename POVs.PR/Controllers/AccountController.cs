using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using POVs.BL.Models;
using POVs.DAL.Extend;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace POVs.PR.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        #region Registeration
        public IActionResult Registeration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registeration(RegisterationVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser()
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        IsAgree = model.IsAgree
                    };
                    var result = await userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(model);
        }
        #endregion

        #region Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            var userName = await userManager.FindByNameAsync(model.UserName);
            var userEmail = await userManager.FindByEmailAsync(model.UserName);
            dynamic result;

            if (userName != null)
            {
                result = await signInManager.PasswordSignInAsync(userName, model.Password, model.RememberMe, false);
            }
            else
            {
                result = await signInManager.PasswordSignInAsync(userEmail, model.Password, model.RememberMe, false);
            }

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid UserName Or Password");
            }
            return View(model);
        }
        #endregion

        #region Logout
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        #endregion

        #region ForgetPassword
        public IActionResult ForgetPassword()
        {
            return View();
        }
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = model.Email, Token = token }, Request.Scheme);

                //MailSender.Mail("Password Reset", passwordResetLink);
                //logger.Log(LogLevel.Warning, passwordResetLink);
                EventLog log = new EventLog();
                log.Source = "Prove of Concepts";
                log.WriteEntry(passwordResetLink, EventLogEntryType.Information);
                return RedirectToAction("ConfirmForgetPassword");
            }
            return View(model);
        }
        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }
        #endregion

        #region ResetPassword
        public IActionResult ResetPassword(string Email = null, string Token = null)
        {
            if (Email != null && Token != null)
            {
                return View();
            }
            return RedirectToAction("ForgetPassword");
        }
        public IActionResult ConfirmResetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ConfirmResetPassword");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
        #endregion
    }
}
