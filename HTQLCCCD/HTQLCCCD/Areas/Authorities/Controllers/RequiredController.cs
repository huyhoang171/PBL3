using HTQLCCCD.Models;
using HTQLCCCD.Models.SystemHP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTQLCCCD.Areas.Authorities.Controllers
{
    public class RequiredController : Controller
    {
        // GET: Authorities/Required
        public ActionResult Index()
        {
            if (Session["Id_author"] != null)
            {
                List<requirement> lr = new mapRequired().GetAll();
                return View(lr);
            }
            return Redirect("~/Home/Login");
        }

        public ActionResult Solve(int id)
        {
            requirement r = new mapRequired().GetById(id);

            ViewBag.re = GetPurport(r);
            return View(r);
        }

        [HttpPost]
        public ActionResult Solve(requirement c)
        {
            
            if (!new mapCitizen().Update(c.citizen))
            {
                
                return RedirectToAction("Solve", new {id = c.Id}); 
            }
            new mapRequired().UpdateSolve(c.Id);

            return RedirectToAction("Index");
        }

        public List<string> GetPurport(requirement r)
        {
            string[] str = r.Purport.Split('@');
            List<string> list = new List<string>();

            if (str[0].Length >= r.citizen.Name.Length)
            {
                string tmp1 = str[0].Substring(0, r.citizen.Name.Length);
                if (tmp1 != r.citizen.Name)
                {
                    list.Add("Sửa Họ và tên: " + str[0]);
                }
            }
            else
            {
                list.Add("Sửa Họ và tên: " + str[0]);
            }

            if ((str[1].Contains("True") && r.citizen.Sex == false))
            {
                list.Add("Sửa Giới tính: Nam");
            }
            if ((str[1].Contains("False") && r.citizen.Sex == true))
            {
                list.Add("Sửa Giới tính: Nữ");
            }
            string tmp2 = r.citizen.Date_of_birth.Value.Day.ToString() + "/" + r.citizen.Date_of_birth.Value.Month.ToString() + "/" + r.citizen.Date_of_birth.Value.Year.ToString();
            if (!str[2].Contains(tmp2))
            {
                list.Add("Sửa Ngày sinh: " + str[2]);
            }
            if (!str[3].Contains(r.citizen.Place_of_origin))
            {
                list.Add("Sửa Quê quán: " + str[3]);
            }
            if (!str[4].Contains(r.citizen.Place_of_residence))
            {
                list.Add("Sửa Nơi cư trú: " + str[4]);
            }
            if (!str[5].Contains(r.citizen.job))
            {
                list.Add("Sửa Công việc: " + str[5]);
            }

            if ((str[6].Contains("True") && r.citizen.Married == false))
            {
                list.Add("Sửa Hôn nhân: Đã kết hôn");
            }
            if ((str[6].Contains("False") && r.citizen.Married == true))
            {
                list.Add("Sửa Hôn nhân: Chưa kết hôn");
            }

            return list;
        }

        public ActionResult Delete(int id)
        {
            new mapRequired().Delete(id);
            return RedirectToAction("Index");
        }

    }
}