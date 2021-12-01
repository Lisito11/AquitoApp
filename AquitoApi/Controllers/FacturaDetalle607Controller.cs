
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
    [Route("api/detallefactura607")]
    public class FacturaDetalle607Controller: CustomBaseController
    {
        private readonly d2bc1ckqeusvkjContext context;
        private readonly IMapper mapper;
        public FacturaDetalle607Controller(d2bc1ckqeusvkjContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<FacturaDetalle607DTO>>> Get()
        {
            var facturas = await context.FacturaDetalles607s.ToListAsync();
            return mapper.Map<List<FacturaDetalle607DTO>>(facturas);
        }

        [HttpGet("{id:int}", Name = "obtenerFacturaDetalle607")]
        public async Task<ActionResult<FacturaDetalle607DTO>> Get(int id)
        {
            FacturaDetalle607 factura = await context.FacturaDetalles607s.FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<FacturaDetalle607DTO>(factura);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FacturaDetalle607CreacionDTO facturaDetalle607CreacionDTO)
        {
            return await Post<FacturaDetalle607CreacionDTO, FacturaDetalle607, FacturaDetalle607DTO>(facturaDetalle607CreacionDTO, "obtenerFacturaDetalle607");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] FacturaDetalle607CreacionDTO facturaDetalle607CreacionDTO)
        {
            return await Put<FacturaDetalle607CreacionDTO, FacturaDetalle607>(id, facturaDetalle607CreacionDTO);
        }

        //Metodo Patch
        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, JsonPatchDocument<FacturaDetalle607> patchDoc)
        {
            return await Patch<FacturaDetalle607, FacturaDetalle607DTO>(id, patchDoc);
        }
    }
}
