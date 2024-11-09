using MiniBank.Models;
using System.Security.Principal;
using System.Text.Json;

namespace MiniBank.Repository
{
    public class AccountJsonRepository
    {
        private readonly string _filePath;
        private readonly List<Account> _accounts;

        public AccountJsonRepository(string filePath)
        {
            _filePath = filePath;
            _accounts = LoadData();
        }

        public List<Account> GetAccounts() => _accounts;


        public List<Account> GetAccounts(int userId) => _accounts.Where(account => account.CustomerId == userId).ToList();



        public Account GetAccount(int id) => _accounts.FirstOrDefault(account => account.Id == id);


        public void Create(Account account)
        {
            if (_accounts.All(c => c.Id != account.Id))
            {
                _accounts.Add(account);
                SaveData();
            }
        }

        public void Update(Account account)
        {
            var currentAccount = _accounts.FirstOrDefault(a=> a.Id == account.Id);
            if (currentAccount != null) { 
               currentAccount.Id = account.Id;
               currentAccount.Currency = account.Currency;
               currentAccount.Balance = account.Balance;
               currentAccount.Iban = account.Iban;
               currentAccount.Name= account.Name;
               SaveData();
            }
            
        }

        public void Delete(int id)
        {
            var removedCustomer = _accounts.FirstOrDefault(c => c.Id == id);
            if (removedCustomer != null)
            {
                _accounts.Remove(removedCustomer);
                SaveData();
            }
        }

        private void SaveData()
        {
            string jsonFile = JsonSerializer.Serialize(_accounts, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
            File.WriteAllText(_filePath, jsonFile);
        }

        private List<Account> LoadData()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Account>();
            }
            var jsonData = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Account>>(jsonData);
        }
    }
}
