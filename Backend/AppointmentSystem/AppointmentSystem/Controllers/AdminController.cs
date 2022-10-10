using Microsoft.AspNetCore.Mvc;
using AppointmentSystem.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace AppointmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        reservation_SysContext db;
        public AdminController(reservation_SysContext _db)
        {
            this.db = _db;
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointmentsForDateAndSpeciality(int speciality, DateTime? date)
        {
            date = date == null ? DateTime.Now : date;
            return await db.Appointments.Where(app => app.Date == date && app.SpecialityId == speciality).ToListAsync();
        }


    }
}
