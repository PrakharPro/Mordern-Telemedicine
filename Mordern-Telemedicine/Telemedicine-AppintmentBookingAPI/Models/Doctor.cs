using System;
using System.Collections.Generic;

namespace Telemedicine_AppintmentBookingAPI.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string Email { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public string LicenseNumber { get; set; } = null!;

    public int ExperienceYears { get; set; }

    public string? ClinicAddress { get; set; }

    public decimal ConsultationFee { get; set; }

    public TimeOnly? AvailableFrom { get; set; }

    public TimeOnly? AvailableTo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
