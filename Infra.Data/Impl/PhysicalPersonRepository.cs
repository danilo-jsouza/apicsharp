using Domain.Models;
using Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Impl
{
    public class PhysicalPersonRepository : Repository<PhysicalPerson>, IPhysicalPersonRepository
    {
        public PhysicalPersonRepository(DbContext context) : base(context)
        {

        }
    }
}
