using System;

namespace BankApp;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Bank App!");

        AccountHolderDetails accountHolder1 = new("Tim Shao", "123456789", "123 Elm Street");
        BankAccountNumber accountNumber1 = new("000012345678");

        BankAccount bankAccount = new(accountNumber1, BankAccountType.Checking, accountHolder1, 500m);

        Console.WriteLine("\nDisplay basic bank account information");
        Console.WriteLine($"Account type description: {bankAccount.AccountType.GetDescription()}");
        Console.WriteLine(bankAccount.DisplayAccountInfo());

        bankAccount.AddTransaction(200m, "Deposit");
        bankAccount.AddTransaction(-50m, "ATM Withdrawal");

        Console.WriteLine("\nDemonstrate using the Transaction record");
        Console.WriteLine(bankAccount.DisplayAccountInfo());
        bankAccount.DisplayTransactions();

        AccountHolderDetails accountHolder2 = new("Tim Shao", "123456789", "123 Elm Street");

        Console.WriteLine("\nDemonstrate record comparison and struct immutability");
        Console.WriteLine($"Are customers equal? {accountHolder1 == accountHolder2}");

        BankAccountNumber accountNumber2 = new("000123456789");
        Console.WriteLine($"Original Account Number: {accountNumber2}");
    }
}