﻿using Microsoft.AspNetCore.Mvc;

namespace CoreEmptyMvc.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
