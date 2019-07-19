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

        public Fechamento FecharCiclo(DateTime inicio, DateTime fim)
        {
            return Fechamento.Novo(_funcionario).Adicionar(CalcularPagamento(inicio)).Adicionar(RelatoHoras(inicio));
        }

        private Pagamento CalcularPagamento(DateTime inicioCiclo)
        {
            var folhaPonto = FolhaPonto.ComputarPeriodo(_funcionario, inicioCiclo);
            return CalculadoraPagamento.CalcularPagamento(folhaPonto);
        }

        private FolhaPonto RelatoHoras(DateTime inicioCiclo)
        {
            var folhaPonto = FolhaPonto.ComputarPeriodo(_funcionario, inicioCiclo);
            return RelatorioHoras.ReportarHoras(folhaPonto);
        }
    }
}
