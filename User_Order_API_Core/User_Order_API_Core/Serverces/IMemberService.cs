using User_Order_API_Core.CustomModels;
using User_Order_API_Core.CustomModels.ViewModels;

namespace User_Order_API_Core.Serverces
{
    public interface IMemberService
    {
        ResultViewModel CheckLogin(MemberViewModel memberVM);
    }
}