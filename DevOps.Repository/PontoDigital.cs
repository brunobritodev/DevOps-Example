using Bogus;
using System;

namespace DevOps.Repository
{
    public class PontoDigital
    {
        public int Id { get; set; }
        public DateTime PontoEntrada { get; set; }
        public DateTime PontoSaida { get; set; }

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
            return PontoSaida.Subtract(PontoEntrada).TotalHours;
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