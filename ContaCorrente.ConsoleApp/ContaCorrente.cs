

namespace ContaCorrente.ConsoleApp
{
    class ContaCorrente
    {
        public int numeroConta;

        public decimal saldo;

        public void Sacar(decimal valor)
        {
            saldo -= valor;
        }
        
        public void Depositar(decimal valor)
        {
            saldo += valor;
        }
        
    }
}
