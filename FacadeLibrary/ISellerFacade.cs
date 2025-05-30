using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeLibrary
{
    public interface ISellerFacade
    {
        List<Order> GetOrderListForEmployes();
        List<Product> GetProductListInOrder(int order_id);
        void UpdateOrderStatus(int orderId, string newStatus,string role);
    }
}
