using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO.Request.PhysicalPerson
{
    public class PhysicalPersonAdressRequest
    {
        public string City { get; set; }
        public string State { get; set; }
        public virtual PhysicalPersonRequest PhysicalPersonRequest { get; set; }
    }
}
