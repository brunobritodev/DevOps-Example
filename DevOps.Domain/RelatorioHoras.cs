using DevOps.Repository;

namespace DevOps.Domain
{
    public class RelatorioHoras
    {
        public static FolhaPonto ReportarHoras(FolhaPonto folhaPonto)
        {
            var cargaHorariaNormal = 0D;
            var cargaExtra = 0D;

            foreach (var ponto in folhaPonto)
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