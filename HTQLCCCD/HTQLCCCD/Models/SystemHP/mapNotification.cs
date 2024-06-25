using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTQLCCCD.Models.SystemHP
{
    public class mapNotification
    {
        
        public DateTime DateTime { get; set; }
        public string Purport { get; set; }

        public mapNotification() { }

        public mapNotification(DateTime d, string p) 
        { 
            DateTime = d;
            Purport = p;
        }
        //lấy ra tất cả thông báo của công dân theo id công dân
        public List<mapNotification> GetAllById(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            List<sending> ls = db.sendings.ToList().FindAll(m => m.Id_receiver == id);
            if(ls.Count != 0)
            {
                ls.Sort((x, y) => DateTime.Compare((DateTime)y.Date_send, (DateTime)x.Date_send));
                
                List<mapNotification> lm = new List<mapNotification>();
                foreach (sending s in ls)
                {
                    
                    notification n = db.notifications.ToList().Find(m => m.Id == s.Id_notifi);
                    lm.Add(new mapNotification((DateTime)s.Date_send,n.Purport));
                }
                return lm;
            }
            return null;
        }

        public List<notification> GetAll()
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            List<notification> l = db.notifications.ToList();
            return l;
        }

        //lấy ra tất cả sending của 1 notification
        public List<sending> GetAllSending(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            List<sending> l = db.sendings.Where(m => m.Id_notifi == id).Select(m => m).ToList();
            return l;
        }

        //lấy ra tất cả sending của 1 cơ quan chính quyền
        public List<sending> GetAllByAuthor(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            List<sending> l = db.sendings.ToList().FindAll(m => m.Id_sender == id);
            return l;
        }

        public notification GetNotifiById(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            notification n = db.notifications.Find(id);
            return n;
        }

        public bool AddSend(int id_citizen,int id_notifi,int id_sender)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            List<sending> ls = GetAllSending(id_notifi);
            sending s = ls.Find(m => m.Id_receiver == id_citizen);
            if (s != null)
            {
                return false;
            }

            sending ss = new sending()
            {
                Id_sender = id_sender,
                Id_receiver = id_citizen,
                Id_notifi = id_notifi,
                Date_send = DateTime.Now,
                Id = id_sender + id_citizen + id_notifi
            };
            db.sendings.Add(ss);
            db.SaveChanges();

            return true;
        }

        //xóa 1 record sending
        public void DeleteSend(int id,int id_notifi, int id_sender)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            sending s = db.sendings.FirstOrDefault(m => m.Id == id && m.Id_sender == id_sender && m.Id_notifi == id_notifi);
            db.sendings.Remove(s);
            db.SaveChanges();
        }
        
        //xóa đi 1 thông báo
        public void Delete(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            notification n = db.notifications.Find(id);
            List<sending> l = db.sendings.Where(m => m.Id_notifi == id).Select(m => m).ToList();
            db.sendings.RemoveRange(l);
            db.notifications.Remove(n);
            db.SaveChanges();

        }

        public void AddNotifi(notification n)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            db.notifications.Add(n);
            db.SaveChanges();
        }

    }
}