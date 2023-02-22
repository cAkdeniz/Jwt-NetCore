using JwtProje.Entities;
using JwtProje.Entities.DTOs.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JwtProje.Business.Interfaces
{
    public interface IAppUserService: IGenericService<AppUser>
    {
        Task<AppUser> FindByUsername(string userName);
        Task<bool> CheckPassword(AppUserLoginDto appUserLoginDto);
        Task<List<AppRole>> GetRoles(string userName);
    }
}
