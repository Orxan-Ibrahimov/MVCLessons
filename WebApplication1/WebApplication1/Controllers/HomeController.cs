﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index(Info model)
        //{
        //    if (Request.Method == "POST")
        //    {
        //       //string email = Request.Form["email"];
        //       //string password = Request.Form["password"];

        //        //ViewBag.Email = model.Name;
        //        //ViewBag.Password = password;

        //        //ViewBag.Name = model.Name;
        //        //ViewBag.Surname = model.Surname;
        //        //ViewBag.Phone = model.Phone;

        //    }
        //    return View(model);
        //}
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Info model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            return View();
           
        }
    }
}
