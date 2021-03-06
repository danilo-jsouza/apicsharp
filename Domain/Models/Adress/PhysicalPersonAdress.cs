﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models.Adress
{
    public class PhysicalPersonAdress : ModelBasic
    {
        public string City { get; set; }
        public string State { get; set; }
        [ForeignKey("PhysicalPersonId")]
        public virtual PhysicalPerson PhysicalPerson { get; set; }
    }
}
