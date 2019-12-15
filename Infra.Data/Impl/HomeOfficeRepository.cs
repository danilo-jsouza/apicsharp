using Domain.Models;
using Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Impl
{
    public class HomeOfficeRepository : Repository<HomeOffice>, IHomeOfficeRepository
    {
        public HomeOfficeRepository(DbContext context) : base(context)
        {

        }
    }
}
