using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeLibrary
{
    public interface ICustomerFacade
    {
        List<Product> GetProductList();
        List<Product> GetProductListInOrder(int order_id);
        void RegistrationCustomer(string firstName, string lastName, string phone, string password);
    }
}
