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
        List<Cart> GetProductsFromCart(int userId);
        List<Order> GetOrderListForCustomer(int user_id);
        void SaveProductInCart(int user_id, int product_id);
        void DeleteProductFromCart(int userId, int productId);
        void ClearCartAfterCalculateOrderCost(int userId);
        void UpdateProductCountInCart(int userId, int productId, int newCount);
        decimal CalculateOrderCost(int userId);
        int CreateOrder(int userId, List<int> productIds, List<int> productCounts);
        void UpdateOrderStatus(int orderId, string newStatus, string role);
    }
}
