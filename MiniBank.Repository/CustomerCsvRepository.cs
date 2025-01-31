using MiniBank.Models;
using System.Collections.Generic;
using System.Reflection;

namespace MiniBank.Repository
{
    public class CustomerCsvRepository
    {
        private readonly string _filePath;
        private List<Customer> _customers;

        public CustomerCsvRepository(string filePath)
        {
            _filePath = filePath;
            _customers = LoadData();
        }

        public List<Customer> GetCustomers() => _customers;
        public Customer GetCustomer(int id) => _customers.FirstOrDefault(person => person.Id == id);

        public void Create(Customer customer)
        {
            if (_customers.All(c => c.Id != customer.Id))
            {
                _customers.Add(customer);
                SaveData();
            }

        }

        public void Update(Customer customer)
        {
            var currentCustomer = _customers.FirstOrDefault(c => c.Id == customer.Id);
            if (currentCustomer != null)
            {
                currentCustomer.Name = customer.Name;
                currentCustomer.IdentityNumber = customer.IdentityNumber;
                currentCustomer.PhoneNumber = customer.PhoneNumber;
                currentCustomer.Email = customer.Email;
                currentCustomer.Type = customer.Type;

                SaveData();
            }
        }

        public void Delete(int id)
        {
            var removedCustomer = _customers.FirstOrDefault(c => c.Id == id);
            if (removedCustomer != null)
            {
                _customers.Remove(removedCustomer);
                SaveData();
            }


        }

        private void SaveData()
        {
            /*
            var lines = new List<string>() { "Id,Name,IdentityNumber,PhoneNumber,Email,Type" };
            lines.AddRange(_customers.Select(customer => $"{customer.Id},{customer.Name},{customer.IdentityNumber},{customer.PhoneNumber},{customer.Email},{customer.Type}"));
            File.WriteAllLines(_filePath, lines);
            */

            using (StreamWriter sw = new StreamWriter(_filePath, false))
            {
                var lines = new List<string>() { "Id,Name,IdentityNumber,PhoneNumber,Email,Type" };
                lines.AddRange(_customers.Select(customer => $"{customer.Id},{customer.Name},{customer.IdentityNumber},{customer.PhoneNumber},{customer.Email},{customer.Type}"));
                foreach (var line in lines) { 
                sw.WriteLine(line);
                }
            }


        }

        private List<Customer> LoadData()
        {
            if (!File.Exists(_filePath))
                return new List<Customer>();

            return File
                .ReadAllLines(_filePath)
                .Skip(1)
                .Select(line => line.Split(','))
                .Select(parts => new Customer
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1],
                    IdentityNumber = parts[2],
                    PhoneNumber = parts[3],
                    Email = parts[4],
                    Type = Enum.Parse<Models.CustomerType>(parts[5])
                }).ToList();
        }
    }
}
