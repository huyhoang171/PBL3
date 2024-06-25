using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTQLCCCD.Models.SystemHP
{
    public class mapAuthorities
    {
        //lấy ra cơ quan chính quyền theo Id
        public authority GetById(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            authority a = null;
            a = db.authorities.ToList().Find(m => m.Id == id);
            return a;
        }

        public List<authority> GetAll()
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            List<authority> la = db.authorities.ToList();
            return la;
        }

        public List<authority> Search(string s)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            List<authority> la = db.authorities.ToList().FindAll(m => m.Name.Contains(s) || m.Place_of_origin.Contains(s));
            return la;
        }

        public void Add(authority authority)
        {
            if (authority != null)
            {
                HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2 ();
                db.authorities.Add(authority);
                db.SaveChanges();
            }
        }

        public void Update(authority a)
        {
            if(a != null)
            {
                HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
                authority aa = db.authorities.FirstOrDefault(m => m.Id == a.Id);
                if(aa != null)
                {
                    if(a.Name != null)
                    {
                        aa.Name = a.Name;
                    }

                    if(a.Place_of_origin != null)
                    {
                        aa.Place_of_residence = a.Place_of_origin;
                    }    

                    if(a.Sex != null)
                    {
                        aa.Sex = a.Sex; 
                    }

                    if(a.Date_of_birth != null)
                    {
                        aa.Date_of_birth = a.Date_of_birth;
                    }    

                    if(a.Place_of_residence != null)
                    {
                        aa.Place_of_residence = a.Place_of_residence;
                    }    

                    db.SaveChanges ();
                }    
            }
        }

        public void Delete(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2 ();
            authority a = db.authorities.Find(id);
            if(a != null)
            {
                //xóa account
                account ac = db.accounts.FirstOrDefault(m => m.Id_author == a.Id);
                if (ac != null)
                {
                    db.accounts.Remove(ac);
                }    
                //thay yêu cầu đã giải quyết thành null
                List<requirement> r = db.requirements.ToList().FindAll(m => m.Id_solver == a.Id);
                for(int i = 0; i< r.Count; i++)
                {
                    r[i].Id_solver = null;
                }

                //thay lịch hẹn thành null
                List<appointment_schedule> la = db.appointment_schedule.ToList().FindAll(m => m.Id_solver == a.Id);
                for (int i = 0; i < la.Count; i++)
                {
                    la[i].Id_solver = null;
                }

                //xóa tất cả thông báo
                List<sending> lse = db.sendings.Where(m => m.Id_sender == id).Select(m => m).ToList();
                db.sendings.RemoveRange(lse);

                db.authorities.Remove(a);
                db.SaveChanges ();
            }
        }
    }
}