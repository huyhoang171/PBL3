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
    
    public partial class sending
    {
        public int Id { get; set; }
        public int Id_sender { get; set; }
        public int Id_receiver { get; set; }
        public Nullable<System.DateTime> Date_send { get; set; }
        public Nullable<int> Id_notifi { get; set; }
    
        public virtual authority authority { get; set; }
        public virtual authority authority1 { get; set; }
        public virtual citizen citizen { get; set; }
        public virtual citizen citizen1 { get; set; }
        public virtual notification notification { get; set; }
        public virtual notification notification1 { get; set; }
    }
}
