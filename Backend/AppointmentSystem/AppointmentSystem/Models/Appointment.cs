using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace AppointmentSystem.Models
{
    public partial class Appointment
    {
        [Key]
        public int AppId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int SpecialityId { get; set; }
        //[Required(AllowEmptyStrings = true)]
        public virtual Speciality Speciality { get; set; } = null!;
        //[Required(AllowEmptyStrings = true)]
        public virtual User User { get; set; } = null!;
    }
}
