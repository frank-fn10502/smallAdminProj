using System.Collections.Generic;
using User_Order_API_Core.CustomModels;
using User_Order_API_Core.CustomModels.ViewModels;

namespace User_Order_API_Core.Serverces
{
    public interface IOrderService
    {
        ResultViewModel GetAllFullOrder();
        ResultViewModel UpdateOrder(IEnumerable<OrderViewModel> vm);
    }
}