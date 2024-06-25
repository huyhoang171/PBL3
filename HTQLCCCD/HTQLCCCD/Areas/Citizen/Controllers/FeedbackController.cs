using HTQLCCCD.Models;
using HTQLCCCD.Models.SystemHP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTQLCCCD.Areas.Citizen.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Citizen/Feedback
        public ActionResult Index()
        {
            if (Session["Id_user"] != null)
            {
                feedback f = new feedback();
                ViewBag.feedback = new mapFeedback().GetAll((int)Session["Id_user"]);
                return View(f);
            }
            return Redirect("~/Home/Login");
        }

        [HttpPost]
        public ActionResult Index(feedback f)
        {
            if(f.Purport == null)
            {
                ModelState.AddModelError("", "Bạn chưa nhập thông tin");
                ViewBag.feedback = new mapFeedback().GetAll((int)Session["Id_user"]);
                return View(f);
            }   
            else if(f.Purport.Length < 20)
            {
                ModelState.AddModelError("", "Thông tin chưa đủ ký tự");
                ViewBag.feedback = new mapFeedback().GetAll((int)Session["Id_user"]);
                return View(f);
            }
            else
            {
                f.Id_sender = (int)Session["Id_user"];
                f.Type = 0;
                f.Date_send = DateTime.Now;
                new mapFeedback().Add(f);
                return RedirectToAction("Index");   
            }
        }
    }
}