using JwtProje.Business.Interfaces;
using JwtProje.DataAccess.Interfaces;
using JwtProje.Entities;
using JwtProje.Entities.DTOs.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JwtProje.Business.Concrete
{
    public class AppUserManager: GenericManager<AppUser>, IAppUserService
    {
        private IAppUserDal _appUserDal;
        public AppUserManager(IGenericDal<AppUser> genericDal,IAppUserDal appUserDal) : base(genericDal)
        {
            _appUserDal = appUserDal;
        }

        public async Task<bool> CheckPassword(AppUserLoginDto appUserLoginDto)
        {
            var appuser = await _appUserDal.GetByFilter(x => x.UserName == appUserLoginDto.UserName);
            if (appuser.Password == appUserLoginDto.Password)
            {
                return true;
            }
            return false;
        }

        public async Task<AppUser> FindByUsername(string userName)
        {
            return await _appUserDal.GetByFilter(x => x.UserName == userName);
        }

        public async Task<List<AppRole>> GetRoles(string userName)
        {
            return await _appUserDal.GetRoles(userName);
        }
    }
}
