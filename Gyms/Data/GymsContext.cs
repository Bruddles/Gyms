using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Gyms.Models;

namespace Gyms.Models
{
    public class GymsContext : DbContext
    {
        public GymsContext (DbContextOptions<GymsContext> options)
            : base(options)
        {
        }

        public DbSet<Gyms.Models.Client> Client { get; set; }

        public DbSet<Gyms.Models.Instructor> Instructor { get; set; }
    }
}
