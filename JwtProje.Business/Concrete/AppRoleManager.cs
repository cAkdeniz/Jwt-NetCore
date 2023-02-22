using JwtProje.Business.Interfaces;
using JwtProje.DataAccess.Interfaces;
using JwtProje.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JwtProje.Business.Concrete
{
    public class AppRoleManager: GenericManager<AppRole>, IAppRoleService
    {
        private IAppRoleDal _appRoleDal;
        public AppRoleManager(IGenericDal<AppRole> genericDal, IAppRoleDal appRoleDal) : base(genericDal)
        {
            _appRoleDal = appRoleDal;
        }

        public async Task<AppRole> FindByName(string roleName)
        {
            return await _appRoleDal.GetByFilter(x => x.Name == roleName);
        }
    }
}
