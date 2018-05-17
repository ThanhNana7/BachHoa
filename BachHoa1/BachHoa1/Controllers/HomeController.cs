using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BachHoa1.Models;

namespace BachHoa1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(Admin u)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (dbBachHoa dc = new dbBachHoa())
        //        {
        //            var v = dc.Admins.Where(a => a.IDName.Equals(u.IDName) && a.Pass.Equals(u.Pass)).FirstOrDefault();
        //            if (v != null)
        //            {
        //                Session["LogedID"] = v.ID.ToString();
        //                Session["LogedFullName"] = v.FullName.ToString();
        //                return RedirectToAction("AfterLogin");
        //            }
        //        }
        //    }
        //    return View(u);
        //}
        //public ActionResult AfterLogin()
        //{
        //    if (Session["LogedID"] != null)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index");
        //    }
        //}
    }
}