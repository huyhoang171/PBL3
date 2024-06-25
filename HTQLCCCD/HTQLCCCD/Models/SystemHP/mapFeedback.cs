using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTQLCCCD.Models.SystemHP
{
    public class mapFeedback
    {
        public void Add(feedback f)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            db.feedbacks.Add(f);
            db.SaveChanges();
        }

        //lấy ra 5 feedback gần đây
        public List<feedback> GetAll(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            List<feedback> lf = db.feedbacks.ToList().FindAll(m => m.Id_sender == id);
            lf.Sort((x,y) => DateTime.Compare((DateTime)y.Date_send,(DateTime)x.Date_send));
            
            if(lf.Count > 5)
            {
                List<feedback> l = new List<feedback>();
                for(int i =0; i < 5; i++)
                {
                    l.Add(lf[i]);
                }
                return l;

            }
            return lf;
        }

        public List<feedback> GetAll()
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            var l = db.feedbacks.ToList();
            return l;
        }

        public void Delete(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            feedback a = db.feedbacks.Where(m => m.Id == id).FirstOrDefault();
            db.feedbacks.Remove(a);
            db.SaveChanges();
        }
    }
}