using User_Order_API_Core.CustomModels;

namespace User_Order_API_Core.Serverces
{
    public interface IProductService
    {
        ResultViewModel GetProductById(string id);
    }
}