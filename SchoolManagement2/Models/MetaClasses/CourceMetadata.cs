using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace SchoolManagement2.Models
{
    public class CourceMetadata
    {
        [StringLength(50)]
        public string title { get; set; }
        [Range(1,8)]
        public int credit { get; set; }

    }
    [MetadataType(typeof(CourceMetadata))]
    public partial class Cource
    {

    }
}