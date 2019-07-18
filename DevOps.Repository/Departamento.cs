using Bogus;
using System.Diagnostics;

namespace DevOps.Repository
{
    [DebuggerDisplay("{Nome}")]
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public static Faker<Departamento> Obter()
        {
            return new Faker<Departamento>()
                .RuleFor(d => d.Id, f => f.Random.Int())
                .RuleFor(d => d.Nome, f => f.Name.JobArea());
        }
    }
}