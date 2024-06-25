using HTQLCCCD.Models;
using HTQLCCCD.Models.SystemHP;
using System.Web.Mvc;

namespace HTQLCCCD.Areas.Authorities.Controllers
{
    public class HomeController : Controller
    {
        // GET: Authorities/Home
        public ActionResult Index()
        {
            if (Session["Id_author"] != null)
            {
                authority a = new mapAuthorities().GetById((int)Session["Id_author"]);
                ViewBag.TotalCD = new mapCitizen().GetAll().Count;
                ViewBag.TotalSe = new mapNotification().GetAllByAuthor((int)Session["Id_author"]).Count;
                return View(a);
            }
            return Redirect("~/Home/Login");
        }


        public ActionResult CPDN()
        {
            if (Session["Id_author"] != null)
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