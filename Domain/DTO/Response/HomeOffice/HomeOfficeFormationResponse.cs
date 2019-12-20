using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO.Response.HomeOffice
{
    public class HomeOfficeFormationResponse
    {
        public FormationEnum Type { get; set; }
        public string School { get; set; }
        public string Course { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public virtual HomeOfficeResponse HomeOfficeResponse { get; set; }
    }
}
