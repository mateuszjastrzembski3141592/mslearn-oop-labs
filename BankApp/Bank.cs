using System;
using System.Collections.Generic;
using System.Linq;

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

public interface ILedgerEntry
{
    decimal Amount { get; }
    DateTime Date { get; }
    string Description { get; }
}

public record Transaction(decimal Amount, DateTime Date, string Description) : ILedgerEntry
{
    public override string ToString()
    {
        return $"{Date:d}: {Description}: {Amount:C}";
    }
}

public record DailyTotal(DateOnly Day, decimal Total, int Count);

public class BankAccount
{
    public BankAccountNumber AccountNumber { get; }
    public BankAccountType AccountType { get; }
    public decimal Balance { get; private set; }
    public AccountHolderDetails AccountHolder { get; }

    private readonly Ledger<Transaction> _ledger = new();
    public IReadOnlyList<Transaction> Transactions => _ledger.Entries;

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
        _ledger.Add(new Transaction(amount, DateTime.Now, description));
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

    public IEnumerable<Transaction> GetTransactions() => Transactions;

    public IEnumerable<DailyTotal> GetDailyTotals() => Transactions
        .GroupBy(t => DateOnly.FromDateTime(t.Date))
        .Select(g => new DailyTotal(g.Key, g.Sum(x => x.Amount), g.Count()))
        .OrderBy(x => x.Day);
}

public sealed class Bank
{
    private readonly Dictionary<BankAccountNumber, BankAccount> _accounts = [];

    public void OpenAccount(BankAccount account)
    {
        ArgumentNullException.ThrowIfNull(account);
        _accounts.Add(account.AccountNumber, account);
    }

    public BankAccount GetAccount(BankAccountNumber number)
    {
        if (_accounts.TryGetValue(number, out var account))
        {
            return account;
        }

        throw new InvalidOperationException($"No account exists with number {number}.");
    }

    public bool TryGetAccount(BankAccountNumber number, out BankAccount account) => _accounts.TryGetValue(number, out account!);
    public bool CloseAccount(BankAccountNumber number) => _accounts.Remove(number);
}

public sealed class Ledger<TEntry> where TEntry : ILedgerEntry
{
    private readonly List<TEntry> _entries = [];
    public IReadOnlyList<TEntry> Entries => _entries;

    public void Add(TEntry entry)
    {
        ArgumentNullException.ThrowIfNull(entry);
        _entries.Add(entry);
    }

    public decimal Total() => _entries.Sum(e => e.Amount);
}

public record Fee(decimal Amount, DateTime Date, string Description) : ILedgerEntry;