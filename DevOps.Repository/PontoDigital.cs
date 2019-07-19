using Bogus;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace DevOps.Repository
{
    [DebuggerDisplay("{PontoEntrada}")]
    public class PontoDigital
    {
        [Display(Name = "Entrada")]
        public DateTime PontoEntrada { get; set; }
        [Display(Name = "Saida")]
        public DateTime PontoSaida { get; set; }
        public Funcionario Funcionario { get; set; }
        public static Faker<PontoDigital> Obter(DateTime dataReferencia)
        {
            var faker = new Faker();
            var dataEntrada = faker.Date.Between(dataReferencia.Date.AddHours(5), dataReferencia.Date.AddHours(11));
            return new Faker<PontoDigital>()
                .RuleFor(t => t.PontoEntrada, dataEntrada)
                .RuleFor(t => t.PontoSaida, f => f.Date.Between(dataEntrada, dataEntrada.Date.AddDays(1)));
        }

        public double ObterCargaHoraria()
        {
            return PontoSaida.Subtract(PontoEntrada).TotalHours - 1;
        }

        public bool TemHoraExtra()
        {
            return ObterCargaHoraria() > 8;
        }

        public double ObterCargaExtra()
        {
            return ObterCargaHoraria() - 8;
        }
    }
}