﻿using Domain.Enum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO.Request.Freelancer
{
    public class FreelancerRequest
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public SexoEnum Sexo { get; set; }
        public string Skills { get; set; }
        public string Experience { get; set; }
        public string Description { get; set; }
        public string Portfolio { get; set; }
        public string Email { get; set; }
        public virtual FreelancerAdressRequest FreelancerAdressRequest { get; set; }
        public virtual IEnumerable<FreelancerFormationRequest> FreelancerFormationRequest { get; set; }
    }
}
