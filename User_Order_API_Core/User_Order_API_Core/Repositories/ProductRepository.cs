using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Order_API_Core.CustomModels.ViewModels;
using User_Order_API_Core.Models;

namespace User_Order_API_Core.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AdminModel _adminModel;
        public ProductRepository(AdminModel adminModel)
        {
            _adminModel = adminModel;
        }
        public ProductViewModel GetProductById(string id)
        {
            var result = from p in _adminModel.Product
                         select p;

            result = result.Where(x => x.Id == id);
            return result.Select(x => new ProductViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price
            }).FirstOrDefault();
            //return null;
        }
    }
}
