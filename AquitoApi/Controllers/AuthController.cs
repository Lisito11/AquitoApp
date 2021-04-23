using AquitoApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AquitoApi.Services;
using PasantesBackendApi.Models.Request;
using PasantesBackendApi.Models.Response;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Security.Claims;

namespace AquitoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : CustomBaseController
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<Useraquito> _userManager;
        private readonly SignInManager<Useraquito> _signInManager;
        

        public AuthController(d2bc1ckqeusvkjContext context, IMapper mapper, ITokenService tokenService, SignInManager<Useraquito> signInManager, UserManager<Useraquito> userManager) : base(context, mapper)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // POST auth/login
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0037:Usar nombre de miembro inferido", Justification = "<pendiente>")]
        public async Task<IActionResult> LoginAsync([FromBody] AuthRequest model)
        {
            BaseResponse res = new BaseResponse();

            if (!ModelState.IsValid)
            {

                res.Message = "Payload no valido";
                return BadRequest(res);
            }

            Useraquito existingUser = await _userManager.FindByEmailAsync(model.Email);

            if (existingUser == null)
            {
                res.Message = "Ese email no existe";
                return Unauthorized(res);
            }

            Microsoft.AspNetCore.Identity.SignInResult isValidPassword = await _signInManager.CheckPasswordSignInAsync(existingUser, model.Password, false);

            if (!isValidPassword.Succeeded)
            {
                res.Message = "Contraseña incorrecta";
                return BadRequest(res);

            }

            await _signInManager.SignInAsync(existingUser, true);

            (string token, IEnumerable<string> roles) = await _tokenService.GenerateJwtToken(existingUser);

            res.Message = "Logeado correctamente";
            res.Data = new
            {
                Id = existingUser.Id,
                UserName = existingUser.UserName,
                Email = existingUser.Email,
                Token = token,
                Roles = roles
            };
            res.Ok = true;

            return Ok(res);
        }


        [HttpPost]
        [Route("logout")]
        [AllowAnonymous]
        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return Ok(new BaseResponse
            {
                Ok = true,
                Message = "Se ha cerrado session correctamente."
            });
        }

        [HttpGet]
        [Route("userAuth")]
        public IActionResult UserAuth()
        {

            ClaimsPrincipal userAuth = HttpContext.User;

            return Ok(new BaseResponse
            {
                Ok = true,
                Data = new
                {
                    UserName = userAuth?.Identity?.Name,
                    IsAuthentication = userAuth?.Identity?.IsAuthenticated,
                    Claims = userAuth.Claims.Select(x => new { x.Type, x.Value })
                                            .GroupBy(x => x.Type)
                                            .ToDictionary(c => c.Key, func)
                }
            });
        }


        private Func<IGrouping<string, object>, object> func = (c) => (c.Count() > 1) ? c.ToList() : c.FirstOrDefault();

    }
}
