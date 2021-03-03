using System;
using System.Collections.Generic;
using DIO.Bank.Classes;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("Valor digitado não reconhecido, digite um valor válido");

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado or uttilizar o DIO Bank.");
            Console.ReadLine();

        }

        private static void Transferir()
        {
           Console.WriteLine("Digite o número da conta que receberá o valor: ");
           int indiceDeposito = int.Parse(Console.ReadLine());

           Console.WriteLine("Digite o número da conta que irá transferir: ");
           int indiceSaque = int.Parse(Console.ReadLine());

           Console.WriteLine("Digite o valor a ser transferido: ");
           double valorTran = double.Parse(Console.ReadLine());

           listaContas[indiceSaque].Transferir(valorTran, listaContas[indiceDeposito]);
          
        }

        private static void Depositar()
        {
            Console.Write("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
            
        }

        private static void Sacar()
        {
            Console.Write("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");
            if(listaContas.Count == 0){
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            for(int i =0; i < listaContas.Count; i++){
                Conta conta = listaContas[i];
                Console.Write($"Conta # {i} :");
                Console.WriteLine(conta);
            }
           
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta física ou 2 para Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);

            listaContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank, seu dinheiro está seguro conosco!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar contas"); 
            Console.WriteLine("2 - Inserir nova conta"); 
            Console.WriteLine("3 - Transferir"); 
            Console.WriteLine("4 - Sacar"); 
            Console.WriteLine("5 - Depositar"); 
            Console.WriteLine("C - Limpar Tela"); 
            Console.WriteLine("X - Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario; 
        }
    }
}
