using DevOps.Repository;

namespace DevOps.Domain
{
    public class CalculadoraPagamento
    {
        public static Pagamento CalcularPagamento(Fechamento fechamento)
        {
            var totalHorasNormais = 0m;
            var totalExtra = 0m;
            var pagamento = new Pagamento(fechamento.Funcionario, fechamento);

            foreach (var ponto in fechamento)
            {
                var cargaHorariaDoDia = ponto.ObterCargaHoraria();
                totalHorasNormais = pagamento.CalcularHoraNormal(cargaHorariaDoDia);
                if (ponto.TemHoraExtra())
                {
                    var cargaExtra = ponto.ObterCargaExtra();
                    totalExtra += pagamento.CalcularHoraExtra(cargaExtra);
                }

            }

            pagamento.InformarSalario(totalHorasNormais, totalExtra);
            return pagamento;
        }
    }
}