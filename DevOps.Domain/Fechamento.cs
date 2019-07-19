using DevOps.Repository;

namespace DevOps.Domain
{
    public class Fechamento
    {
        public Funcionario Funcionario { get; }
        public Pagamento Pagamento { get; private set; }
        public FolhaPonto FolhaPonto { get; private set; }

        public Fechamento(Funcionario funcionario)
        {
            Funcionario = funcionario;
        }

        public Fechamento Adicionar(FolhaPonto folhaPonto)
        {
            FolhaPonto = folhaPonto;
            return this;
        }
        public Fechamento Adicionar(Pagamento pagamento)
        {
            Pagamento = pagamento;
            return this;
        }

        public static Fechamento Novo(Funcionario funcionario)
        {
            return new Fechamento(funcionario);
        }
    }
}
