using Dio.Bank.Enum;

namespace Dio.Bank.Entities
{
    public class Account
    {
        private AccountType AccountType { get; set; }
        private double Amount { get; set; }
        private double Credit { get; set; }
        private string Name { get; set; }

        public Account(AccountType AcountType, double Amount, double Credit, string Name)
        {
            this.AccountType = AcountType;
            this.Amount = Amount;
            this.Credit = Credit;
            this.Name = Name;
        }

        public bool Withdraw(double value)
        {
            if ((this.Amount - value) < (this.Credit * -1))
            {
                System.Console.WriteLine("Saldo insuficiente!");

                return false;
            }

            this.Amount -= value;

            return true;
        }

        public void Deposit(double value)
        {
            this.Amount += value;

            System.Console.WriteLine($"Saldo atual da conta de {this.Name} é {this.Amount} ");
        }

        public void Transfer(double value, Account account)
        {
            if (this.Withdraw(value))
            {
                account.Deposit(value);
            }
        }

        public override string ToString() => $"Tipo Conta: {this.AccountType} | Nome: {this.Name} | Saldo: {this.Amount} | Crédito: {this.Credit}";
    }
}
