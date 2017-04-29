using Bang_Orientation.Api.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bang_Orientation.Api.Models;
using System.Data;
using Dapper;

namespace Bang_Orientation.Api.DAL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        IDbConnection _dbConnection;
        public OrderRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }

        public Order GetById(int id)
        {     
            var sql = @"Select * From [Order] Where OrderId = @id";
            var singleOrder = _dbConnection.QuerySingle<Order>(sql, new { id = id });

            return singleOrder;
        }

        public IEnumerable<Order> AllOrders()
        {
            var sql = @"Select * From [Order]";
            var allOrders = _dbConnection.Query<Order>(sql);

            return allOrders;
        }

        public void Save(Order newOrder)
        {
            var sql = @" Insert into [Order](OrderTitle, DuckettsId, CustomerId)

                   values(@ordertitle, @duckettsid, @customerid) ";

            _dbConnection.Execute(sql, newOrder);
        }

        public Order Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}