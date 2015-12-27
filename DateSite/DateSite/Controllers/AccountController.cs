using DateSite.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DateSite.Controllers
{
    public class AccountController : Controller
    {

        public UsersRepository _usersRepository = new UsersRepository();

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {;

            if (!ModelState.IsValid)
            {
                return View();
            }

            var completed = true;

            if (!completed)
            {
                ModelState.AddModelError("", "Fel fan");
                return View();
            }

            Profiles profile = new Profiles();
            profile.About = model.About;
            profile.Age = Int32.Parse(model.Age);
            profile.Email = model.Email;
            profile.Gender = model.Gender;
            profile.Lastname = model.Lastname;
            profile.Firstname = model.Firstname;

            SECURITY security = new SECURITY();
            security.USERNAME = model.Username;
            security.PASSWORD = model.Password;
            security.VISIBILITY = true;
            security.PID = 5;

            _usersRepository.insertUser(profile, security);

            return RedirectToAction("Index", "Home");
        }
    }
}