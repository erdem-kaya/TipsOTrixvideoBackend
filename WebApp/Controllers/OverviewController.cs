﻿using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class OverviewController : Controller
{
    [Route("/admin/overview")]
    public IActionResult Index()
    {
        return View();
    }
}
