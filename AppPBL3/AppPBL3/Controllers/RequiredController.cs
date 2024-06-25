using AppPBL3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppPBL3.Controllers
{
    public class RequiredController : Controller
    {
        // GET: Required
        public ActionResult Index()
        {
           
            return View();
        }

        //chỉnh sửa thông tin cá nhân

        public ActionResult EditProfile() 
        {
            HeThongQLCCCDEntities1 db = new HeThongQLCCCDEntities1();
            List<citizen> c = db.citizens.ToList();

            return View(c[0]); 
        }

        [HttpPost]
        public ActionResult EditProfile(citizen c)
        {
            try
            {
                    HeThongQLCCCDEntities1 db = new HeThongQLCCCDEntities1();
                    requirement r = new requirement()
                    {
                        Id_sender = c.Id,
                        Type = 2,
                        Date_send = DateTime.Now,
                        Purport = c.Name + " / " + c.Sex.ToString() + " / " + c.Date_of_birth.Value.ToString() + " / " + c.Place_of_origin + " / " + c.Place_of_residence + " / " + c.job + " / " + c.Married.ToString(),
                        Solved = false,
                    };
                    db.requirements.Add(r);
                    //lưu thay đổi
                    db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }   
            return RedirectToAction("Index");
         
        }

    }
}