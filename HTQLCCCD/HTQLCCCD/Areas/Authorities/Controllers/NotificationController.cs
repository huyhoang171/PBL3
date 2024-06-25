using HTQLCCCD.Models;
using HTQLCCCD.Models.SystemHP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTQLCCCD.Areas.Authorities.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Authorities/Notification
        public ActionResult Index()
        {
            if (Session["Id_author"] != null)
            {
                List<notification> l = new mapNotification().GetAll();
                return View(l);
            }

            return Redirect("~/Home/Login");
        }

        
        public ActionResult SendTo(int id)
        {
            List<sending> ls = new mapNotification().GetAllSending(id);
            ViewBag.id = id;
            return View(ls);
        }

        [HttpPost]
        public ActionResult SendTo(string s,int d)
        {
            citizen c = new mapCitizen().GetCitizenByNumber(s);
            if(c != null)
            {
                if(!new mapNotification().AddSend(c.Id, d, (int)Session["Id_author"]))
                {
                    ModelState.AddModelError("", "Công dân đã được gửi trước đó");
                }
            }
            else
            {
                ModelState.AddModelError("", "Không tồn tại công dân");
            }
            
            List<sending> ls = new mapNotification().GetAllSending(d);
            ViewBag.id = d;
            return View(ls);

        }

        public ActionResult DeleteSend(int id, int id_notifi)
        {
            new mapNotification().DeleteSend(id, id_notifi, (int)Session["Id_author"]);
            return RedirectToAction("SendTo",new {id = id_notifi});
        }

        public ActionResult SendToAll(int id)
        {
            List<citizen> lc = new mapCitizen().GetAll();
            foreach(citizen c in lc)
            {
                new mapNotification().AddSend(c.Id, id, (int)Session["Id_author"]);
            }
            return RedirectToAction("SendTo", new { id = id });
        }

        public ActionResult Delete(int id)
        {
            new mapNotification().Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            if (Session["Id_author"] != null)
            {
                notification n = new notification();
                return View(n);
            }

            return Redirect("~/Home/Login");
        }

        [HttpPost]
        public ActionResult Create(notification n, string send)
        {
            if(send.ToLower() == "all")
            {
                new mapNotification().AddNotifi(n);
                List<citizen> lc = new mapCitizen().GetAll();
                foreach (citizen cc in lc)
                {
                    new mapNotification().AddSend(cc.Id, n.Id, (int)Session["Id_author"]);

                }
                return RedirectToAction("Index");
            }
            citizen c = new mapCitizen().GetCitizenByNumber(send);
            if (c == null)
            {
                ModelState.AddModelError("", "Không tồn tại công dân");
                return View(n);
            }

            new mapNotification().AddNotifi(n);
            new mapNotification().AddSend(c.Id, n.Id, (int)Session["Id_author"]);
            return RedirectToAction("Index");
        }

    }
}