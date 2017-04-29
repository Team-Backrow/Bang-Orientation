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

        public void Save(Order newOrder)
        {
            var sql = @" Insert into Order(OrderTitle, OrderId, DuckettsId, CustomerId)

                   values(@ordertitle, @orderid, @duckettsid, @customerid) ";

            _dbConnection.Execute(sql, newOrder);
        }
    }
}