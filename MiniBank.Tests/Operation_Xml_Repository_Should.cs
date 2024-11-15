using MiniBank.Models;
using MiniBank.Repository;
using System.Reflection;

namespace MiniBank.Tests
{
    public class Operation_Xml_Repository_Should
    {
        private readonly string _testFilePath = @"../../../../MiniBank.Tests/Data/Operations.xml";
        private readonly string _jsonFilePath = @"../../../../MiniBank.Tests/Data/Accounts.json";

        [Fact]
        public void Perform_Credit_Operation()
        {
            //Arrange
            var repository = new OperationXmlRepository(_testFilePath, _jsonFilePath);
            var expected = 1;

            var newOperation = new Operation()
            {
                Id = 1,
                AccountId = 4,
                CustomerId = 1,
                Amount = 100,
                Currency = "USD",
                HappendAt = DateTime.Now,
                OperationType = OperationType.Credit
            };

            //Act
            repository.Create(newOperation);
            var actual = repository.GetOperations().Count;

            //Assert
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Perform_Debit_Operation()
        {
            //Arrange
            var repository = new OperationXmlRepository(_testFilePath, _jsonFilePath);
            var expected = 2;

            var newOperation = new Operation()
            {
                Id = 1,
                AccountId = 4,
                CustomerId = 1,
                Amount = 100,
                Currency = "USD",
                HappendAt = DateTime.Now,
                OperationType = OperationType.Debit
            };

            //Act
            repository.Create(newOperation);
            var actual = repository.GetOperations().Count;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_Operation()
        {
            //Arrange
            var repository = new OperationXmlRepository(_testFilePath, _jsonFilePath);
            var expected = 1;


            //Act
            repository.Delete(1);
            var actual = repository.GetOperations().Count;

            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
