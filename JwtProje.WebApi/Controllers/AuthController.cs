using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using JwtProje.Business.Interfaces;
using JwtProje.Business.Jwt;
using JwtProje.Business.StringInfos;
using JwtProje.Entities;
using JwtProje.Entities.DTOs.AppUserDtos;
using JwtProje.Entities.Token;
using JwtProje.WebApi.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtProje.WebApi.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IJwtService _jwtService;
        private IMapper _mapper;
        private IAppUserService _appUserService;
        public AuthController(IJwtService jwtService, IMapper mapper, IAppUserService appUserService)
        {
            _appUserService = appUserService;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var appUser = await _appUserService.FindByUsername(appUserLoginDto.UserName);
            if (appUser == null)
            {
                return BadRequest("Kullanıcı Adı veya Şifre Hatalı");
            }
            else
            {
                if (await _appUserService.CheckPassword(appUserLoginDto))
                {
                    var roles = await _appUserService.GetRoles(appUserLoginDto.UserName);
                    var token = _jwtService.CreateToken(appUser, roles);
                    JwtAccessToken jwtAccessToken = new JwtAccessToken();
                    jwtAccessToken.Token = token;
                    return Created("", jwtAccessToken);
                }
                return BadRequest("Kullanıcı Adı veya Şifre Hatalı");
            }
        }

        [HttpPost("[action]")]
        [ValidModel]
        public async Task<IActionResult> SignUp(AppUserAddDto appUserAddDto,[FromServices] IAppUserRoleService appUserRoleService,
            [FromServices] IAppRoleService appRoleService)
        {
            var appUser = await _appUserService.FindByUsername(appUserAddDto.UserName);
            if (appUser != null)
            {
                return BadRequest("Bu kullanıcı adı kullanılıyor.");
            }
            await _appUserService.Add(_mapper.Map<AppUser>(appUserAddDto));

            var user = await _appUserService.FindByUsername(appUserAddDto.UserName);
            var role = await appRoleService.FindByName(RoleInfo.Member);

            await appUserRoleService.Add(new AppUserRole
            {
                AppRoleId = role.Id,
                AppUserId = user.Id
            });

            return Created("", appUserAddDto);
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> ActiveUser()
        {
            var user = await _appUserService.FindByUsername(User.Identity.Name);
            var roles = await _appUserService.GetRoles(User.Identity.Name);

            AppUserDto appUserDto = new AppUserDto
            {
                FullName = user.FullName,
                UserName = user.UserName,
                Roles = roles.Select(x=>x.Name).ToList()
            };

            return Ok(appUserDto);
        }
    }
}