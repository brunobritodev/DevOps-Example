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

            repo.Departamentos = Departamento.Obter().Generate(5);
            repo.Funcionarios = Funcionario.Obter().Generate(faker.Random.Int(1, 20));

            var mesesParaGerar = faker.Random.Int(1, 3);
            var diaAtual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            diaAtual = diaAtual.Date.AddMonths(mesesParaGerar * -1);

            while (DateTime.Now.Date > diaAtual.Date)
            {
                Parallel.ForEach(repo.Funcionarios, (funcionario) =>
                {
                    if (funcionario.PontoDigital == null)
                        funcionario.PontoDigital = new List<PontoDigital>();

                    funcionario.PontoDigital.Add(PontoDigital.Obter(diaAtual).Generate());
                });


                diaAtual = diaAtual.AddDays(1);
            }

            foreach (var funcionario in repo.Funcionarios)
            {
                funcionario.Departamento = faker.PickRandom(repo.Departamentos);
            }

            return repo;
        }

    }
}
