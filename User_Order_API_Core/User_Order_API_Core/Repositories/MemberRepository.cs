using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Order_API_Core.CustomModels.ViewModels;
using User_Order_API_Core.Models;

namespace User_Order_API_Core.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AdminModel _adminModel;
        public MemberRepository(AdminModel adminModel)
        {
            this._adminModel = adminModel;
        }

        public MemberOutViewModel CheckLogin(MemberViewModel memberVM)
        {
            var r = _adminModel.Member.FirstOrDefault(x => x.Name == memberVM.Account && x.Password == memberVM.Password);
            if (r == null) return null;

            return new MemberOutViewModel()
            {
                ID = r.Id,
                Account = r.Name
            };
        }
    }
}
