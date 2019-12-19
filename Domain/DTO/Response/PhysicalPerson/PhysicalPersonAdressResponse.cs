using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO.Response.PhysicalPerson
{
    public class PhysicalPersonAdressResponse
    {
        public string City { get; set; }
        public string State { get; set; }
        public virtual PhysicalPersonResponse PhysicalPersonResponse { get; set; }
    }
}
