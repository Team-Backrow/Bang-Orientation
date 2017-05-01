using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Bang_Orientation.Api.Controllers;
using Bang_Orientation.Api.Models;
using Dapper;

namespace Bang_Orientation.Api.DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        readonly IDbConnection _dbConnection;

        public CustomerRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }
        public void Save(Customer newCustomer)
        {
            var sql = @"Insert into Customer(username,firstname,lastname,password)
                        Values(@username,@firstname,@lastname,@password)";

            _dbConnection.Execute(sql, newCustomer);
                        
        }

        public Customer GetACustomer(int id)
        {
            var sql = @"Select from Customer Where @customerid = @id";
            var singleCustomer = _dbConnection.QuerySingle<Customer>(sql, id);


            return singleCustomer;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var sql = @"Select customerid,username,firstname,lastname,password from Customer";

            return _dbConnection.Query<Customer>(sql);
        }

    }
}