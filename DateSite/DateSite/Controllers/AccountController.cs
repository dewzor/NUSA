using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Register(string username, string password, string firstname, string lastname, string email, string gender, string age, string location, string about)
        {

            Profiles profile = new Profiles();
            profile.Username = username;
            profile.Pass = password;
            profile.Firstname = firstname;
            profile.Lastname = lastname;
            profile.Gender = gender;
            profile.Age = Int32.Parse(age);
            profile.Location = location;
            profile.About = about;
            profile.Email = email;
    

            _usersRepository.insertUser(profile);

            return RedirectToAction("Index", "Home");
        }
    }
}