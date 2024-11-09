using System.Diagnostics.CodeAnalysis;

namespace MiniBank.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Iban { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
    }
    public class AccountEqulityComparer : IEqualityComparer<Account>
    {
        public bool Equals(Account x, Account y) => x.Id == y.Id &&
                x.Name.ToLower().Trim() == y.Name.ToLower().Trim() &&
                x.Iban.ToLower().Trim() == y.Iban.ToLower().Trim() &&
                x.Currency.Trim() == y.Currency.Trim() &&
                x.Balance == y.Balance &&
                x.CustomerId == y.CustomerId;
        public int GetHashCode([DisallowNull] Account obj) => obj.Name.Length;
    }
}
