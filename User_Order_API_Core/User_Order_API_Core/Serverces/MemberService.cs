using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Order_API_Core.CustomModels;
using User_Order_API_Core.CustomModels.ViewModels;
using User_Order_API_Core.Repositories;

namespace User_Order_API_Core.Serverces
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _repos;

        public MemberService(IMemberRepository repos)
        {
            this._repos = repos;
        }

        public ResultViewModel CheckLogin(MemberViewModel memberVM)
        {
            var r = _repos.CheckLogin(memberVM);
            var rvm = new ResultViewModel();
            if (r == null)
            {
                rvm.isSuccess = false;
                rvm.Exception = "no such guy!!";
            }
            else
            {
                rvm.isSuccess = true;
                rvm.Data = r.ID;
            }
            return rvm;
        }
    }
}
