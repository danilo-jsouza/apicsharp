using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO.Request.Company
{
    public class CompanyAdressRequest
    {
        public string City { get; set; }
        public string State { get; set; }
        public virtual CompanyRequest CompanyRequest { get; set; }
    }
}
