using HTQLCCCD.Models.SystemHP;
using HTQLCCCD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;

namespace HTQLCCCD.Areas.Citizen.Controllers
{
    public class RequiredController : Controller
    {
        // GET: Citizen/Required
        public ActionResult Index()
        {
            if (Session["Id_user"] != null)
            {
                return View();
            }
            return Redirect("~/Home/Login");
        }

        //chỉnh sửa thông tin cá nhân
        public ActionResult EditProfile()
        {
            if (Session["Id_user"] != null)
            {
                citizen c = new mapCitizen().GetCitizenById((int)Session["Id_user"]);
                return View(c);
            }
            return Redirect("~/Home/Login");
        }

        [HttpPost]
        public ActionResult EditProfile(citizen c)
        {
            if(c.Name == null || c.Place_of_residence == null || c.Place_of_origin == null || c.job ==  null)
            {
                ModelState.AddModelError("", "Thông tin bị thiếu hoặc chưa chính xác");
                return View(c);
            }    

            requirement r = new requirement()
            {
                Id_sender = c.Id,
                Type = 2,
                Date_send = DateTime.Now,
                Purport = c.Name + " @ " + c.Sex.ToString() + " @ " + c.Date_of_birth.Value.Day.ToString() + "/"+ c.Date_of_birth.Value.Month.ToString()+"/" +c.Date_of_birth.Value.Year.ToString() + " @ " + c.Place_of_origin + " @ " + c.Place_of_residence + " @ " + c.job + " @ " + c.Married.ToString(),
                Solved = false,
            };

            new mapRequired().AddRequired(r);
            return RedirectToAction("Index");

        }

        //khiếu nại lần đầu tại cấp tỉnh
        public ActionResult Complain()
        {
            if (Session["Id_user"] != null)
            {
                return View();
            }
            return Redirect("~/Home/Login");
        }

        //Xác nhận tình trạng hôn nhân
        public ActionResult Married()
        {
            if (Session["Id_user"] != null)
            {
                return View();
            }
            return Redirect("~/Home/Login");
        }

        //Xác nhận nơi cư trú
        public ActionResult Location()
        {
            if (Session["Id_user"] != null)
            {
                return View();
            }
            return Redirect("~/Home/Login");
        }

    }
}