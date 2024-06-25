using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTQLCCCD.Models.SystemHP
{
    public class mapCriminal
    {
        public List<criminal_record> GetCriminalById(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            List<criminal_record> lc = null;
            lc = db.criminal_record.ToList().FindAll(m => m.Id_citizen == id);
            return lc;
        }

        public void Add(criminal_record record)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            db.criminal_record.Add(record);
            db.SaveChanges();

        }

        //trả về id của công dân
        public int Delete(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            criminal_record c = db.criminal_record.Find(id);
            int a = (int)c.Id_citizen;
            db.criminal_record.Remove(c);
            db.SaveChanges();
            return a;
        }
    }
}