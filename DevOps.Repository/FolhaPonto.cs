using System.Collections.Generic;

namespace DevOps.Repository
{
    public class FolhaPonto
    {
        public FolhaPonto(Funcionario funcionario, Fechamento fechamento)
        {
            this.Funcionario = funcionario;
            PontoDigital = fechamento;
        }

        public double CargaHorariaNormal { get; set; }
        public double CargaHorariaExtra { get; set; }
        public double TotalHoras { get; set; }
        public Funcionario Funcionario { get; set; }
        public List<PontoDigital> PontoDigital { get; set; }

        public void InformarCarga(double cargaHorariaNormal, double cargaExtra)
        {
            TotalHoras = cargaHorariaNormal + cargaExtra;
            CargaHorariaNormal = cargaHorariaNormal;
            CargaHorariaExtra = cargaExtra;
        }

    }
}