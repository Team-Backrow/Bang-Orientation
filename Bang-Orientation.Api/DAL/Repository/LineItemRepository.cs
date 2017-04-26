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
    public class LineItemRepository : ILineItemRepository
    {
        readonly IDbConnection _dbConnection;

        public LineItemRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }

        public void Save(LineItem newItem)
        {
            var sql = @"Insert into LineItem(lineitem, customerorder, product, quantity) Values(@lineitem, @customerorder, @product, @quantity)";

            _dbConnection.Execute(sql, newItem);
        }

        public IEnumerable<LineItem>GetAll()
        {
            var sql = @"Select lineitem, customerorder, product, quantity";

            return _dbConnection.Query<LineItem>(sql);
        }
    }
}