using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DevOps.Repository
{
    public class FolhaPonto : List<PontoDigital>
    {
        public FolhaPonto(IEnumerable<PontoDigital> folhaPonto)
        {
            this.AddRange(folhaPonto);
            Inicio = this.Min(m => m.PontoEntrada).Date;
            Fim = this.Max(m => m.PontoEntrada).Date;
        }

        [Display(Name = "Carga horária"), DisplayFormat(DataFormatString = "{0:HH\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan CargaHorariaNormal { get; set; }
        [Display(Name = "Hora extra"), DisplayFormat(DataFormatString = "{0:HH\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan CargaHorariaExtra { get; set; }
        [Display(Name = "Total de Horas"), DisplayFormat(DataFormatString = "{0:HH\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan TotalHoras { get; set; }
        public DateTime Fim { get; set; }
        public DateTime Inicio { get; set; }

        public Funcionario Funcionario { get; set; }

        public void InformarCarga(double cargaHorariaNormal, double cargaExtra)
        {
            TotalHoras = TimeSpan.FromHours(cargaHorariaNormal + cargaExtra);
            CargaHorariaNormal = TimeSpan.FromHours(cargaHorariaNormal);
            CargaHorariaExtra = TimeSpan.FromHours(cargaExtra);
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