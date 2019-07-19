using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DevOps.Repository
{
    public class FolhaPonto : List<PontoDigital>
    {
        public FolhaPonto() { }
        public FolhaPonto(IEnumerable<PontoDigital> folhaPonto)
        {
            this.AddRange(folhaPonto);
            Inicio = this.Min(m => m.PontoEntrada).Date;
            Fim = this.Max(m => m.PontoEntrada).Date;
        }

        public int Id { get; set; }
        [Display(Name = "Carga horária")]
        public double CargaHorariaNormal { get; set; }
        [Display(Name = "Hora extra")]
        public double CargaHorariaExtra { get; set; }
        [Display(Name = "Total de Horas")]
        public double TotalHoras { get; set; }
        public DateTime Fim { get; set; }
        public DateTime Inicio { get; set; }

        public Funcionario Funcionario { get; set; }

        public void InformarCarga(double cargaHorariaNormal, double cargaExtra)
        {
            TotalHoras = cargaHorariaNormal + cargaExtra;
            CargaHorariaNormal = cargaHorariaNormal;
            CargaHorariaExtra = cargaExtra;
        }

        public static FolhaPonto ComputarPeriodo(Funcionario funcionario, DateTime inicioCiclo)
        {
            var periodoFinal = inicioCiclo.AddMonths(1);
            var folhaPonto = funcionario.ObterPontoDigitalDoPeriodo(inicioCiclo, periodoFinal);
            var fechamento = new FolhaPonto(folhaPonto) { Funcionario = funcionario };
            return fechamento;
        }
    }
}