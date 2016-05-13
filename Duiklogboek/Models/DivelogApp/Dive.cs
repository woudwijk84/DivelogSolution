using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Duiklogboek.Models.DivelogApp
{
    public class Dive
    {
        [Key]
        public virtual int DiveId { get; set; }

        [DisplayName("Dive number")]
        public virtual int DiveNumber { get; set; }

        [Required]
        public virtual string Location { get; set; }

        [DisplayName("Dive site")]
        public virtual string DiveSite { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public virtual DateTime Date { get; set; }

        [Required]
        public virtual int Duration { get; set; }

        public virtual string Weather { get; set; }

        public virtual string Visibility { get; set; }

        public virtual string Notes { get; set; }

        public string Username { get; set; }

        public string Buddy { get; set; }
    }
}