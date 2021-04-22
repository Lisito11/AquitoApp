using AquitoApi.Entities;
using AquitoApi.Entities.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PasantesBackendApi.Models.Response;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AquitoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<Roleaquito> _roleManager;
        private readonly d2bc1ckqeusvkjContext _context;

        public RoleController(RoleManager<Roleaquito> roleManager, d2bc1ckqeusvkjContext context)
        {
            _roleManager = roleManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Roles.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoleRequest model)
        {

            BaseResponse res = new BaseResponse();

            if (!ModelState.IsValid)
            {
                res.Message = "Payload es valido.";
                return BadRequest(res);
            }
            
            // Verificar si el role existe
            bool roleExist  = await _roleManager.RoleExistsAsync(model.Role);

            if (roleExist)
            {
                res.Message = String.Format("El Role '{0}' ya existe.", model.Role);
                return BadRequest(res);
            }

            // Crear role
            Roleaquito role = new Roleaquito() { Name = model.Role, NormalizedName = model.Role.ToUpper() };

            if(model.ConcurrencyStamp != null)
            {
                role.ConcurrencyStamp = model.ConcurrencyStamp;
            }
                
            IdentityResult isRoleCreated = await _roleManager.CreateAsync(role);

            if (!isRoleCreated.Succeeded)
            {
                res.Message = isRoleCreated.Errors.Select(x => x.Description).FirstOrDefault();
                return new JsonResult(res) { StatusCode = 500 };
            }

            res.Message = "Role fue creado correctamente";
            res.Ok = true;

            return Ok(res);
            
        }
    }
}
