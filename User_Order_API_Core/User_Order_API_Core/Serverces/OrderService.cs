using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Order_API_Core.CustomModels;
using User_Order_API_Core.CustomModels.ViewModels;
using User_Order_API_Core.Enum;
using User_Order_API_Core.Repositories;

namespace User_Order_API_Core.Serverces
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repos;
        public OrderService(IOrderRepository repos)
        {
            this._repos = repos;
        }
        public ResultViewModel GetAllFullOrder()
        {
            ResultViewModel r = new ResultViewModel();
            var data = _repos.GetAllFullOrder();
            try
            {
                r.isSuccess = true;
                r.Data = data;
            }
            catch (Exception e)
            {
                r.isSuccess = false;
                r.Exception = e.ToString();
            }
            return r;
        }

        public ResultViewModel UpdateOrder(IEnumerable<OrderViewModel> vms)
        {
            return new ResultViewModel()
            {
                isSuccess = _repos.UpdateOrder(vms)
            };
        }
    }
}
