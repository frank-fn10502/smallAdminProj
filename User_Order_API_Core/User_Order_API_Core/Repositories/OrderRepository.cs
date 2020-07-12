using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using User_Order_API_Core.CustomModels.ViewModels;
using User_Order_API_Core.Enum;
using User_Order_API_Core.Models;

namespace User_Order_API_Core.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AdminModel _adminModel;
        public OrderRepository(AdminModel adminModel)
        {
            this._adminModel = adminModel;
        }
        public IEnumerable<OrderViewModel> GetAllFullOrder()
        {
            var result = from o in _adminModel.Order
                         join p in _adminModel.Product on o.Pid equals p.Id
                         select new { o, p };

            return result.Select(x => new OrderViewModel()
            {
                Id = x.o.Id,
                Pid = x.o.Pid,
                Pname = x.p.Name,
                Price = x.o.Price,
                Cost = x.o.Cost,
                Status = x.o.Status,
            });
            //return null;
        }

        public bool UpdateOrder(IEnumerable<OrderViewModel> vms)
        {
            var result = true;
            using (var transaction = _adminModel.Database.BeginTransaction())
            {
                try
                {
                    var soCounter = _adminModel.ShippingOrder.Count();
                    foreach (var so in _adminModel.ShippingOrder)
                    {
                        so.Status = "";
                    }

                    foreach (var vm in vms)
                    {
                        var target = _adminModel.Order.FirstOrDefault(x => x.Id == vm.Id);
                        target.Status = vm.Status;

                        ShippingOrder so = new ShippingOrder()
                        {
                            Id = $"SS{++soCounter}",
                            OrderId = target.Id,
                            Status = "New",
                            CreateDateTime = DateTime.Now,
                        };
                        _adminModel.Entry(so).State = EntityState.Added;
                    }

                    _adminModel.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    transaction.Rollback();
                    result = false;
                    throw e;
                }
            }
            return result;
        }
    }
}
