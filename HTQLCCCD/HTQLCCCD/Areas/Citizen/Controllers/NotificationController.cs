using HTQLCCCD.Models;
using HTQLCCCD.Models.SystemHP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTQLCCCD.Areas.Citizen.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Citizen/Notification
        public ActionResult Index()
        {
            if (Session["Id_user"] != null)
            {
                List<mapNotification> la = new mapNotification().GetAllById((int)Session["Id_user"]);
                return View(la);
            }

            return Redirect("~/Home/Login");
        }
    }
}