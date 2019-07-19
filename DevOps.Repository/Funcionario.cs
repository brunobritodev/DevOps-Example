using Bogus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Valor Hora")]
        public decimal ValorHora { get; set; }

        [Display(Name = "Contratado Em"), DataType(DataType.Date)]
        public DateTime DataContratacao { get; set; }
        public bool Demitido { get; set; }
        [Display(Name = "Desligado"), DataType(DataType.Date)]
        public DateTime? DataDemissao { get; set; }
        public Departamento Departamento { get; set; }
        public List<PontoDigital> PontoDigital { get; set; }
        public static Faker<Funcionario> Obter(int mesesParaGerar)
        {
            var faker = new Faker();
            var demitido = faker.Random.Bool(0.1f);
            var dataContratacao = faker.Date.Past();
            return new Faker<Funcionario>()
                .RuleFor(e => e.Id, f => f.Random.Int())
                .RuleFor(e => e.DepartmentoId, f => f.Random.Int())
                .RuleFor(e => e.Nome, f => f.Person.FullName)
                .RuleFor(e => e.Cargo, f => f.Name.JobTitle())
                .RuleFor(e => e.ValorHora, f => f.Random.Decimal(7, 150))
                .RuleFor(e => e.DataContratacao, f => f.Date.Past())
                .RuleFor(e => e.Demitido, f => demitido)
                .RuleFor(e => e.DataDemissao, f => demitido ? f.Date.Past(refDate: dataContratacao) : (DateTime?)null);
        }

        public IEnumerable<PontoDigital> ObterPontoDigitalDoPeriodo(DateTime periodoInicial, DateTime periodoFinal)
        {
            return PontoDigital.Where(w => w.PontoEntrada > periodoInicial.Date && w.PontoSaida < periodoFinal.Date);
        }

    }
}