using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO.Response.Freelancer
{
    public class FreelancerAdressResponse
    {
        public string City { get; set; }
        public string State { get; set; }
        public virtual FreelancerResponse FreelancerResponse { get; set; }
    }
}
