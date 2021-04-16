using AquitoApi.DTOs.TypeVehicle;
using AquitoApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquitoApi.Controllers {
    [ApiController]
    [Route("api/tipovehiculo")]
    public class TypeVehicleController: CustomBaseController {
        private readonly d2bc1ckqeusvkjContext context;
        private readonly IMapper mapper;

        public TypeVehicleController(d2bc1ckqeusvkjContext context, IMapper mapper) : base(context, mapper) {
            this.context = context;
            this.mapper = mapper;
        }
        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<TypevehicleDTO>>> Get() {
            return await Get<Typevehicle, TypevehicleDTO>();
        }

        //Metodo Get(id)
        [HttpGet("{id:int}", Name = "obtenerTipoVehiculo")]
        public async Task<ActionResult<TypevehicleDTO>> Get(int id) {
            return await Get<Typevehicle, TypevehicleDTO>(id);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TypevehicleCreacionDTO typevehicleCreacionDTO) {
            return await Post<TypevehicleCreacionDTO, Typevehicle, TypevehicleDTO>(typevehicleCreacionDTO, "obtenerTipoVehiculo");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] TypevehicleCreacionDTO typevehicleCreacionDTO) {
            return await Put<TypevehicleCreacionDTO, Typevehicle>(id, typevehicleCreacionDTO);
        }

        //Metodo Patch
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Patch(int id) {
            return await Patch<Typevehicle, TypevehicleDTO>(id);
        }

    }
}
