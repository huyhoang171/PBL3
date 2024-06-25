using System.Web.Mvc;

namespace HTQLCCCD.Areas.Citizen.Controllers
{
    public class HomeController : Controller
    {
        // GET: Citizen/Home
        public ActionResult Index()
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
    }
}