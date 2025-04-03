using System.ComponentModel;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using static System.Net.Mime.MediaTypeNames;

namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        // 1 Número de identificação único,
        // 2 um saldo disponível 
        // 3 um limite de débito estabelecido.
        // 4 mantém um registro de movimentações financeiras, que englobam todas as transações realizadas.
        // 5 Cada movimentação registrada na conta corresponde a uma transação financeira, 
        //   que pode ser classificada como crédito(depósito ou entrada de dinheiro) ou débito (saque ou retirada de fundos).

        // 6 Cada transação contém um valor associado e impacta diretamente o saldo da conta.
        // 7 Saque: Permite a retirada de valores, respeitando o limite máximo permitido.
        // 8 Depósito: Possibilita a adição de fundos à conta.
        // 9 Consulta de saldo: Fornece informações atualizadas sobre o montante disponível.
        // 10 Emissão de extrato: Lista todas as movimentações realizadas em um período específico.
        // 11 Transferência entre contas: Permite a movimentação de valores entre contas correntes distintas.
        // 12 No que se refere aos saques, a conta corrente só pode efetuar retiradas
        //    caso o valor solicitado não ultrapasse o limite de saque permitido, que
        //    corresponde à soma do saldo disponível com o limite adicional concedido à conta.
        //------------------------------------------------------------------------------------------------------------------------------

        static void Main(string[] args)
        {
            ContaCorrente conta1 = new ContaCorrente();
            conta1.numeroConta = 1;
            conta1.saldo = 1000;
            conta1.Sacar(200);
            conta1.Depositar(200);

            conta1.movimentacoes = new Movimentacao[10];
            conta1.Sacar(200);
            conta1.Depositar(300);

            ContaCorrente conta2 = new ContaCorrente();
            conta2.saldo = 300;
            conta2.numeroConta = 13;

            conta2.limite = -1000;

            conta2.movimentacoes = new Movimentacao[10];

            conta1.TransferirPara(conta2, 400);


            conta1.ExibirExtrato();

            Console.WriteLine();

            conta2.ExibirExtrato();
        }
    }
}
