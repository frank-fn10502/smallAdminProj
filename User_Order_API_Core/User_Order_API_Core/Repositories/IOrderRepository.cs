using System.Collections.Generic;
using User_Order_API_Core.CustomModels.ViewModels;

namespace User_Order_API_Core.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<OrderViewModel> GetAllFullOrder();
        bool UpdateOrder(IEnumerable<OrderViewModel> vm);
    }
}