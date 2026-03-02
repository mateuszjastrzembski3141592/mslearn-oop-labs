using System;

namespace BankApp;

public enum BankAccountType
{
    Checking,
    Savings,
    Business
}

public static class BankAccountTypeExtensions
{
    public static string GetDescription(this BankAccountType accountType)
    {
        return accountType switch
        {
            BankAccountType.Checking => "A standard checking account.",
            BankAccountType.Savings => "A standard checking account.",
            BankAccountType.Business => "A standard checking account.",
            _ => "Unknown account type."
        };
    }
}

public readonly struct BankAccountNumber
{
    public string Value { get; }

    public BankAccountNumber(string value)
    {
        if (value is null || value.Length != 12 || !value.All(char.IsDigit))
        {
            throw new ArgumentException("Account numberts must be 12 digits.");
        }

        Value = value;
    }

    public override string ToString() => Value;
}

public record AccountHolderDetails(string Name, string CustomerId, string Address);

public record Transaction(decimal Amount, DateTime Date, string Description)
{
    public override string ToString()
    {
        return $"{Date:d}: {Description}: {Amount:C}";
    }
}

public class BankAccount
{
    public BankAccountNumber AccountNumber { get; }
    public BankAccountType AccountType { get; }
    public decimal Balance { get; private set; }
    public AccountHolderDetails AccountHolder { get; }
    private List<Transaction> Transactions { get; } = [];

    public BankAccount(BankAccountNumber accountNumber, BankAccountType accountType, AccountHolderDetails accountHolder, decimal balance = 0)
    {
        AccountNumber = accountNumber;
        AccountType = accountType;
        AccountHolder = accountHolder;
        Balance = balance;
    }

    public void AddTransaction(decimal amount, string description)
    {
        Balance += amount;
        Transactions.Add(new Transaction(amount, DateTime.Now, description));
    }

    public string DisplayAccountInfo()
    {
        return $"Account Holder: {AccountHolder.Name}, Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance:C}";
    }

    public void DisplayTransactions()
    {
        Console.WriteLine("Transactions:");

        foreach (Transaction transaction in Transactions)
        {
            Console.WriteLine(transaction);
        }
    }
}