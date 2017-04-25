using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Bang_Orientation.Api.Models;
using Dapper;

namespace Bang_Orientation.Api.DAL.Repository
{
    public class ProductRepository
    {
        IDbConnection _dbConnection;

        public ProductRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }

        public void Save(Product NewProduct)
        {
            var sql = @"Insert into Product(name, brand, description, price)
                            values(@name, @brand, @description, @price)";


            _dbConnection.Execute(sql, NewProduct);
        }
    }
}
