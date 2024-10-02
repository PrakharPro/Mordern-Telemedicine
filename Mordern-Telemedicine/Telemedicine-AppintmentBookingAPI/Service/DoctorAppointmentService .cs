using Grpc.Core;
using Telemedicine_AppintmentBookingAPI.Service.IService;
using System.Threading.Tasks;
using AppointmentService;
using Telemedicine_AppintmentBookingAPI.Service;

namespace Telemedicine_AppintmentBookingAPI.Service
{
    public class DoctorAppointmentService : Appointment.AppointmentBase
    {
        private IAppointService _appointService;

        public DoctorAppointmentService(IAppointService appointService)
        {
            _appointService = appointService;
        }
        public override async Task<DoctorResponse> RegisterDoctor(DoctorRequest request, ServerCallContext context)
        {
            // Implement the logic to store the doctor's details in your Appointment database
            // For now, we can return a success message.

            var result = await _appointService.AddUser(request);

            return new DoctorResponse
            {
                Success = true,
                Message = result == "OK" ? "Doctor registered successfully." : "Failed to register doctor."
            };
        }


    }

}
