﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.AdminPanel.Controllers
{
    public class DashboardController : Controller
    {
        [Area("Adminpanel")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
