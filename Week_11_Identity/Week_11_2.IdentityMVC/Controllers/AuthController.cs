﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Week_11_2.Domain.Identity;
using Week_11_2.IdentityMVC.ViewModels;

namespace Week_11_2.IdentityMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IToastNotification _toastNotificaation;
        private readonly IToastNotification _toastNotification;
        private readonly SignInManager<User> _signInManager;

        public AuthController(IToastNotification toastNotificaation)
        {

            _toastNotificaation = toastNotificaation;
        }

        public AuthController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            var registerViewModel = new AuthRegisterViewModel();

            return View(registerViewModel);

        }

        [HttpGet]
        public async Task<IActionResult> RegisterAsync(AuthRegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
                return View(registerViewModel);

            var userId = Guid.NewGuid();

            var user = new User()
            {
                Id = userId,
                Email = registerViewModel.Email,
                FirstName = registerViewModel.FirstName,
                SurName = registerViewModel.SurName,
                Gender = registerViewModel.Gender,
                BirthDate = registerViewModel.BirthDate.Value.ToUniversalTime(),
                UserName = registerViewModel.UserName,
                CreatedOn = DateTimeOffset.UtcNow,
                CreatedByUserId = userId.ToString()
            };

            var identityResult = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return View(registerViewModel);

            }
            _toastNotification.AddSuccessToastMessage("You've successfully registered to the application.");

            return RedirectToAction(nameof(Login));

        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var loginViewModel = new AuthLoginViewModel();

            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(AuthLoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);

            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if (user is null)
            {
                _toastNotification.AddErrorToastMessage("Your email or password is incorrect.");

                return View(loginViewModel);
            }

            var loginResult = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, true, false);

            if (!loginResult.Succeeded)
            {
                _toastNotification.AddErrorToastMessage("Your email or password is incorrect.");

                return View(loginViewModel);
            }

            _toastNotification.AddSuccessToastMessage($"Welcome {user.UserName}!");

            return RedirectToAction("Index", controllerName: "Students");
        }
    }
}
