using AppPBL3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppPBL3.Controllers
{
    public class MainCDController : Controller
    {
        // GET: MainCD
        public ActionResult Index()
        {
            return View();
        }

        // Thông tin cá nhân
        public ActionResult Account()
        {
            HeThongQLCCCDEntities1 q = new HeThongQLCCCDEntities1();
            List<citizen> c = q.citizens.ToList();
            return View(c[0]);
        }

        public ActionResult ChinhPhu()
        {
            return View();
        }

        public ActionResult ChinhPhuDuongNhiem()
        {
            return View();
        }
    }
}