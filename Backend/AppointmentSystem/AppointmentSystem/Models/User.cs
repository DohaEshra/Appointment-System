using System;
using System.Collections.Generic;

namespace AppointmentSystem.Models
{
    public partial class User
    {
        public User()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FName { get; set; } = null!;
        public string LName { get; set; } = null!;

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
