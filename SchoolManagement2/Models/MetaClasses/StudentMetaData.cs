using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement2.Models
{
    public class StudentMetaData
    {
        [StringLength(50)]
        [Display(Name ="First Name")]
        public string firstname { get; set; }
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string lastname { get; set; }
        [Display(Name = "Enrollment Date")]
        public Nullable<System.DateTime> EnrollmentDate { get; set; }
    }
    [MetadataType(typeof(StudentMetaData))]
    public partial class student { }
}