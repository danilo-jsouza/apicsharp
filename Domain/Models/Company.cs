using Domain.Interface;
using Domain.Models.Adress;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class Company : ModelBasic
    {
        public string FantasyName { get; set; }
        public string CompanyName { get; set; }
        public string Cnpj { get; set; }
        public virtual CompanyAdress CompanyAdress { get; set; }
    }
}
