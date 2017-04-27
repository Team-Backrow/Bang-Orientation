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

        public IHttpActionResult GetSingleProduct(Product productId)
        {
            throw new NotImplementedException();
        }

        //public IHttpActionResult GetSingleProduct()
        //{
        //    var product = IEnumerable<Product>.FirstOrDefault((p) => p.ProductId == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(product);
        //}
    }
}
