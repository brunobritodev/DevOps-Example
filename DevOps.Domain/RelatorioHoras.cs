using DevOps.Repository;

namespace DevOps.Domain
{
    public class RelatorioHoras
    {
        public static FolhaPonto ReportarHoras(Fechamento fechamento)
        {
            var cargaHorariaNormal = 0D;
            var cargaExtra = 0D;
            var folhaPonto = new FolhaPonto(fechamento.Funcionario, fechamento);

            foreach (var ponto in fechamento)
            {
                cargaHorariaNormal += ponto.ObterCargaHoraria();
                if (ponto.TemHoraExtra())
                {
                    cargaExtra += ponto.ObterCargaExtra();
                }

            }

            folhaPonto.InformarCarga(cargaHorariaNormal, cargaExtra);
            return folhaPonto;
        }
    }
}