using MiniBank.Models;
using MiniBank.Repository;
using System.Reflection;

namespace MiniBank.Tests
{
    public class Customer_Csv_Repository_Should
    {
        [Fact]
        public void Get_All_Customers()
        {
            //Arrange
            var customerRepository = new CustomerCsvRepository(@"../../../../MiniBank.Tests/Data/Customers.csv");
            var expected = 2;

            //Act
            var actual = customerRepository.GetCustomers();

            //Assert
            Assert.Equal(expected, actual.Count);
        }

        [Fact]
        public void Get_Single_Customer()
        {
            //Arrange
            var customerRepository = new CustomerCsvRepository(@"../../../../MiniBank.Tests/Data/Customers.csv");
            Customer expected = new()
            {
                Id = 1,
                Name = "Iakob Qobalia",
                IdentityNumber = "31024852345",
                PhoneNumber = "555337681",
                Email = "Iakob.Qobalia@gmail.com",
                Type = Models.CustomerType.Phyisical,
            };

            //Act
            var actual = customerRepository.GetCustomer(1);

            //Assert
            Assert.Equal(expected, actual, new CustomerEqulityComparer());
        }
        [Fact]
        public void Create_New_Customer()
        {
            //Arrange
            Customer newCustomer = new Customer()
            {
                Id=3,
                Name = "Keti",
                IdentityNumber="123",
                PhoneNumber = "123",
                Email = "123",
                Type = Models.CustomerType.Phyisical
            };
            var customerRepository = new CustomerCsvRepository(@"../../../../MiniBank.Tests/Data/Customers.csv");
            customerRepository.Create(newCustomer);
            var expected = 3;

            //Act
            var actual = customerRepository.GetCustomers();

            //Assert
            Assert.Equal(expected, actual.Count);
        }
        [Fact]
        public void Update_Existing_Customer() {
            //Arrange
            
            Customer editedCustomer = new Customer()
            {
                Id = 3,
                Name = "Ketevan",
                IdentityNumber = "123",
                PhoneNumber = "123",
                Email = "123",
                Type = Models.CustomerType.Phyisical
            };
            var customerRepository = new CustomerCsvRepository(@"../../../../MiniBank.Tests/Data/Customers.csv");
            customerRepository.Update(editedCustomer);
            //Act
            var actual = customerRepository.GetCustomer(3);
            //Assert
            Assert.Equal(editedCustomer, actual, new CustomerEqulityComparer());
        }
        [Fact]
        public void Remove_Customer()
        {
            //Arrange
            var customerRepository = new CustomerCsvRepository(@"../../../../MiniBank.Tests/Data/Customers.csv");
            customerRepository.Delete(1);
            var expected = 2;
            //Act
            var actual = customerRepository.GetCustomers();
            //Assert
            Assert.Equal(expected, actual.Count);
        }
    }
}
