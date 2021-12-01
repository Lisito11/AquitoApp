
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
    [Route("api/detallefactura606")]
    public class FacturaDetalle606Controller : CustomBaseController
    {
        private readonly d2bc1ckqeusvkjContext context;
        private readonly IMapper mapper;
        public FacturaDetalle606Controller(d2bc1ckqeusvkjContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<FacturaDetalle606DTO>>> Get()
        {
            var facturas = await context.FacturaDetalles606s.ToListAsync();
            return mapper.Map<List<FacturaDetalle606DTO>>(facturas);
        }

        [HttpGet("{id:int}", Name = "obtenerFacturaDetalle606")]
        public async Task<ActionResult<FacturaDetalle606DTO>> Get(int id)
        {
            FacturaDetalle606 factura = await context.FacturaDetalles606s.FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<FacturaDetalle606DTO>(factura);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FacturaDetalle606CreacionDTO facturaDetalle606CreacionDTO)
        {
            return await Post<FacturaDetalle606CreacionDTO, FacturaDetalle606, FacturaDetalle606DTO>(facturaDetalle606CreacionDTO, "obtenerFacturaDetalle606");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] FacturaDetalle606CreacionDTO facturaDetalle606CreacionDTO)
        {
            return await Put<FacturaDetalle606CreacionDTO, FacturaDetalle606>(id, facturaDetalle606CreacionDTO);
        }

        //Metodo Patch
        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, JsonPatchDocument<FacturaDetalle606> patchDoc)
        {
            return await Patch<FacturaDetalle606, FacturaDetalle606DTO>(id, patchDoc);
        }
    }
}
