//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vacation
    {
        public int Id { get; set; }
        public Nullable<int> EmpId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> Nod { get; set; }
        public string Status { get; set; }
        public Nullable<int> AdminId { get; set; }
    
        public virtual Admin Admin { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
