using AppPBL3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppPBL3.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        public ActionResult Index()
        {
            
            HeThongQLCCCDEntities1 db = new HeThongQLCCCDEntities1();
            List<appointment_schedule> la = db.appointment_schedule.ToList().FindAll(m => m.Id_sender == 1);
            la.Sort((x, y) => DateTime.Compare((DateTime)x.Date_send,(DateTime)y.Date_send));

            return View(la);
        }

        public ActionResult Add()
        {

            return RedirectToAction("Index");
        }
    }
}