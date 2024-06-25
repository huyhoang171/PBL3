using HTQLCCCD.Models.SystemHP;
using HTQLCCCD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTQLCCCD.Areas.Authorities.Controllers
{
    public class ManagerCitizenController : Controller
    {
        // GET: Authorities/ManagerCitizen
        public ActionResult Index()
        {
            if (Session["Id_author"] != null)
            {
                List<citizen> lc = new mapCitizen().GetAll();
                return View(lc);
            }
            return Redirect("~/Home/Login");
        }

        public ActionResult Search(string s)
        {
            if (Session["Id_author"] != null)
            {
                List<citizen> lc = new mapCitizen().Search(s);
                return View(lc);
            }
            return Redirect("~/Home/Login");
        }

        public ActionResult Details(int id)
        {
            if (Session["Id_author"] != null)
            {
                citizen c = new mapCitizen().GetCitizenById(id);
                if (c.criminal_record.Count != 0)
                {
                    return RedirectToAction("Detailss", new { id = id });
                }
                return View(c);
            }
            return Redirect("~/Home/Login");
        }

        public ActionResult Detailss(int id)
        {
            citizen c = new mapCitizen().GetCitizenById(id);
            return View(c);
        }

        public ActionResult Create()
        {
            if (Session["Id_author"] != null)
            {
                citizen c = new citizen();
                return View(c);
            }
            return Redirect("~/Home/Login");
        }

        [HttpPost]
        public ActionResult Create(citizen c)
        {
            if (c.Number == null || c.Number == null || c.Place_of_residence == null || c.Place_of_origin == null || c.Date_of_birth == null || c.job == null)
            {
                ModelState.AddModelError("", "Chưa nhập đầy đủ thông tin cần thiết");
                return View(c);
            }

            if (new mapCitizen().Add(c) == false)
            {
                ModelState.AddModelError("", "Thông tin chưa chính xác");
                return View(c);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            citizen c = new mapCitizen().GetCitizenById(id);
            return View(c);
        }

        [HttpPost]
        public ActionResult Edit(citizen c)
        {
            if (!new mapCitizen().Update(c))
            {
                ModelState.AddModelError("", "Thông tin chưa chính xác");
                return View(c);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Crim(int id)
        {
            List<criminal_record> c = new mapCriminal().GetCriminalById(id);
            ViewBag.Name = new mapCitizen().GetCitizenById(id).Name;
            ViewBag.Id = new mapCitizen().GetCitizenById(id).Id;
            return View(c);
        }

        public ActionResult CreateCR(int id)
        {
            if (Session["Id_author"] != null)
            {
                criminal_record c = new criminal_record();
                ViewBag.Id = id;
                return View(c);
            }
            return Redirect("~/Home/Login");
        }

        [HttpPost]
        public ActionResult CreateCR(criminal_record c)
        {
            if(c.Crime == null)
            {
                ModelState.AddModelError("", "Chưa nhập đầy đủ thông tin");
                return View(c);
            }
            new mapCriminal().Add(c);
            return RedirectToAction("Crim", new {id = c.Id_citizen});
        }

        public ActionResult DeleteCR(int id)
        {
            int a = new mapCriminal().Delete(id);
            return RedirectToAction("Crim", new { id = a });
        }

        public ActionResult Delete(int id)
        {
            new mapCitizen().Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Account(int id)
        {
            account a = new mapAccount().GetAccountById(id);
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
            a.Role = "CD";
            new mapAccount().Add(a);
            return RedirectToAction("Account", new {id = a.Id_user});
        }

        public ActionResult EditAC(int id)
        {
            account a = new mapAccount().GetAccountt(id);
            ViewBag.Id = a.Id_user;
            return View(a);
        }

        [HttpPost]
        public ActionResult EditAC(account a)
        {
            new mapAccount().Update(a);
            return RedirectToAction("Account", new { id = a.Id_user });
        }

        public ActionResult Feedback()
        {
            if (Session["Id_author"] != null)
            {
                List<feedback> lf = new mapFeedback().GetAll();
                return View(lf);
            }

            return Redirect("~/Home/Login");
        }

        public ActionResult Deletefb(int id)
        {
            new mapFeedback().Delete(id);
            return RedirectToAction("Feedback");
        }

    }
}