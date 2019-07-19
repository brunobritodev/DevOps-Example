using DevOps.Repository;
using Microsoft.EntityFrameworkCore;

namespace DevOps.Data
{
    public class DevOpsContext : DbContext
    {
        public DevOpsContext(DbContextOptions<DevOpsContext> options)
            : base(options)
        {
        }
        public DbSet<FolhaPonto> FolhaPontos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<DevOps.Repository.Funcionario> Funcionario { get; set; }
        public DbSet<DevOps.Repository.PontoDigital> PontoDigital { get; set; }
    }
}
