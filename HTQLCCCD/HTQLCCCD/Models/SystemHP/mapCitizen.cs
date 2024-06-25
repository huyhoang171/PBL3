using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTQLCCCD.Models.SystemHP
{
    public class mapCitizen
    {
        public citizen GetCitizenById(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            citizen c = null;
            c = db.citizens.ToList().Find(m => m.Id == id);
            return c;
        }

        public citizen GetCitizenByNumber(string s)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            citizen c = null;
            c = db.citizens.Where(m => m.Number == s).Select(m => m).FirstOrDefault();
            return c;
        }

        public List<citizen> GetAll()
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            List<citizen> lc = db.citizens.ToList();
            return lc;

        }

        //tìm kiếm
        public List<citizen> Search(string search)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            List<citizen> lc = db.citizens.ToList().FindAll(m => m.Number == search || m.Name.Contains(search)|| m.Place_of_origin.Contains(search));
            
            return lc;

        }

        public bool Add(citizen c)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            if(db.citizens.FirstOrDefault(m => m.Number == c.Number) == null)
            {
                if(c.Father != null && db.citizens.FirstOrDefault(m => m.Id == c.Father) == null)
                {
                    return false;
                }
                if (c.Mother != null && db.citizens.FirstOrDefault(m => m.Id == c.Mother) == null)
                {
                    return false;
                }
                db.citizens.Add(c);
                db.SaveChanges();
                return true;
            }
            
            return false;
        }

        public bool Update(citizen c)
        {
            if (c.Name == null || c.Place_of_origin == null || c.Place_of_residence == null || c.job == null )
            {
                return false;
            }    

            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            citizen cc = db.citizens.Find(c.Id);
            if (c.Father != null && db.citizens.FirstOrDefault(m => m.Id == c.Father) == null)
            {
                return false;
            }
            if (c.Mother != null && db.citizens.FirstOrDefault(m => m.Id == c.Mother) == null)
            {
                return false;
            }
            cc.Name = c.Name;
            if(c.Join_military != null)
            {
                cc.Join_military = c.Join_military;
            }    
            
            if(c.Married != null)
            {
                cc.Married = c.Married;
            }    

            if(c.Sex != null)
            {
                cc.Sex = c.Sex;
            }    

            cc.Father = c.Father;
            
            cc.Mother = c.Mother;
             
            cc.Date_of_birth = c.Date_of_birth;
            cc.Place_of_origin = c.Place_of_origin;
            cc.Place_of_residence = c.Place_of_residence;
            cc.job = c.job; 
            db.SaveChanges();

            return true;
        }

        public void Delete(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            
            //xóa tiền án
            List<criminal_record> lc = db.criminal_record.Where(m => m.Id_citizen == id).Select(m => m).ToList();
            db.criminal_record.RemoveRange(lc);
            //xóa yêu cầu
            List<requirement> lr = db.requirements.Where(m => m.Id_sender == id).Select(m => m).ToList();
            db.requirements.RemoveRange(lr);
            //xóa lịch hẹn
            List<appointment_schedule> la = db.appointment_schedule.Where(m => m.Id_sender == id).Select(m => m).ToList();
            db.appointment_schedule.RemoveRange(la);
            //xóa account
            account a = db.accounts.FirstOrDefault(m => m.Id_user == id);
            if (a != null)
            {
                db.accounts.Remove(a);
            }    
            
            //có là cha của ai k
            List<citizen> lci = db.citizens.Where(m => m.Father == id).Select(m =>m).ToList();    
            if(lci.Count > 0)
            {
                foreach(citizen i in lci)
                {
                    i.Father = null;
                }
            }
            //có là mẹ của ai k
            List<citizen> lcii = db.citizens.Where(m => m.Mother == id).Select(m => m).ToList();
            if (lci.Count > 0)
            {
                foreach (citizen i in lci)
                {
                    i.Mother = null;
                }
            }
            //xóa tất cả thông báo
            List<sending> lse = db.sendings.Where(m => m.Id_receiver == id).Select(m => m).ToList();
            db.sendings.RemoveRange(lse);
            //xóa tất cả feedback
            List<feedback> lf = db.feedbacks.Where(m => m.Id_sender == id).Select(m => m).ToList(); 
            db.feedbacks.RemoveRange(lf);

            //xóa công dân
            citizen c = db.citizens.Find(id);
            db.citizens.Remove(c);  
            db.SaveChanges();
        }

    }
}