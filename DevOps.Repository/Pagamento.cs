using Bogus;
using System;
using System.ComponentModel.DataAnnotations;

namespace DevOps.Repository
{
    public class Pagamento
    {
        public Pagamento(Funcionario funcionario, FolhaPonto folhaPonto)
        {
            this.Funcionario = funcionario;
            PontoDigital = folhaPonto;
        }

        public decimal Salario { get; set; }
        [Display(Name = "Pago em"), DataType(DataType.Date)]
        public DateTime PagoEm { get; set; }
        public Funcionario Funcionario { get; set; }
        public FolhaPonto PontoDigital { get; set; }
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