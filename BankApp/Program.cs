using System;

namespace BankApp;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Bank App!");

        var bank = new Bank();

        var accountHolder1 = new AccountHolderDetails("Tim Shao", "123456789", "123 Elm Street");
        var accountNumber1 = new BankAccountNumber("000012345678");
        var checking = new BankAccount(accountNumber1, BankAccountType.Checking, accountHolder1, 500m);

        var accountHolder3 = new AccountHolderDetails("Ni Kang", "987654321", "456 Oak Avenue");
        var accountNumber3 = new BankAccountNumber("000123456789");
        var savings = new BankAccount(accountNumber3, BankAccountType.Savings, accountHolder3, 1200m);

        bank.OpenAccount(checking);
        bank.OpenAccount(savings);

        var bankAccount = checking;

        var selected = bank.GetAccount(accountNumber3);
        selected.AddTransaction(321m, "Deposit");
        selected.AddTransaction(-123m, "ATM Withdrawal");
        Console.WriteLine(selected.DisplayAccountInfo());

        Console.WriteLine("\nDisplay basic bank account information");
        Console.WriteLine($"Account type description: {bankAccount.AccountType.GetDescription()}");
        Console.WriteLine(bankAccount.DisplayAccountInfo());

        bankAccount.AddTransaction(200m, "Deposit");
        bankAccount.AddTransaction(-50m, "ATM Withdrawal");

        Console.WriteLine("\nDemonstrate using the Transaction record");
        Console.WriteLine(bankAccount.DisplayAccountInfo());

        bankAccount.DisplayTransactions();

        var rows = bankAccount.Transactions
            .Select(t => new
            {
                t.Date,
                t.Description,
                t.Amount,
                Kind = t.Amount >= 0 ? "Credit" : "Debit"
            });

        Console.WriteLine("Transaction report:");
        foreach (var row in rows)
        {
            Console.WriteLine($"{row.Date:d} | {row.Kind,-6} | {row.Amount,10:C} | {row.Description}");
        }

        Console.WriteLine("Daily totals:");
        foreach (var day in bankAccount.GetDailyTotals())
        {
            Console.WriteLine($"{day.Day}: {day.Total:C} ({day.Count} tx)");
        }

        var topDebits = bankAccount.Transactions
            .Where(t => t.Amount < 0)
            .OrderBy(t => t.Amount)
            .Take(3)
            .Select(t => new
            {
                t.Date,
                t.Description,
                t.Amount
            });

        Console.WriteLine("Top debits:");
        foreach (var d in topDebits)
        {
            Console.WriteLine($"{d.Date:d} | {d.Amount,10:C} | {d.Description}");
        }

        var feeLedger = new Ledger<Fee>();
        feeLedger.Add(new Fee(-2.50m, DateTime.Now, "Monthly service fee"));
        Console.WriteLine($"Fee ledger total: {feeLedger.Total():C}");

        AccountHolderDetails accountHolder2 = new("Tim Shao", "123456789", "123 Elm Street");

        Console.WriteLine("\nDemonstrate record comparison and struct immutability");
        Console.WriteLine($"Are customers equal? {accountHolder1 == accountHolder2}");

        BankAccountNumber accountNumber2 = new("000123456789");
        Console.WriteLine($"Original Account Number: {accountNumber2}");
    }
}