using System;
using System.Collections.Generic;

namespace DevOps.Repository
{
    public class Fechamento : List<PontoDigital>
    {
        public Funcionario Funcionario { get; set; }
        public Fechamento(IEnumerable<PontoDigital> folhaPonto)
        {
            this.AddRange(folhaPonto);
        }
        public static Fechamento GerarFechamento(Funcionario funcionario, DateTime periodoInicial)
        {
            var periodoFinal = periodoInicial.AddDays(30);
            var folhaPonto = funcionario.ObterPontoDigitalDoPeriodo(periodoInicial, periodoFinal);
            var fechamento = new Fechamento(folhaPonto) { Funcionario = funcionario };
            return fechamento;
        }
    }
}