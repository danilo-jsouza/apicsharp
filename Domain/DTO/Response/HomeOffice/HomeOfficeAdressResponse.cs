using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO.Response.HomeOffice
{
    public class HomeOfficeAdressResponse
    {
        public string City { get; set; }
        public string State { get; set; }
        public virtual HomeOfficeResponse HomeOfficeResponse { get; set; }
    }
}
