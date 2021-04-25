using AquitoApi.DTOs.Client;
using AquitoApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

namespace AquitoApi.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController: CustomBaseController
    {
        private readonly d2bc1ckqeusvkjContext context;
        private readonly IMapper mapper;
        public ClientController(d2bc1ckqeusvkjContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<ClientDTO>>> Get()
        {
            var usuario = await context.Clients.Include(x => x.Useraquito).Include(x => x.Reservations).ToListAsync();
            return mapper.Map<List<ClientDTO>>(usuario);
        }
        //Metodo Get traer los clientes que deben
        [HttpGet("deben")]
        public async Task<ActionResult<List<ClientDTO>>> GetDeben() {
            var usuario = await context.Clients.Include(x => x.Useraquito).Include(x => x.Reservations.Where(x => x.Status == 1 || x.Status == 3)).ToListAsync();
            return mapper.Map<List<ClientDTO>>(usuario);
        }

        //Metodo Get(id) traer un cliente que debe
        [HttpGet("{id:int}/debe")]
        public async Task<ActionResult<ClientDTO>> GetDebe(int id)
        {
            Client usuario = await context.Clients.Include(x => x.Useraquito).Include(x=> x.Reservations.Where(x => x.Status == 1 || x.Status == 3)).FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<ClientDTO>(usuario);
        }

        [HttpGet("{id:int}", Name = "obtenerCliente")]
        public async Task<ActionResult<ClientDTO>> Get(int id) {
            Client usuario = await context.Clients.Include(x => x.Useraquito).Include(x => x.Reservations).FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<ClientDTO>(usuario);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClientCreacionDTO vehicleCreacionDTO)
        {
            return await Post<ClientCreacionDTO, Client, ClientDTO>(vehicleCreacionDTO, "obtenerCliente");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClientCreacionDTO vehicleCreacionDTO)
        {
            return await Put<ClientCreacionDTO, Client>(id, vehicleCreacionDTO);
        }

        //Metodo Patch
        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, JsonPatchDocument<Client> patchDoc)
        {
            return await Patch<Client, ClientDTO>(id, patchDoc);
        }
    }
}
