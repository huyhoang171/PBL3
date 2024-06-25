using HTQLCCCD.Models.SystemHP;
using HTQLCCCD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTQLCCCD.Areas.Admin.Controllers
{
    public class AuthoritiesController : Controller
    {
        // GET: Admin/Authorities
        public ActionResult Index()
        {
            if (Session["Id_admin"] != null)
            {
                List<authority> lc = new mapAuthorities().GetAll();
                return View(lc);

            }
            return Redirect("~/Home/Login");
        }

        public ActionResult Search(string s)
        {
            if (Session["Id_admin"] != null)
            {
                List<authority> lc = new mapAuthorities().Search(s);
                return View(lc);
            }
            return Redirect("~/Home/Login");
        }

        public ActionResult Create()
        {
            if (Session["Id_admin"] != null)
            {
                authority c = new authority();
                return View(c);
            }
            return Redirect("~/Home/Login");
        }

        [HttpPost]
        public ActionResult Create(authority a)
        {
            if ( a.Name == null || a.Place_of_residence == null || a.Place_of_origin == null || a.Date_of_birth == null )
            {
                ModelState.AddModelError("", "Chưa nhập đầy đủ thông tin cần thiết");
                return View(a);
            }

            new mapAuthorities().Add(a);
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            authority c = new mapAuthorities().GetById(id);
            return View(c);
        }

        [HttpPost]
        public ActionResult Edit(authority a)
        {
            if (a.Name == null || a.Place_of_residence == null || a.Place_of_origin == null || a.Date_of_birth == null)
            {
                ModelState.AddModelError("", "Chưa nhập đầy đủ thông tin cần thiết");
                return View(a);
            }
            new mapAuthorities().Update(a);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            new mapAuthorities().Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Account(int id)
        {
            account a = new mapAccount().GetByIdAuthor(id);
            ViewBag.Id = id;
            return View(a);
        }

        public ActionResult CreateAC(int id)
        {
            account a = new account();
            ViewBag.Id = id;
            return View(a);

        }

        [HttpPost]
        public ActionResult CreateAC(account a)
        {
            a.Role = "CQ";
            new mapAccount().Add(a);
            return RedirectToAction("Account", new { id = a.Id_author });
        }

        public ActionResult EditAC(int id)
        {
            account a = new mapAccount().GetAccountt(id);
            ViewBag.Id = a.Id_author;
            return View(a);
        }

        [HttpPost]
        public ActionResult EditAC(account a)
        {
            new mapAccount().Update(a);
            return RedirectToAction("Account", new { id = a.Id_author });
        }

    }
}