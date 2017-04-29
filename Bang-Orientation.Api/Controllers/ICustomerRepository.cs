using Bang_Orientation.Api.Models;

namespace Bang_Orientation.Api.Controllers
{
    public interface ICustomerRepository
    {
        void Save(Customer newCustomer);
        void GetACustomer(Customer customer);
        void GetAllCustomers();
    }
}