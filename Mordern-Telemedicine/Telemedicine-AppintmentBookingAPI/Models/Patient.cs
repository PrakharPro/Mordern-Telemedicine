using System;
using System.Collections.Generic;

namespace Telemedicine_AppintmentBookingAPI.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string Email { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Gender { get; set; } = null!;

    public string? MedicalHistory { get; set; }

    public string? InsuranceNumber { get; set; }

    public string? EmergencyContact { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
