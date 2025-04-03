

using System.Net.Http.Headers;
using System.Reflection.Metadata;

namespace ContaCorrente.ConsoleApp
{
    class ContaCorrente
    {
        public int numeroConta;

        public decimal saldo;

        public decimal movimentacao;

        public decimal transferencia;

        public decimal limite;

        public void Sacar(decimal valor)
        {
            saldo -= valor;
            limite = saldo + 1000;
        }

        public void Depositar(decimal valor)
        {
            saldo += valor;
            limite = saldo + 1000;

        }
        public void Movimentacoes(decimal transferencia)
        {
            if (saldo >= -500)
            {
                movimentacao = Sacar ;
            }
            if (saldo <= 1000)
            {
                movimentacao = Depositar;
            }
            

        }

        public void extrato(decimal exibirExtrato)
        {
            exibirExtrato = Convert.ToInt32(movimentacao);
            Console.ReadLine();
            Console.WriteLine("Extrato de movimentações");
        }


    }
}
