using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTQLCCCD.Models.SystemHP
{
    public class mapAccount
    {

        //get
        public List<account> GetAll()
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            return db.accounts.ToList();
        }

        public int GetId_user(string user, string password,string role)
        {
            account a = GetAll().Find(m => m.User_name == user && m.Password == password && m.Role == role);
            if(a == null)
            {
                return -1;
            }
            if(role == "CD")
            {
                return (int)a.Id_user;
            }
            else if(role == "CQ")
            {
                return (int)a.Id_author;
            }  
            else
            {
                return (int)a.Id_admin;
            }
                
        }

        //lấy account theo id_user
        public account GetAccountById(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            account a = db.accounts.FirstOrDefault(m => m.Id_user == id);
            return a;
        }

        //lấy account theo id
        public account GetAccountt(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            account a = db.accounts.Find(id);
            return a;
        }

        public void Add(account a)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            db.accounts.Add(a);
            db.SaveChanges();

        }

        //update account
        public void Update(account a)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            account aa = db.accounts.Find(a.Id); 
            if(a.User_name != null)
            {
                aa.User_name = a.User_name;
            }    
            if(a.Password != null)
            {
                aa.Password = a.Password;
            }    
            
            db.SaveChanges();
        }

        public account GetByIdAd(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            account a = db.accounts.FirstOrDefault(m => m.Id_admin == id);
            return a;
        }

        public account GetByIdAuthor(int id)
        {
            HeThongQLCCCDEntities2 db = new HeThongQLCCCDEntities2();
            account a = db.accounts.FirstOrDefault(m => m.Id_author == id);
            return a;
        }
    }
}