using DevOps.Repository;
using FluentAssertions;
using System;
using Xunit;

namespace DevOps.Tests
{
    public class PagamentoTest
    {
        [Fact]
        public void ValorHoraExtraDeveSer30PorCentoDaHoraNormal()
        {
            var horaExtra = 1;
            var folhaPonto = new FolhaPonto(PontoDigital.Obter(DateTime.Now.AddMonths(-1)).Generate(10));
            var pagamento = new Pagamento(Funcionario.Obter().Generate(), folhaPonto);

            var valorHora = pagamento.CalcularHoraNormal(horaExtra);
            pagamento.CalcularHoraExtra(horaExtra).Should().Be(valorHora * 1.3m);
        }


        [Fact]
        public void ValorDoCalculoHoraDeveSerCem()
        {
            var horasTrabalhadas = 10;
            var funcionario = Funcionario.Obter().Generate();
            funcionario.ValorHora = 10;
            var folhaPonto = new FolhaPonto(PontoDigital.Obter(DateTime.Now.AddMonths(-1)).Generate(10));
            var pagamento = new Pagamento(funcionario, folhaPonto);

            pagamento.CalcularHoraNormal(horasTrabalhadas).Should().Be(100);
        }
    }
}
