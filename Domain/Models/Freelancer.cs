using Domain.Enum;
using Domain.Models.Adress;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Domain.Models
{
    public class Freelancer : ModelBasic
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public SexoEnum Sexo { get; set; }
        public string Skills { get; set; }
        public string Experience { get; set; }
        public string Description { get; set; }
        public string Portfolio { get; set; }
        public virtual FreelancerAdress FreelancerAdress { get; set; }
    }
}
