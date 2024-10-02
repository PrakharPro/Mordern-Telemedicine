using System;
using System.Collections.Generic;

namespace Telemedicine_AppintmentBookingAPI.Models;

public partial class DoctorAvailability
{
    public int AvailabilityId { get; set; }

    public int DoctorId { get; set; }

    public DateOnly AvailableDate { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
