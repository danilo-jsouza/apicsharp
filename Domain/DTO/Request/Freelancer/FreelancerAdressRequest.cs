using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO.Request.Freelancer
{
    public class FreelancerAdressRequest
    {
        public string City { get; set; }
        public string State { get; set; }
        public virtual FreelancerRequest FreelancerRequest { get; set; }
    }
}
