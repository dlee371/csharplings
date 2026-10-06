// quiz2.cs
//
// 🧩 Quiz 2: object-oriented C#. Build a small banking model from scratch.
//
//   * IAccount interface:
//       string Owner (read-only), decimal Balance (read-only),
//       void Deposit(decimal amount), void Withdraw(decimal amount)
//
//   * Account class, implementing IAccount:
//       - Anyone can read Balance, but only the account itself can change it.
//       - Deposit and Withdraw throw ArgumentOutOfRangeException if amount <= 0.
//       - Withdraw throws InsufficientFundsException if the balance is too low.
//       - History: a read-only list of strings like "+100" and "-30".
//
//   * SavingsAccount, which inherits from Account:
//       - Has an InterestRate, and ApplyInterest() deposits Balance × InterestRate.
//       - Allows only 3 withdrawals; the 4th throws InvalidOperationException.
//         (Hint: you'll need to make Withdraw virtual.)
//
//   * InsufficientFundsException, with a Shortfall property (how much was missing).
//
// The checks below spell out exactly what's expected. Read them carefully!

// I AM NOT DONE

var checking = new Account("Ada");
checking.Deposit(100);
checking.Withdraw(30);
Check.Equal("Ada", checking.Owner);
Check.Equal(70m, checking.Balance);
Check.Equal(new List<string> { "+100", "-30" }, checking.History);

Check.Throws<ArgumentOutOfRangeException>(() => checking.Deposit(0));
Check.Throws<ArgumentOutOfRangeException>(() => checking.Withdraw(-5));
var error = Check.Throws<InsufficientFundsException>(() => checking.Withdraw(100));
Check.Equal(30m, error.Shortfall);
Check.Equal(70m, checking.Balance);

var savings = new SavingsAccount("Grace", interestRate: 0.05m);
savings.Deposit(1000);
savings.ApplyInterest();
Check.Equal(1050m, savings.Balance);
savings.Withdraw(1);
savings.Withdraw(1);
savings.Withdraw(1);
Check.Throws<InvalidOperationException>(() => savings.Withdraw(1));
Check.Equal(1047m, savings.Balance);

List<IAccount> all = [checking, savings];
decimal total = 0;
foreach (IAccount account in all)
{
    total += account.Balance;
}
Check.Equal(1117m, total);

// Write your types below 👇
