using AquitoApi.DTOs.Client;
using AquitoApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

            return await Get<Client, ClientDTO>();
        }

        //Metodo Get(id)
        [HttpGet("{id:int}", Name = "obtenerCliente")]
        public async Task<ActionResult<ClientDTO>> Get(int id)
        {
            Client usuario = await context.Clients.Include(x => x.Useraquito).FirstOrDefaultAsync(x => x.Id == id);
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
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Patch(int id)
        {
            return await Patch<Client, ClientDTO>(id);
        }
    }
}
