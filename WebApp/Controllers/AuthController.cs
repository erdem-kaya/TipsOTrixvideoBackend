using Business.Services;
using Domain.Extensions;
using Domain.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class AuthController(IAuthService authService) : Controller
{
    private readonly IAuthService _authService = authService;


    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpViewModel model)
    {
        ViewBag.ErrorMessage = null;

        if (!ModelState.IsValid)
            return View(model);

        var singUpFormData = model.MapTo<SignUpFormData>();
        var result = await _authService.SignUpAsync(singUpFormData);
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }

        ViewBag.ErrorMessage = result.Error;
        return View(model);
    }


    public IActionResult SignIn(string returnUrl = "~/")
    {
        ViewBag.ReturnUrl = returnUrl;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInViewModel model, string returnUrl = "~/")
    {
        ViewBag.ErrorMessage = null;
        ViewBag.ReturnUrl = returnUrl;


        if (!ModelState.IsValid)
            return View(model);
        var signInFormData = model.MapTo<SignInFormData>();
        var result = await _authService.SignInAsync(signInFormData);
        if (result.Succeeded)
        {
            return LocalRedirect(returnUrl);
        }
        ViewBag.ErrorMessage = result.Error;
        return View(model);
    }
}
