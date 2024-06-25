using HTQLCCCD.Models;
using HTQLCCCD.Models.SystemHP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTQLCCCD.Areas.Citizen.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Citizen/Appointment
        public ActionResult Index()
        {
            if (Session["Id_user"] != null)
            {
                List<appointment_schedule> la = new mapAppointment().GetAllById((int)Session["Id_user"]);
                ViewBag.Upcoming = new mapAppointment().GetUpcoming((int)Session["Id_user"]);
                return View(la);
            }
            return Redirect("~/Home/Login");
        }

        public ActionResult Delete(int id)
        {
            new mapAppointment().DeleteById(id);
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            if (Session["Id_user"] != null)
            {
                appointment_schedule a = new appointment_schedule();
                return View(a);
            }

            return Redirect("~/Home/Login");
        }

        [HttpPost]
        public ActionResult Add(appointment_schedule a)
        {
            if(a.Time_start != null && a.Purport != null)
            {
                a.Id_sender = (int)Session["Id_user"];
                a.Date_send = DateTime.Now;
                a.Solved = false;
                if(new mapAppointment().Add(a))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thông tin ngày hẹn bị trùng hoặc không hợp lệ");
                    return View(a);
                }
            }    
            else
            {
                ModelState.AddModelError("", "Thông tin chưa chính xác");
                return View(a);
            }    
            
        }
    }
}