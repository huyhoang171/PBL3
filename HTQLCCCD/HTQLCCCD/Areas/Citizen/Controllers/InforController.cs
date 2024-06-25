using HTQLCCCD.Models;
using HTQLCCCD.Models.SystemHP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTQLCCCD.Areas.Citizen.Controllers
{
    public class InforController : Controller
    {
        // GET: Citizen/Infor
        public ActionResult Index()
        {
            if (Session["Id_user"] != null)
            {
                citizen c = new mapCitizen().GetCitizenById((int)Session["Id_user"]);
                List<criminal_record> lc = new mapCriminal().GetCriminalById(c.Id);
                if(lc.Count != 0)
                {
                    
                    return RedirectToAction("Index2",new {id = (int)Session["Id_user"] });
                }
                else
                {
                    return View(c);
                }

                

            }
            else
            {
                return Redirect("~/Home/Login");
            }
        }


        public ActionResult Index2(int id)
        {
            citizen c = new mapCitizen().GetCitizenById((int)Session["Id_user"]);
            
            return View(c);
        }

        public ActionResult InfoCP()
        {
            if (Session["Id_user"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("~/Home/Login");
            }
        }

        public ActionResult CPDN()
        {
            if (Session["Id_user"] != null)
            {
                ViewBag.TT = new mapState_leaders().GetTT();
                ViewBag.PTT = new mapState_leaders().GetPTT();
                return View();
            }
            else
            {
                return Redirect("~/Home/Login");
            }
        }
    }
}