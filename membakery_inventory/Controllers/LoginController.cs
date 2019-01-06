using membakery_inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace membakery_inventory.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(membakery_inventory.Models.Employee login)
        {
            using (Database1Entities1 db = new Database1Entities1())
            {
                var userDetail = db.Employees.Where(x => x.email == login.email && x.password == login.password).FirstOrDefault();
                if (userDetail == null)
                {
                    login.LoginErrorMessage = "Wrong username or password.";
                    return View("Index", login);
                }
                else
                {
                    Session["userID"] = userDetail.Emp_ID;
                    return RedirectToAction("Index", "Home");
                }

            }
        }
    }
}