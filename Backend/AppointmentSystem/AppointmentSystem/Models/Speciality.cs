using System;
using System.Collections.Generic;

namespace AppointmentSystem.Models
{
    public partial class Speciality
    {
        public Speciality()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int SpecialityId { get; set; }
        public string SpecialityName { get; set; }= null!;

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
