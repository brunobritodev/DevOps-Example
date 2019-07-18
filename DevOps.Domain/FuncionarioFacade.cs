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
            var fechamento = Fechamento.GerarFechamento(_funcionario, inicioCiclo);
            return CalculadoraPagamento.CalcularPagamento(fechamento);
        }

        public FolhaPonto ReportarHoras(DateTime inicioCiclo)
        {
            var fechamento = Fechamento.GerarFechamento(_funcionario, inicioCiclo);
            return RelatorioHoras.ReportarHoras(fechamento);
        }
    }
}
