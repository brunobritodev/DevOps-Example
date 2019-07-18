using System;
using System.Collections.Generic;
using Bogus;

namespace DevOps.Repository
{
    public class Pagamento
    {
        public Pagamento(Funcionario funcionario, Fechamento fechamento)
        {
            this.Funcionario = funcionario;
            PontoDigital = fechamento;
        }

        public decimal Salario { get; set; }
        public DateTime PagoEm { get; set; }
        public Funcionario Funcionario { get; set; }
        public List<PontoDigital> PontoDigital { get; set; }
        public static Faker<Pagamento> Get()
        {
            return new Faker<Pagamento>()
                .RuleFor(p => p.Salario, f => f.Random.Decimal(0, 25000))
                .RuleFor(p => p.PagoEm, f => f.Date.Past());
        }

        public decimal CalcularHoraExtra(double cargaExtra)
        {
            return Funcionario.ValorHora * (decimal)cargaExtra * 1.3m;
        }

        public decimal CalcularHoraNormal(double cargaHorariaDoDia)
        {
            return Funcionario.ValorHora * (decimal)cargaHorariaDoDia;
        }


        public void InformarSalario(decimal totalHorasNormais, decimal totalExtra)
        {
            Salario = totalHorasNormais + totalExtra;
        }
    }
}