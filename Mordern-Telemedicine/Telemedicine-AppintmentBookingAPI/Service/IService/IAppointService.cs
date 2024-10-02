using AppointmentService;
using Telemedicine_AppintmentBookingAPI.Models;

namespace Telemedicine_AppintmentBookingAPI.Service.IService
{
    public interface IAppointService
    {
        Task<string> AddUser(DoctorRequest doctorRequest);
        string UpdatePatientDetails(Patient patient);
        string UpdateDoctorDetails(Doctor doctor);
    }
}
