using AppointmentService;
using Telemedicine_AppintmentBookingAPI.Models;
using Telemedicine_AppintmentBookingAPI.Service.IService;

namespace Telemedicine_AppintmentBookingAPI.Service
{
    public class AppointService : IAppointService
    {
        private readonly AppointmentDbContext _appointmentDbContext;
        public AppointService(AppointmentDbContext appointmentDbContext) {
        _appointmentDbContext = appointmentDbContext;
        }
       public async Task<String> AddUser(DoctorRequest doctorRequest)
        {
            try
            {
                User user = new User()
                {

                    Name = doctorRequest.DoctorName,
                    Email = doctorRequest.Email,
                    PhoneNumber = doctorRequest.Phone,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                if (doctorRequest.Role == "doctor")
                {
                    user.IsDoctor = true;
                }
                else
                {
                    user.IsDoctor = false;
                }
                Patient patient = new Patient() { 
                Email = user.Email
                };
                Doctor doctor = new Doctor()
                {
                    Email = user.Email
                };
                await _appointmentDbContext.Users.AddAsync(user);
                if (user.IsDoctor)
                {
                    await _appointmentDbContext.Doctors.AddAsync(doctor);
                }
                else
                {
                    await _appointmentDbContext.Patients.AddAsync(patient);
                }
                await _appointmentDbContext.SaveChangesAsync();

                return "OK";
            }
            catch (Exception ex) {
                return "Error Encountered";
            }
        }

        public string UpdateDoctorDetails(Doctor doctor)
        {
            try
            {
                _appointmentDbContext.Doctors.Update(doctor);
                _appointmentDbContext.SaveChanges();
                return "OK";
            }
            catch (Exception ex)
            {
                return "Error Encountered";
            }
        }

        public String UpdatePatientDetails(Patient patient)
        {
            try
            {
                _appointmentDbContext.Patients.Update(patient);
                _appointmentDbContext.SaveChanges();
                return "OK";
            }
            catch (Exception ex)
            {
                return "Error Encountered";
            }
        }

    }
}
