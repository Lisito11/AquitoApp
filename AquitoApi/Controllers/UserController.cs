using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AquitoApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using AquitoApi.Entities.Request;
using PasantesBackendApi.Models.Response;
using AquitoApi.Services;
using Microsoft.AspNetCore.JsonPatch;

namespace AquitoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : CustomBaseController
    {

        private readonly UserManager<Useraquito> _userManager;
        private readonly RoleManager<Roleaquito> _roleManager;
        private readonly d2bc1ckqeusvkjContext _context;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

      
        public UserController(d2bc1ckqeusvkjContext context, IMapper mapper, UserManager<Useraquito> userManager, RoleManager<Roleaquito> roleManager, ITokenService tokenService): base(context, mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _tokenService = tokenService;
            _roleManager = roleManager;
        }

        // GET api/[cotroller]/users
        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Useraquitos.ToListAsync());
        }



        // POST: Useraquitoes/api/[controller]/register
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("register")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0037:Usar nombre de miembro inferido", Justification = "<pendiente>")]
        public async Task<IActionResult> Register([FromBody] UserRequest model)
        {

            BaseResponse res = new BaseResponse();

            if (!ModelState.IsValid)
            {
                res.Message = "Payload no valido";

                return BadRequest(res);
            }

            // chequear que el email exista
            Useraquito existingUser = await _userManager.FindByEmailAsync(model.Email);

            if (existingUser != null)
            {
                res.Message = "Email ya existe";
                return BadRequest(res);
            }

            // Chequear si existe el role enviado
            bool existingRole = await _roleManager.RoleExistsAsync(model.Role);

            if (!existingRole)
            {
                res.Message = $"Role '{model.Role}' no existe, ponga un rol valido";
                return BadRequest(res);
            }

            // Crear Usuario
            var user = _mapper.Map<Useraquito>(model);

            IdentityResult isUserCreated = await _userManager.CreateAsync(user, model.Password);

            if (!isUserCreated.Succeeded)
            {
                res.Message = isUserCreated.Errors.Select(x => x.Description).FirstOrDefault();

                return new JsonResult(res) { StatusCode = 500 };
            }


            // Agregar role
            IdentityResult isAddedRole = await _userManager.AddToRoleAsync(user, model.Role);

            if (!isAddedRole.Succeeded)
            {
                res.Message = isAddedRole.Errors.Select(x => x.Description).FirstOrDefault();

                return new JsonResult(res) { StatusCode = 500 };
            }

            (string token, IEnumerable<string> roles) = await _tokenService.GenerateJwtToken(user);

            res.Message = "Usuario creado correctamente";
            res.Ok = true;
            res.Data = new { 
                Token = token,
                Roles = roles,
                UserName = user.UserName,
                FirstName =user.Firstname,
                LastName = user.Lastname,
                Phone = user.Phone,
                Id = user.Id
                       
            };

            return Ok(res);

        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id) {
            var usuario = await _context.Useraquitos.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(usuario);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Useraquito model) {
            var entidad = model;
            entidad.Id = id;
            _context.Entry(entidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //Metodo Patch
        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, JsonPatchDocument<Useraquito> patchDoc) {

            if (patchDoc == null) {
                return BadRequest();
            }

            var entidadEdit = await _context.Set<Useraquito>().FirstOrDefaultAsync(x => x.Id == id);

            if (entidadEdit == null) {
                return NotFound();
            }

            patchDoc.ApplyTo(entidadEdit, ModelState);

            var isValid = TryValidateModel(entidadEdit);

            if (!isValid) {
                return BadRequest(ModelState);
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
