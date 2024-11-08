using MiniBank.Models;
using MiniBank.Repository;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Text.Json;


namespace MiniBank.Tests
{
    public class MiniBank_Json_Repository_Should
    {
        [Fact]
        public void Get_All_Accounts()
        {
            //Arrange
            var accountRepository = new AccountJsonRepository(@"../../../../MiniBank.Tests/Data/Accounts.json");
            var expected = 4;

            //Act
            var actual = accountRepository.GetAccounts();

            //Assert
            Assert.Equal(expected, actual.Count);
        }
        [Fact]
        public void Get_Account_with_specific_Id()
        {
            //Arrange
            var accountRepository = new AccountJsonRepository(@"../../../../MiniBank.Tests/Data/Accounts.json");
            var actualAccount = new Account()
            {
                Id = 3,
                Iban = "GE91SB4412587693211000",
                Currency = "GEL",
                Balance = 3500,
                CustomerId = 2,
                Name = ""
            };
            
            //Act
            var expectedAccount = accountRepository.GetAccount(3);
            //Assert
            Assert.NotNull(actualAccount);
            Assert.Equal(expectedAccount.Id, actualAccount.Id);
            Assert.Equal(expectedAccount.Iban, actualAccount.Iban);
            Assert.Equal(expectedAccount.Currency, actualAccount.Currency);
            Assert.Equal(expectedAccount.Balance, actualAccount.Balance);
            Assert.Equal(expectedAccount.CustomerId, actualAccount.CustomerId);
            Assert.Equal(expectedAccount.Name, actualAccount.Name);
        }
        [Fact]
        public void Delete_Account_with_specific_Id() 
        {
            var accountRepository = new AccountJsonRepository(@"../../../../MiniBank.Tests/Data/Accounts.json");
            accountRepository.Delete(2);
            var expected = 3;
            string jsonString = File.ReadAllText(@"../../../../MiniBank.Tests/Data/Accounts.json");

            // Parse the JSON as JArray
            JArray jsonArray = JArray.Parse(jsonString);

            // Get the count of objects
            int numberOfObjects = jsonArray.Count;
            Assert.Equal(expected, numberOfObjects);
        }
}
}
