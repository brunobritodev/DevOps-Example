using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DevOps.Repository;

namespace DevOps.Models
{
    public class DevOpsContext : DbContext
    {
        public DevOpsContext (DbContextOptions<DevOpsContext> options)
            : base(options)
        {
        }

        public DbSet<DevOps.Repository.Funcionario> Funcionario { get; set; }
    }
}
