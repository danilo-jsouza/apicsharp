using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO.Response.Company
{
    public class CompanyAdressResponse
    {
        public string City { get; set; }
        public string State { get; set; }
        public virtual CompanyResponse CompanyResponse { get; set; }
    }
}
