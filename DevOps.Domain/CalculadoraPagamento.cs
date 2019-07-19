using DevOps.Repository;
using System;

namespace DevOps.Domain
{
    public class CalculadoraPagamento
    {
        public static Pagamento CalcularPagamento(FolhaPonto folhaPonto)
        {
            var valorTotalHoraNormal = 0m;
            var valorTotalExtra = 0m;
            var pagamento = new Pagamento(folhaPonto.Funcionario, folhaPonto);

            foreach (var ponto in folhaPonto)
            {
                var cargaHorariaDoDia = ponto.ObterCargaHoraria();
                valorTotalHoraNormal = pagamento.CalcularHoraNormal(cargaHorariaDoDia);
                if (ponto.TemHoraExtra())
                {
                    var cargaExtra = ponto.ObterCargaExtra();
                    valorTotalExtra += pagamento.CalcularHoraExtra(cargaExtra);
                }

            }

            pagamento.PagoEm = new DateTime(folhaPonto.Inicio.Year, folhaPonto.Inicio.Month, 5);
            pagamento.InformarSalario(valorTotalHoraNormal, valorTotalExtra);
            return pagamento;
        }
    }
}