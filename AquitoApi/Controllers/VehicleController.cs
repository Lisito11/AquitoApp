using AquitoApi.DTOs.Vehicle;
using AquitoApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

namespace AquitoApi.Controllers {
    [ApiController]
    [Route("api/vehiculo")]
    public class VehicleController: CustomBaseController {
        private readonly d2bc1ckqeusvkjContext context;
        private readonly IMapper mapper;
        public VehicleController(d2bc1ckqeusvkjContext context, IMapper mapper) : base(context, mapper) {
            this.context = context;
            this.mapper = mapper;
        }

        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<VehicleDTO>>> Get() {
            var Vehiculo = await context.Vehicles.Include(x => x.Typevehicle).ToListAsync();
            return mapper.Map<List<VehicleDTO>>(Vehiculo);
        }

        //Metodo Get para traer los vehiculos que estan disponibles
        [HttpGet("disponible")]
        public async Task<ActionResult<List<VehicleDTO>>> GetActiveVehicle() {
            var Vehiculo = await context.Vehicles.Include(x => x.Typevehicle).Where(x=> x.Status == 1).ToListAsync();
            return mapper.Map<List<VehicleDTO>>(Vehiculo);
        }


        //Metodo Get para traer los vehiculos que no estan disponibles
        [HttpGet("nodisponible")]
        public async Task<ActionResult<List<VehicleDTO>>> GetNoActiveVehicle() {
            var Vehiculo = await context.Vehicles.Include(x => x.Typevehicle).Where(x => x.Status == 2).ToListAsync();
            return mapper.Map<List<VehicleDTO>>(Vehiculo);
        }


        //Metodo Get para traer los vehiculos que no estan disponibles
        [HttpGet("deshabilitados")]
        public async Task<ActionResult<List<VehicleDTO>>> GetDeshabilitados() {
            var Vehiculo = await context.Vehicles.Include(x => x.Typevehicle).Where(x => x.Status == 0).ToListAsync();
            return mapper.Map<List<VehicleDTO>>(Vehiculo);
        }

        //Metodo Get(id)
        [HttpGet("{id:int}", Name = "obtenerVehiculo")]
        public async Task<ActionResult<VehicleDTO>> Get(int id) {
            Vehicle vehiculo = await context.Vehicles.Include(x => x.Typevehicle).FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<VehicleDTO>(vehiculo);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VehicleCreacionDTO vehicleCreacionDTO) {
            return await Post<VehicleCreacionDTO, Vehicle, VehicleDTO>(vehicleCreacionDTO, "obtenerVehiculo");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] VehicleCreacionDTO vehicleCreacionDTO) {
            return await Put<VehicleCreacionDTO, Vehicle>(id, vehicleCreacionDTO);
        }

        //Metodo Patch
        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<Vehicle> patchDoc) {
            return await Patch<Vehicle, VehicleDTO>(id, patchDoc);
        }
    }
}
