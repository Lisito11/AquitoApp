using AquitoApi.DTOs.Client;
using AquitoApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AquitoApi.Services;
using PasantesBackendApi.Models.Request;
using PasantesBackendApi.Models.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AquitoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : CustomBaseController
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<Useraquito> _userManager;

        public AuthController(d2bc1ckqeusvkjContext context, IMapper mapper, ITokenService tokenService, UserManager<Useraquito> userManager) : base(context, mapper)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }


        

            // POST auth/login
            [HttpPost]
        [Route("login")]
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
                res.Message = "Solicitud de Autenticacion Invalida";
                return Unauthorized(res);
            }

            bool isValidPassword = await _userManager.CheckPasswordAsync(existingUser, model.Password);

            if (!isValidPassword)
            {
                res.Message = "Contraseña incorrecta";
                return Unauthorized(res);

            }

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
    }


}
