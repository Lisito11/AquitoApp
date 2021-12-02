using AquitoApi.DTOs.Facturas606;
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
    [Route("api/factura606")]
    public class Factura606Controller : CustomBaseController
    {
        private readonly d2bc1ckqeusvkjContext context;
        private readonly IMapper mapper;
        public Factura606Controller(d2bc1ckqeusvkjContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<Factura606DTO>>> Get()
        {
            var facturas = await context.Factura606s.Include(x => x.FacturasDetalle606).ToListAsync();
            return mapper.Map<List<Factura606DTO>>(facturas);
        }
        
        [HttpGet("{id:int}", Name = "obtenerFactura606")]
        public async Task<ActionResult<Factura606DTO>> Get(int id)
        {
            Factura606 factura = await context.Factura606s.Include(x => x.FacturasDetalle606).FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<Factura606DTO>(factura);
        }
        [HttpGet("search/{mes:int}/{age}", Name = "obtenerFt606")]
        public async Task<ActionResult<Factura606DTO>> GetSearch(int mes, string age)
        {
            Factura606 factura = await context.Factura606s.FirstOrDefaultAsync(x => x.Mes == mes && x.Age == age);
            return mapper.Map<Factura606DTO>(factura);
        }
        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Factura606CreacionDTO factura606CreacionDTO)
        {
            return await Post<Factura606CreacionDTO, Factura606, Factura606DTO>(factura606CreacionDTO, "obtenerFactura606");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Factura606CreacionDTO factura606CreacionDTO)
        {
            return await Put<Factura606CreacionDTO, Factura606>(id, factura606CreacionDTO);
        }

        //Metodo Patch
        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, JsonPatchDocument<Factura606> patchDoc)
        {
            return await Patch<Factura606, Factura606DTO>(id, patchDoc);
        }
    }
}
