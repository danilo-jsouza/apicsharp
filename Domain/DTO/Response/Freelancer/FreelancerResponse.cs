using Domain.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO.Response.Freelancer
{
    public class FreelancerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public SexoEnum Sexo { get; set; }
        public string Skills { get; set; }
        public string Experience { get; set; }
        public string Description { get; set; }
        public string Portfolio { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public virtual FreelancerAdressResponse FreelancerAdressResponse { get; set; }
        public virtual IEnumerable<FreelancerFormationResponse> FreelancerFormationResponse { get; set; }
    }
}
