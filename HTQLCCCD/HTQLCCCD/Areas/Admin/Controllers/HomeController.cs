using HTQLCCCD.Models;
using HTQLCCCD.Models.SystemHP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTQLCCCD.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["Id_admin"] != null)
            {
                admin a = new mapAdmin().GetById((int)Session["Id_admin"]);
                ViewBag.Totalcd = new mapCitizen().GetAll().Count;
                ViewBag.Totalau = new mapAuthorities().GetAll().Count;
                ViewBag.Totalac = new mapAccount().GetAll().Count;
                ViewBag.Ad = new mapAccount().GetByIdAd((int)Session["Id_admin"]);
                return View(a);
            }
            return Redirect("~/Home/Login");
        }

        public ActionResult Change(admin a, string tk, string mk)
        {
            account ac = new mapAccount().GetByIdAd(a.Id);
            ac.User_name = tk;
            ac.Password = mk;
            new mapAccount().Update(ac);
            new mapAdmin().Update(a);
            return RedirectToAction("Index");
        }

    }
}