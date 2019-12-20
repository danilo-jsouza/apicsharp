using Domain.Enum;
using Domain.Models.Adress;
using Domain.Models.Formation;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace Domain.Models
{
    public class HomeOffice : ModelBasic
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public SexoEnum Sexo { get; set; }
        public string Skills { get; set; }
        public string Experience { get; set; }
        public string Description { get; set; }
        public string Portfolio { get; set; }
        public virtual HomeOfficeAdress HomeOfficeAdress { get; set; }
        public virtual IEnumerable<HomeOfficeFormation> HomeOfficeFormation { get; set; }
    }
}
