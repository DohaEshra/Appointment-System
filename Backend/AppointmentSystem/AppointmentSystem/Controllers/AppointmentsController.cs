using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppointmentSystem.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly reservation_SysContext _context;
        public User CurrentUser { get; set; }

        public AppointmentsController(reservation_SysContext context)
        {
            _context = context;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            CurrentUser = GetCurrentUser();
            return await _context.Appointments.Where(app => app.UserId == CurrentUser.UserId).ToListAsync();
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }

        //book an appointment
        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]//DateTime date, int specID
        [Authorize(Roles = "User")]

        public async Task<ActionResult<Appointment>> PostAppointment(string specName, DateTime date)
        {
            CurrentUser = GetCurrentUser();
            Appointment app = new Appointment();
            app.UserId = CurrentUser.UserId;
            app.SpecialityId = _context.Specialities.Where(s=>s.SpecialityName==specName).Select(s=>s.SpecialityId).FirstOrDefault();
            app.Date = date;
            _context.Appointments.Add(app);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAppointment", new { id = app.AppId }, app);

        }

       
        private User GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;// get identity of loggedin user

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new User
                {
                    UserId = int.Parse(userClaims.FirstOrDefault(o => o.Type == "ID")?.Value),
                    Username = userClaims.FirstOrDefault(o => o.Type == "Username")?.Value,
                    Password = userClaims.FirstOrDefault(o => o.Type == "Password")?.Value,
                    //Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;

        }
    }
}
