using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO.Response.Company
{
    public class CompanyResponse
    {
        public int Id { get; set; }
        public string FantasyName { get; set; }
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
    }
}
