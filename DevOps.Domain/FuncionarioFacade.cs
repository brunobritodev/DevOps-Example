using DevOps.Repository;
using System;

namespace DevOps.Domain
{
    public class FuncionarioFacade
    {
        private readonly Funcionario _funcionario;

        public FuncionarioFacade(Funcionario funcionario)
        {
            _funcionario = funcionario;
        }

        public Pagamento CalcularPagamento(DateTime inicioCiclo)
        {
            var folhaPonto = FolhaPonto.ComputarPeriodo(_funcionario, inicioCiclo);
            return CalculadoraPagamento.CalcularPagamento(folhaPonto);
        }

        public FolhaPonto ReportarHoras(DateTime inicioCiclo)
        {
            var folhaPonto = FolhaPonto.ComputarPeriodo(_funcionario, inicioCiclo);
            return RelatorioHoras.ReportarHoras(folhaPonto);
        }
    }
}
