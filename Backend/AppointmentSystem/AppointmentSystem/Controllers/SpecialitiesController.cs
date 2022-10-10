using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppointmentSystem.Models;

namespace AppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialitiesController : ControllerBase
    {
        private readonly reservation_SysContext _context;

        public SpecialitiesController(reservation_SysContext context)
        {
            _context = context;
        }

        // GET: api/Specialities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetSpecialities()
        {
            return await _context.Specialities.Select(a=>a.SpecialityName).ToListAsync();
        }

        // GET: api/Specialities/Cardiolgy
        [HttpGet("{name}")]
        public async Task<ActionResult<int>> GetSpecialityID(string name)
        {
            var speciality =  await _context.Specialities.Where(a=>a.SpecialityName==name).Select(a=>a.SpecialityId).FirstAsync();

            if (speciality == null)
            {
                return NotFound();
            }

            return speciality;
        }

        
    }
}
