using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models.Adress
{
    public class FreelancerAdress : ModelBasic
    {
        public string City { get; set; }
        public string State { get; set; }
        [ForeignKey("FreelancerId")]
        public virtual Freelancer Freelancer { get; set; }
    }
}
