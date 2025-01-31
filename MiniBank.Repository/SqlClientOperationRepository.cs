using Microsoft.Data.SqlClient;
using MiniBank.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Repository
{
    public class SqlClientOperationRepository
    {
        //TODO
        //--1. გადარიცხვა
        //	--1.1 ერთი ანგარიში update.
        //	--1.2 მეორე ანგარიშის update.
        //	--1.3 ახალი ოპერაციის insert(2)
        private const string _connectionString = "Server=DESKTOP-JMDSV2Q\\SQLEXPRESS;Database=MiniBankBCMFH20NC;Trusted_Connection=true;TrustServerCertificate=true";


        public async Task Transfer(int senderId, int recipientId, decimal amount)
        {
            using (SqlConnection connection = new(_connectionString))
            {
                await connection.OpenAsync();
                await BalanceUpdate(senderId, -amount);
                await BalanceUpdate(recipientId, amount);
            }
        }

        public async Task BalanceUpdate(int accountId, decimal amount)
        {
            using (SqlConnection connection = new(_connectionString))
            {
                using (SqlCommand command = new("spUpdateBalance", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@accountId", accountId);
                    command.Parameters.AddWithValue("@balance", amount);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task CreateOperation(Operation operation, Account? recipient = null)
        {
            string commandText = "spCreateOperation";
            using (SqlConnection connection = new(_connectionString))
            {
                using (SqlCommand command = new(commandText, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();

                    command.Parameters.AddWithValue("operationType", operation.OperationType);
                    command.Parameters.AddWithValue("currency", operation.Currency);
                    command.Parameters.AddWithValue("amount", operation.Amount);
                    command.Parameters.AddWithValue("happendAt", operation.HappendAt);
                    command.Parameters.AddWithValue("accountId", operation.AccountId);
                }
                if(operation.OperationType == OperationType.Transfer) {
                    await Transfer(operation.AccountId, recipient.Id, operation.Amount);
                }
            }
        }

        //--2. განაღდება
        //	--1.1 ერთი ანგარიშის update.
        //	--1.2 ახალი ოპერაციის insert(1)
        public async Task Debit(Account account, decimal amount)
        {
            using (SqlConnection connection = new(_connectionString))
            {
                await connection.OpenAsync();
                await BalanceUpdate(account.Id, -amount);
                var operation = new Operation
                {
                    OperationType = OperationType.Debit, 
                    Currency = account.Currency,
                    Amount = amount,
                    HappendAt = DateTime.Now,
                    AccountId = account.Id
                };
                await CreateOperation(operation);
            }
        }

        //--3. თანხის შეტანა
        //	--1.1 ერთი ანგარიშის update.
        //	--1.2 ახალი ოპერაციის insert(1)
        public async Task Credit(Account account, decimal amount)
        {
            using (SqlConnection connection = new(_connectionString))
            {
                await connection.OpenAsync();
                await BalanceUpdate(account.Id, amount);
                var operation = new Operation
                {
                    OperationType = OperationType.Credit, 
                    Currency = account.Currency,
                    Amount = amount,
                    HappendAt = DateTime.Now,
                    AccountId = account.Id
                };
                await CreateOperation(operation);
            }
        }
    }
}
