using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeLibrary
{
    public interface IWarehouserFacade
    {
        List<Product> GetProductList();
        List<Order> GetOrderListForEmployes();
        List<Product> GetProductListInOrder(int order_id);
    }
}
