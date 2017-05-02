using System.Collections.Generic;
using Bang_Orientation.Api.Models;

namespace Bang_Orientation.Api.Controllers
{
    public interface ICustomerRepository
    {
        void Save(Customer newCustomer);
        Customer DeleteACustomer(int id);
        Customer GetACustomer(int id);
        IEnumerable<Customer> GetAllCustomers();
    }
}