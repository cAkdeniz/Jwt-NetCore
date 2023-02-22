using JwtProje.Business.Interfaces;
using JwtProje.Business.StringInfos;
using JwtProje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtProje.WebApi
{
    public static class IdentityInitializer
    {
        public static async Task Seed(IAppUserService appUserService,IAppUserRoleService appUserRoleService,
            IAppRoleService appRoleService)
        {
            var adminRole = await appRoleService.FindByName(RoleInfo.Admin);
            if (adminRole == null)
            {
                await appRoleService.Add(new AppRole() { Name=RoleInfo.Admin });
            }

            var memberRole = await appRoleService.FindByName(RoleInfo.Member);
            if (memberRole == null)
            {
                await appRoleService.Add(new AppRole() { Name = RoleInfo.Member });
            }

            var adminUser = await appUserService.FindByUsername("admin");
            if (adminUser == null)
            {
                await appUserService.Add(new AppUser()
                {
                    UserName = "admin",
                    Password = "1",
                    FullName = "adminadmin"
                });

                var role = await appRoleService.FindByName(RoleInfo.Admin);
                var user = await appUserService.FindByUsername("admin");

                await appUserRoleService.Add(new AppUserRole()
                {
                    AppRoleId = role.Id,
                    AppUserId = user.Id
                });
            }
        }
    }
}
