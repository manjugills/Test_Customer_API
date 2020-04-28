using CustomerService.Domain.Infrastructure.Utilities;
using CustomerService.Domain.Model.Entities;
using CustomerService.Domain.Model.Repositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.Domain.Infrastructure
{
    public class CustomerRepository :  ICustomerRepository
    {
       
        private string connectionString;

        public CustomerRepository(IConfiguration configuration)
        {

            connectionString = configuration.GetSection("ConnectionString").Value;
        }
      
       
        public async Task<Customer> GetAsync(string key, CancellationToken cancellationToken = default)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                var customer =await connection.QueryFirstOrDefaultAsync<Customer>($"SELECT  [PersonalNumber] ,[Email],[Address],[PhoneNumber]  ,[ModifiedBy] ,[CreatedBy] ,[ModifiedDate],[CreatedDate] FROM [Customer].[dbo].[Customer] where [PersonalNumber]= '{key}'");


                return customer;
            }
            //var jsonSettings = await DbConnection.QuerySingleAsync<string>(
            //   $"SELECT CustomerName FROM Customer WHERE Id = '{key}' ");

            //return jsonSettings;
        }
        public async Task<bool> UpdateAsync(Customer  customer, CancellationToken cancellationToken = default)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
            {
                var rowAffected = await connection.ExecuteAsync($"UPDATE [Customer].[dbo].[Customer] SET  Address = '{customer.Address.Trim()}' " +

                $", ModifiedBy = 'MANJU',  Email = '{customer.Email.Trim()}', PhoneNumber = '{customer.PhoneNumber.Trim()}'" +
                $", ModifiedDate = '{DateTime.UtcNow}'" +
                    $"WHERE PersonalNumber ='{customer.PersonalNumber.Trim()}'");

                return rowAffected > 0;
            }
            }
            catch (Exception e)
            {
                return false;


            }

        }
        public async Task<bool> CreateAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var rowAffected = await connection.ExecuteAsync($"INSERT  INTO [Customer].[dbo].[Customer] ( [PersonalNumber] ,[Email],[Address],[PhoneNumber] ,[CreatedBy] ,[CreatedDate]) VALUES (" +
                    $"'{customer.PersonalNumber.Trim()}','{customer.Email.Trim()}','{customer.Address.Trim()}','{customer.PhoneNumber.Trim()}'" +
                    $",'MANJU', '{DateTime.UtcNow}') ");

                    return rowAffected > 0;
                }
            }
            catch(Exception e)
            {
                return false;


            }
        }
  
    }
}
