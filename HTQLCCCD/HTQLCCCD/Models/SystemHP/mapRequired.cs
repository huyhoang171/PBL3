using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace HTQLCCCD.Models.SystemHP
{
    public class mapRequired
    {

        public void AddRequired(requirement r)
        {
            try
            {
                HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();

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
        }
        
        public List<requirement> GetAll()
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            List<requirement> lr = db.requirements.ToList();
            lr.Sort((a, b) => DateTime.Compare((DateTime)b.Date_send, (DateTime)a.Date_send));
            return lr;
        }

        public requirement GetById(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            requirement r = db.requirements.Find(id);
            return r;
        }

        public void UpdateSolve(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            requirement r = db.requirements.Find(id);
            r.Solved = true;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            requirement r = db.requirements.Find(id);
            db.requirements.Remove(r);
            db.SaveChanges();
        }
    }
}