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
        void UpdateOrderStatus(int orderId, string newStatus, string role);
        List<Status> GetStatusList();
        void AddShipment(int productId, int shipperId, int productCount);
        List<Shipper> GetShippers();
        List<Shipment> GetShipmentList();
    }
}
