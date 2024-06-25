using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTQLCCCD.Models.SystemHP
{
    public class mapAdmin
    {
        public admin GetById(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            var a = db.admins.Find(id);
            return a;
        }

        public void Update(admin a)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            admin ad = db.admins.Find(a.Id);
            if(a.Name != null)
            {
                ad.Name = a.Name;
            }

            if(a.Sex != null)
            {
                ad.Sex = a.Sex;
            }

            if(a.Date_of_birth != null)
            {
                ad.Date_of_birth = a.Date_of_birth;
            }    

            db.SaveChanges();
        }

    }
}