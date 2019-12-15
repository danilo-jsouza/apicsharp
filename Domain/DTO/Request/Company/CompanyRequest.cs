using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO.Request.Company
{
    public class CompanyRequest
    {
        public string FantasyName { get; set; }
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
    }
}
