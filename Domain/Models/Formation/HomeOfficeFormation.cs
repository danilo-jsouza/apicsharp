using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models.Formation
{
    public class HomeOfficeFormation : ModelBasic
    {
        public FormationEnum Type { get; set; }
        public string School { get; set; }
        public string Course { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        [ForeignKey("HomeOfficeId")]
        public virtual HomeOffice HomeOffice { get; set; }
    }
}
