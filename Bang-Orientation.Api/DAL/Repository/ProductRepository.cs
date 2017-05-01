using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using Bang_Orientation.Api.DAL.Interface;
using Bang_Orientation.Api.Models;
using Dapper;

namespace Bang_Orientation.Api.DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        IDbConnection _dbConnection;
        private readonly object productId;

        public ProductRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }

        public void Save(Product newProduct)
        {
            var sql = @"Insert into Product(name, brand, description, price)
                            values(@name, @brand, @description, @price)";


            _dbConnection.Execute(sql, newProduct);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var sql = @"Select name, brand, description, price from Product";

            return _dbConnection.Query<Product>(sql);
        }

        public Product GetSingleProduct(int productId)
        {
            var sql = @"Select productId, name, brand, description, price from Product where productId = @productId";

            return _dbConnection.QueryFirstOrDefault<Product>(sql, new {productId});
        }

        public bool DeleteSingleProduct(int productId)
        {
            var sql = @"Delete from Product where productId = @productId";


            return 0< _dbConnection.Execute(sql, new {productId});
        }

        public bool UpdateAProduct(Product updateProduct)
        {
            var sql = @"Update Product set name = @name, brand = @brand, description = @description, price = @price where productId = @productId";

            return 0< _dbConnection.Execute(sql, updateProduct);
        }      
    }
}
