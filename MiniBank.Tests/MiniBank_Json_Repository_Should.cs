using MiniBank.Models;
using MiniBank.Repository;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Text.Json;
using System.Xml.Linq;


namespace MiniBank.Tests
{
    public class MiniBank_Json_Repository_Should
    {
        public int getCount(string str)
        {
            JArray jsonArray = JArray.Parse(str);
            return jsonArray.Count;
        }
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
            Assert.Equal(expectedAccount, actualAccount, new AccountEqulityComparer());
        }
        [Fact]
        public void Get_Account_with_Customer_Id()
        {
            //Arrange
            var accountRepository = new AccountJsonRepository(@"../../../../MiniBank.Tests/Data/Accounts.json");
            var actualAccounts = accountRepository.GetAccounts(2);

            //Act
            var expected = 3;
            //Assert
            Assert.Equal(expected, actualAccounts.Count);
        }
        [Fact]
        public void Create_Account()
        {
            //Arrange
            var accountRepository = new AccountJsonRepository(@"../../../../MiniBank.Tests/Data/Accounts.json");
            var newAccount = new Account()
            {
                Id = 5,
                Iban = "GE91SB4412587693211001",
                Currency = "GEL",
                Balance = 350,
                CustomerId = 1,
                Name = ""
            };
            //Act
            accountRepository.Create(newAccount);
            var actualAccount = new Account();
            var expected = 5;
            string jsonString = File.ReadAllText(@"../../../../MiniBank.Tests/Data/Accounts.json");
            //Assert
            Assert.Equal(expected, getCount(jsonString));

        }
        [Fact]
        public void Update_Account()
        {
            //Arrange
            var accountRepository = new AccountJsonRepository(@"../../../../MiniBank.Tests/Data/Accounts.json");
            var currentAccount = new Account()
            {
                Id = 5,
                Iban = "GE91SB4412587693000000",
                Currency = "GEL",
                Balance = 3500,
                CustomerId = 1,
                Name = "keti"
            };
            accountRepository.Update(currentAccount);
            var expectedAccount = accountRepository.GetAccount(5);
            Assert.Equal(currentAccount, expectedAccount, new AccountEqulityComparer());
            
        }
        [Fact]
        public void Delete_Account_with_specific_Id()
        {
            //Arrange
            var accountRepository = new AccountJsonRepository(@"../../../../MiniBank.Tests/Data/Accounts.json");
            accountRepository.Delete(2);
            //Act
            var expected = 4;
            string jsonString = File.ReadAllText(@"../../../../MiniBank.Tests/Data/Accounts.json");

            //Assert
            Assert.Equal(expected, getCount(jsonString));
        }

    }
}
