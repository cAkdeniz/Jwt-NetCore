using JwtProje.DataAccess.Concrete.EntityFrameworkCore.Context;
using JwtProje.DataAccess.Interfaces;
using JwtProje.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JwtProje.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : EfGenericRepository<AppUser>, IAppUserDal
    {
        public async Task<List<AppRole>> GetRoles(string userName)
        {
            using (var context = new JwtProjeDB())
            {
                var result = from user in context.AppUsers
                             join userRoles in context.AppUserRoles on user.Id equals userRoles.AppUserId
                             join roles in context.AppRoles on userRoles.AppRoleId equals roles.Id
                             where user.UserName == userName
                             select new AppRole()
                             {
                                 Id = roles.Id,
                                 Name = roles.Name
                             };
                return await result.ToListAsync();
            }
        }
    }
}
