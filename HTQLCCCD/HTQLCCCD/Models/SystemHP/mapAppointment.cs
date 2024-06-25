using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTQLCCCD.Models.SystemHP
{
    public class mapAppointment
    {
        //lấy ra tất cả lịch hẹn của cd và sắp xếp theo tgian mới nhất
        public List<appointment_schedule> GetAllById(int id)
        {
            List<appointment_schedule> la = new HeThongQLCCCDEntities2().appointment_schedule.ToList().FindAll(m => m.Id_sender == id);
            la.Sort((y, x) => DateTime.Compare((DateTime)x.Date_send, (DateTime)y.Date_send));
            return la;
        }

        //lấy ra lịch hẹn sắp tới của cd

        public appointment_schedule GetUpcoming(int id)
        {
            appointment_schedule a = null;
            List<appointment_schedule> la = GetAllById(id).FindAll(x => DateTime.Compare((DateTime)x.Time_start,DateTime.Now) >= 0 );
            la.RemoveAll(x => x.Id_solver == null); //remove những cái chưa duyệt
            la.RemoveAll(x => x.Solved == true); // remomve những cái đã xử lý
            if( la.Count > 0 )
            {
                la.Sort((x, y) => DateTime.Compare((DateTime)x.Time_start, (DateTime)y.Time_start));
                a = la[0];
            }    
          
            return a;
        }

        //lấy lịch hẹn sắp tới cho cơ quan chính quyền
        public appointment_schedule GetUpcomingForAuthor(int id)
        {
            appointment_schedule a = null;
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            List<appointment_schedule> l = db.appointment_schedule.Where(m => m.Id_solver == id && DateTime.Compare((DateTime)m.Time_start,DateTime.Now) >= 0 && m.Solved == false).Select(m => m).ToList();
            if (l.Count > 0)
            {
                l.Sort((x, y) => DateTime.Compare((DateTime)x.Time_start, (DateTime)y.Time_start));
                a = l[0];
            }

            return a;
        }


        public void DeleteById(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            var updateModel = db.appointment_schedule.Find(id);
            db.appointment_schedule.Remove(updateModel);
            db.SaveChanges();
        }

        public bool Add(appointment_schedule a)
        {
            //kiểm tra xem có trùng lịch   
            appointment_schedule k = GetAllById((int)a.Id_sender).Find(x => DateTime.Compare((DateTime)a.Time_start, (DateTime)x.Time_start) == 0);
            if(a.Time_start < DateTime.Now)
            {
                return false;
            }    
            if(k ==  null )
            {
                HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
                db.appointment_schedule.Add(a);
                db.SaveChanges();
                return true;
            }
            return false;
            
        }

        //lấy ra tất cả các lịch hẹn
        public List<appointment_schedule> GetAll()
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            List<appointment_schedule> la = db.appointment_schedule.ToList();
            la.Sort((x, y) => DateTime.Compare((DateTime)y.Date_send, (DateTime)x.Date_send));
            return la;
        }
        
        public void Approve(int id, int id_author)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            var a = db.appointment_schedule.Find(id);
            a.Id_solver = id_author;
            db.SaveChanges();
        }

        public void ChangeSolve(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            appointment_schedule a = db.appointment_schedule.Find(id);
            a.Solved = true;
            db.SaveChanges();

        }

    }
}