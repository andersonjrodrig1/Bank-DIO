using Dio.Bank.Entities;
using Dio.Bank.Enum;
using System;
using System.Collections.Generic;

namespace Dio.Bank
{
    class Program
    {
        private static List<Account> bankAccounts = new List<Account>();

        static void Main(string[] args)
        {
            ChoiceOptionBankAccount();
        }

        private static void ChoiceOptionBankAccount()
        {
            string option = string.Empty;

            do
            {
                option = OptionBankAccountMenu();

                switch (option)
                {
                    case "1":
                        ShowAccounts();
                        break;
                    case "2":
                        InsertAccount();
                        break;
                    case "3":
                        Transfer();
                        break;
                    case "4":
                        Deposit();
                        break;
                    case "5":
                        Withdraw();
                        break;
                    case "c":
                        Console.Clear();
                        break;
                    case "x":
                        Console.WriteLine("\nPrograma será encerrado. Obrigado!\n");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida.\n");
                        break;
                }
            } 
            while (option != "x");
        }

        private static string OptionBankAccountMenu()
        {
            Console.Write("**** Dio Instituição Bancária******\n" +
                "1- Listar Contas\n" +
                "2- Inserir Conta\n" +
                "3- Transferir\n" +
                "4- Sacar\n" +
                "5- Depositar\n" +
                "c- Limpar\n" +
                "x- Sair\n" +
                "Escolha uma opção: ");

            string option = Console.ReadLine();

            return option;
        }

        private static void ShowAccounts()
        {
            Console.WriteLine("\nListar Contas:");

            if (bankAccounts.Count <= 0)
            {
                Console.WriteLine("Não existe contas cadastradas!\n");
                return;
            }

            for (int i = 0; i < bankAccounts.Count; i++)
                Console.WriteLine($"#{i} - {bankAccounts[i]}");

            Console.WriteLine("");
        }

        private static void InsertAccount()
        {
            Console.WriteLine("\nInserir Conta:");

            Console.Write("Tipo de Conta (F/J): ");
            string accountType = Console.ReadLine();
            Console.Write("Nome do cliente: ");
            string name = Console.ReadLine();
            Console.Write("Valor do montante da conta: ");
            double amount = Convert.ToDouble(Console.ReadLine());
            Console.Write("Valor do credito: ");
            double credit = Convert.ToDouble(Console.ReadLine());

            AccountType type = (accountType == "F" ? AccountType.PHYSICAL_PERSON : AccountType.LEGAL_PERSON);

            bankAccounts.Add(new Account(type, amount, credit, name));

            Console.WriteLine("Conta cadastrada com sucesso!\n");
        }

        private static void Transfer()
        {
            Console.WriteLine("\nTransferir:");

            Console.Write("Informe número da conta de origem: ");
            int originAccount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Informe número da conta de destino: ");
            int destinyAccount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Informe valor de transferencia: ");
            double value = Convert.ToDouble(Console.ReadLine());

            bankAccounts[originAccount].Transfer(value, bankAccounts[destinyAccount]);

            Console.WriteLine("Transferencia realizada!\n");
        }

        private static void Deposit()
        {
            Console.WriteLine("\nDepósito: ");

            Console.Write("Informe número da conta: ");
            int numberAccount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Informe o valor de depósito: ");
            double value = Convert.ToDouble(Console.ReadLine());

            bankAccounts[numberAccount].Deposit(value);

            Console.WriteLine("Depósito realizado!\n");
        }

        private static void Withdraw()
        {
            Console.WriteLine("\nSaque: ");

            Console.Write("Informe número da conta: ");
            int numberAccount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Informe o valor de saque: ");
            double value = Convert.ToDouble(Console.ReadLine());

            bankAccounts[numberAccount].Withdraw(value);

            Console.WriteLine("Saque realizado!\n");
        }
    }
}