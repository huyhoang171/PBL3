using HTQLCCCD.Models.SystemHP;
using System.Web.Mvc;
using System.Web.Security;

namespace HTQLCCCD.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username,string password,string role)
        {
            if(role == "CD")
            {
                int id = new mapAccount().GetId_user(username,password,role);
                if(id != -1)
                {
                    Session["Id_user"] = id;
                    return Redirect("~/Citizen/Home/Index");
                }
                
            }
            else if(role == "CQ")
            {
                int id = new mapAccount().GetId_user(username, password, role);
                if (id != -1)
                {
                    Session["Id_author"] = id;
                    return Redirect("~/Authorities/Home/Index");
                }
            }    
            else if(role == "AD")
            {
                int id = new mapAccount().GetId_user(username, password, role);
                if (id != -1)
                {
                    Session["Id_admin"] = id;
                    return Redirect("~/Admin/Home/Index");
                }
            }    

           // TempData["Error"] = "Tài khoản hoặc mật khẩu chưa đúng";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("Id_user");
            Session.Remove("Id_author");
            Session.Remove("Id_admin");
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }


    }
}