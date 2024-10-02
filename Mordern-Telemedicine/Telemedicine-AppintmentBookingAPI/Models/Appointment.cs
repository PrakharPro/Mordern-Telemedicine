using System;
using System.Collections.Generic;

namespace Telemedicine_AppintmentBookingAPI.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int DoctorId { get; set; }

    public int PatientId { get; set; }

    public DateOnly AppointmentDate { get; set; }

    public TimeOnly AppointmentStartTime { get; set; }

    public TimeOnly AppointmentEndTime { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
