using Bang_Orientation.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bang_Orientation.Api.DAL.Interface
{
    interface ILineItemRepository
    {
        void Save(LineItem newItem);
        IEnumerable<LineItem> GetAll();
    }
}
