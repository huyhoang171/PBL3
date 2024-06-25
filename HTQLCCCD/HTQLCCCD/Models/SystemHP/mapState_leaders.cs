using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTQLCCCD.Models.SystemHP
{
    public class mapState_leaders
    {
        //Lấy ra thủ tướng
        public state_leaders GetTT()
        {
            HeThongQLCCCDEntities2  db = new HeThongQLCCCDEntities2();
            state_leaders s = db.state_leaders.ToList().Find(m => m.Role == "Thu Tuong Chinh Phu");
            return s;
        }

        //lấy ra list phó thủ tướng
        public List<state_leaders> GetPTT()
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            List<state_leaders> ls = db.state_leaders.ToList().FindAll(m => m.Role == "Pho Thu Tuong");
            return ls;
        }

    }
}