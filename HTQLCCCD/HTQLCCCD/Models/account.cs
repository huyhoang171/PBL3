//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HTQLCCCD.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class account
    {
        public int Id { get; set; }
        public string User_name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Nullable<int> Id_user { get; set; }
        public Nullable<int> Id_admin { get; set; }
        public Nullable<int> Id_author { get; set; }
    
        public virtual admin admin { get; set; }
        public virtual admin admin1 { get; set; }
        public virtual authority authority { get; set; }
        public virtual authority authority1 { get; set; }
        public virtual citizen citizen { get; set; }
        public virtual citizen citizen1 { get; set; }
    }
}