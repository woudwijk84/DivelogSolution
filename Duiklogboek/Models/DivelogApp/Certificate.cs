using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Duiklogboek.Models.DivelogApp
{
    public class Certificate
    {
        [Key]
        public virtual int CertificateId { get; set; }

        public virtual string DivingOrganisation { get; set; }

        public virtual string Username { get; set; }

    }
}