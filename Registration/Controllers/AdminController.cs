using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Registration.DAL;
using Registration.Models;

namespace Registration.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            var db = new UserContext();
            List<User> userList =
                db.Users.Where(l => !string.IsNullOrEmpty(l.OrganisationName)).OrderBy(l => l.OrganisationName).ToList();
            return View(userList);
        }
    }
}