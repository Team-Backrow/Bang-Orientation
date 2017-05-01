using Bang_Orientation.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bang_Orientation.Api.DAL.Repository
{
    public interface IOrderRepository
    {
        void Save(Order newOrder);
        Order GetSingleOrder(int id);
        IEnumerable<Order> AllOrders();
        Order Delete(int id);
        void Edit(Order updatedOrder);
    }
}
