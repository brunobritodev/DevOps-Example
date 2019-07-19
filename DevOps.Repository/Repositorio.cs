using Bogus;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevOps.Repository
{
    public class Repositorio
    {
        public IEnumerable<Departamento> Departamentos { get; set; }
        public IEnumerable<Funcionario> Funcionarios { get; set; }
        public static Repositorio CriarRepositorio()
        {
            var faker = new Faker();
            var repo = new Repositorio();

            var mesesParaGerar = faker.Random.Int(1, 3);

            repo.Departamentos = Departamento.Obter().Generate(5);
            repo.Funcionarios = Funcionario.Obter(mesesParaGerar).Generate(faker.Random.Int(1, 20));

            Parallel.ForEach(repo.Funcionarios, (funcionario) =>
            {
                var diaAtual = funcionario.DataContratacao.Date;
                while (DateTime.Now.Date > diaAtual.Date)
                {
                    if (funcionario.PontoDigital == null)
                        funcionario.PontoDigital = new List<PontoDigital>();
                    if (funcionario.Demitido && funcionario.DataDemissao.Value <= diaAtual)
                        return;

                    funcionario.PontoDigital.Add(PontoDigital.Obter(diaAtual).Generate());
                    diaAtual = diaAtual.AddDays(1);
                }
            });

            foreach (var funcionario in repo.Funcionarios)
            {
                funcionario.Departamento = faker.PickRandom(repo.Departamentos);
            }

            return repo;
        }

    }
}
