using System.Web.Mvc;
using Repositories;
using DateSite.Functions;
using DateSite.Models;

namespace DateSite.Controllers
{
    public class BrowseProfilesController : Controller
    {
        private UsersRepository _usersRepository;
        public readLocalTextFile reader = new readLocalTextFile();

        public BrowseProfilesController()
        {
            _usersRepository = new UsersRepository();
        }

        // GET: BrowseProfiles
        public ActionResult Browse()
        {
            BrowseModel browseData = new BrowseModel();
            browseData.profiles = _usersRepository.fetchProfiles();
            browseData.countries = reader.getCountries();
            return View(browseData);
        }
    }
}