using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;
using Bang_Orientation.Api.Models;

namespace Bang_Orientation.Api.DAL.Repository
{
    public class DuckettRepository 
    {
        IDbConnection _dbConnection;

        public DuckettRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }

        public void Save(Duckett newDuckett)
        {
            var sql = @"Insert into Duckett(duckettsid,duckettstype,accounttype,customerid)
                        Values(@duckettid,@duckettstype,@accounttype,@customerid)";

            _dbConnection.Execute(sql, newDuckett);
        }

        public IEnumerable<Duckett> GetAll()
        {
            var sql = @"Select duckettsid, duckettstype, accounttype, customerid from ducketts";

            return _dbConnection.Query<Duckett>(sql);
        }
    }
}