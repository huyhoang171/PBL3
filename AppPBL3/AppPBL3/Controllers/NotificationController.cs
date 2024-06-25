using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppPBL3.Models;

namespace AppPBL3.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        public ActionResult Index()
        {
            HeThongQLCCCDEntities1 db = new HeThongQLCCCDEntities1();
            List<notification> ln = new List<notification>();
            List<sending> ls = db.sendings.ToList().FindAll(m => m.Id_receiver == 1);
            foreach (sending s in ls)
            {
                ln.Add(db.notifications.ToList().Find(m => m.Id == s.Id));
            }
            return View(ln);
        }
    }
}