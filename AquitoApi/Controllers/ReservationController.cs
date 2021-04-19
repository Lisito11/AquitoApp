using AquitoApi.DTOs.Reservation;
using AquitoApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquitoApi.Controllers
{
    [ApiController]
    [Route("api/reservacion")]
    public class ReservationController: CustomBaseController
    {
        private readonly d2bc1ckqeusvkjContext context;
        private readonly IMapper mapper;
        public ReservationController(d2bc1ckqeusvkjContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<ReservationDTO>>> Get()
        {
            var reservacion = await context.Reservations
                            .Include(x => x.Client)
                            .Include(x => x.Useraquito)
                            .Include(x => x.Vehicle)
                            .ThenInclude(x => x.Typevehicle)
                            .ToListAsync();
            return mapper.Map<List<ReservationDTO>>(reservacion);
        }

        //Metodo Get(id)
        [HttpGet("{id:int}", Name = "obtenerreservaciones")]
        public async Task<ActionResult<ReservationDTO>> Get(int id)
        {
            var reservacion = await context.Reservations
                .Include(x => x.Client)
                .Include(x => x.Useraquito)
                .Include(x => x.Vehicle)
                .ThenInclude(x => x.Typevehicle)
                .FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<ReservationDTO>(reservacion);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ReservationCreacionDTO ReservationCreacionDTO)
        {
            return await Post<ReservationCreacionDTO, Reservation, ReservationDTO>(ReservationCreacionDTO, "obtenerreservaciones");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ReservationCreacionDTO ReservationCreacionDTO)
        {
            return await Put<ReservationCreacionDTO, Reservation>(id, ReservationCreacionDTO);
        }

        //Metodo Patch
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Patch(int id)
        {
            return await Patch<Reservation, ReservationDTO>(id);
        }
    }
}
