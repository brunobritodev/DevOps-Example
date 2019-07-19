using Bogus;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace DevOps.Repository
{
    [DebuggerDisplay("{Nome}")]
    public class Departamento
    {
        public int Id { get; set; }
        [Display(Name = "Departamento")]
        public string Nome { get; set; }

        public static Faker<Departamento> Obter()
        {
            return new Faker<Departamento>()
                .RuleFor(d => d.Id, f => f.Random.Int())
                .RuleFor(d => d.Nome, f => f.Name.JobArea());
        }
    }
}