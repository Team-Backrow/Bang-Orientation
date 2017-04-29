using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bang_Orientation.Api.DAL.Interface
{
    interface IOrderRepository
    {
        void GetOrder(int OrderID);
        void AllOrders();

    }
}
