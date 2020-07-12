using User_Order_API_Core.CustomModels.ViewModels;

namespace User_Order_API_Core.Repositories
{
    public interface IProductRepository
    {
        ProductViewModel GetProductById(string id);
    }
}