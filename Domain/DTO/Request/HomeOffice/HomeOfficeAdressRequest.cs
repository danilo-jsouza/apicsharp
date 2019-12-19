using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO.Request.HomeOffice
{
    public class HomeOfficeAdressRequest
    {
        public string City { get; set; }
        public string State { get; set; }
        public virtual HomeOfficeRequest HomeOfficeRequest { get; set; }
    }
}
