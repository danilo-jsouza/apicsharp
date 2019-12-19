using Domain.Enum;
using Domain.Models.Adress;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Domain.Models
{
    public class PhysicalPerson : ModelBasic
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public SexoEnum Sexo { get; set; }
        public virtual PhysicalPersonAdress PhysicalPersonAdress { get; set; }
    }
}
