//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolManagement2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Enrollment
    {
        public int EnrollmentId { get; set; }
        public Nullable<int> Grade { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> CourceId { get; set; }
    
        public virtual Cource Cource { get; set; }
        public virtual student student { get; set; }
    }
}