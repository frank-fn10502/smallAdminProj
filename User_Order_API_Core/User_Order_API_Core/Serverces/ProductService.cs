using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Order_API_Core.CustomModels;
using User_Order_API_Core.CustomModels.ViewModels;
using User_Order_API_Core.Repositories;

namespace User_Order_API_Core.Serverces
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repos;
        public ProductService(IProductRepository repos)
        {
            _repos = repos;
        }
        public ResultViewModel GetProductById(string id)
        {
            var r = _repos.GetProductById(id);
            var rvm = new ResultViewModel();
            if (r != null)
            {
                rvm.isSuccess = true;
                rvm.Data = r;
            }
            else
            {
                rvm.isSuccess = false;
                rvm.Exception = "no such product";
            }
            return rvm;
        }
    }
}
