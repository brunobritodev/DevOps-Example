using Bogus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DevOps.Repository
{
    [DebuggerDisplay("{Nome} - {Cargo}")]
    public class Funcionario
    {
        public int Id { get; set; }
        public int DepartmentoId { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public decimal ValorHora { get; set; }
        public Departamento Departamento { get; set; }
        public List<PontoDigital> PontoDigital { get; set; }
        public static Faker<Funcionario> Obter(Departamento departamento = null)
        {
            var faker = new Faker();
            var mes = faker.Random.Int(1, 12);

            return new Faker<Funcionario>()
                .RuleFor(e => e.Id, f => f.Random.Int())
                .RuleFor(e => e.DepartmentoId, f => f.Random.Int())
                .RuleFor(e => e.Nome, f => f.Person.FullName)
                .RuleFor(e => e.Cargo, f => f.Name.JobTitle())
                .RuleFor(e => e.ValorHora, f => f.Random.Decimal(7, 150))
                .RuleFor(e => e.Departamento, f => departamento ?? Departamento.Obter().Generate());
        }

        public IEnumerable<PontoDigital> ObterPontoDigitalDoPeriodo(DateTime periodoInicial, DateTime periodoFinal)
        {
            return PontoDigital.Where(w => w.PontoEntrada > periodoInicial.Date && w.PontoSaida < periodoFinal.Date);
        }
    }
}