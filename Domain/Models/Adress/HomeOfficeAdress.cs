using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models.Adress
{
    public class HomeOfficeAdress : ModelBasic
    {
        public string City { get; set; }
        public string State { get; set; }
        [ForeignKey("HomeOfficeId")]
        public virtual HomeOffice HomeOffice { get; set; }
    }
}
