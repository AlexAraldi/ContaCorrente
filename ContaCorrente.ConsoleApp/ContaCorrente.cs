using System.Reflection.Metadata;

namespace ContaCorrente.ConsoleApp
{
    public class ContaCorrente
    {
        public decimal saldo;
        public decimal numero;
        public decimal limite;
        public Movimentacao[] movimentacoes;

        public void Depositar(decimal valor)
        {
            saldo += valor;
            limite = saldo;

            Movimentacao movimentacao = new Movimentacao();
            movimentacao.debito = valor;
            movimentacao.tipo = "Credito";
            movimentacao.descricao = $"Crédito de R$  {valor:F2} R$";

            int posicaoVazia = PegaPosicaoVazia();

            movimentacoes[posicaoVazia] = movimentacao;
        }

        public void Sacar(decimal valor)
        {
            if (valor < saldo + limite)
            {
                saldo -= valor;
                limite = saldo;

                Movimentacao movimentacao = new Movimentacao();
                movimentacao.debito = valor;
                movimentacao.tipo = "Débito";
                movimentacao.descricao = $"Débito de R$ {valor:F2} R$";

                int posicaoVazia = PegaPosicaoVazia();

                movimentacoes[posicaoVazia] = movimentacao;
            }
        }

        public void TransferirPara(ContaCorrente contaDestinada, decimal valor)
        {
            this.Sacar(valor);

            contaDestinada.Depositar(valor);
        }

        public void ExibirExtrato()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Extrado da Conta: #{numero}");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Movimentações:");
            Console.WriteLine("-------------------------------");

            foreach (Movimentacao movimentacao in movimentacoes)
            {
                if (movimentacao != null)
                    Console.WriteLine(movimentacao.descricao);
            }

            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Saldo Atual: R$ {saldo:F2}");
        }

        public int PegaPosicaoVazia()
        {
            for (int i = 0; i < movimentacoes.Length; i++)
            {
                if (movimentacoes[i] == null)
                    return i;
            }
            return -1;
        }

    }
}