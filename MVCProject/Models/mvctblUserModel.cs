using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class mvctblUserModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage ="This fiels is required")]
        public string Name { get; set; }
        [DisplayName("Date Of Birth")]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:dd/MMM/yyyy}")]
        public Nullable<System.DateTime> DOB { get; set; }
        public string Designation { get; set; }
        [DisplayName("Skills")]
        public string Skills { get; set; }
    }


}