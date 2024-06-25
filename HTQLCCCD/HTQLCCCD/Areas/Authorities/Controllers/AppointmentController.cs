using HTQLCCCD.Models.SystemHP;
using HTQLCCCD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTQLCCCD.Areas.Authorities.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Authorities/Appointment
        public ActionResult Index()
        {
            if (Session["Id_author"] != null)
            {
                List<appointment_schedule> l = new mapAppointment().GetAll();
                ViewBag.Id = Session["Id_author"];
                ViewBag.Upcoming = new mapAppointment().GetUpcomingForAuthor((int)Session["Id_author"]);
                return View(l);
            }

            return Redirect("~/Home/Login");
        }

        public ActionResult Approve(int id)
        {
            new mapAppointment().Approve(id, (int)Session["Id_author"]);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            new mapAppointment().DeleteById(id);
            return RedirectToAction("Index");
        }

        public ActionResult Solve(int id)
        {
            new mapAppointment().ChangeSolve(id);
            return RedirectToAction("Index");
        }

    }
}