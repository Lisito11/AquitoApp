using AquitoApi.DTOs.Facturas607;
using AquitoApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AquitoApi.Controllers
{
    [ApiController]
    [Route("api/factura607")]
    public class Factura607Controller : CustomBaseController
    {
        private readonly d2bc1ckqeusvkjContext context;
        private readonly IMapper mapper;
        public Factura607Controller(d2bc1ckqeusvkjContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<Factura607DTO>>> Get()
        {
            var facturas = await context.Factura607s.Include(x => x.FacturasDetalle607).ToListAsync();
            return mapper.Map<List<Factura607DTO>>(facturas);
        }

        

        [HttpGet("{id:int}", Name = "obtenerFactura607")]
        public async Task<ActionResult<Factura607DTO>> Get(int id)
        {
            Factura607 factura = await context.Factura607s.Include(x => x.FacturasDetalle607).FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<Factura607DTO>(factura);
        }

        [HttpGet("search/{mes:int}/{age}", Name = "obtenerFt607")]
        public async Task<ActionResult<Factura607DTO>> GetSearch(int mes, string age)
        {
            Factura607 factura = await context.Factura607s.FirstOrDefaultAsync(x => x.Mes == mes && x.Age == age);
            return mapper.Map<Factura607DTO>(factura);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Factura607CreacionDTO factura607CreacionDTO)
        {
            return await Post<Factura607CreacionDTO, Factura607, Factura607DTO>(factura607CreacionDTO, "obtenerFactura607");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Factura607CreacionDTO factura607CreacionDTO)
        {
            return await Put<Factura607CreacionDTO, Factura607>(id, factura607CreacionDTO);
        }

        //Metodo Patch
        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, JsonPatchDocument<Factura607> patchDoc)
        {
            return await Patch<Factura607, Factura607DTO>(id, patchDoc);
        }
    }
}
