using AppointmentService;
using Grpc.Net.Client;

namespace Telemedicine_AuthAPI.Service
{
    public class DoctorRegistrationService
    {
        private readonly string _appointmentServiceUrl;

        public DoctorRegistrationService(string appointmentServiceUrl)
        {
            _appointmentServiceUrl = appointmentServiceUrl;
        }

        public async Task RegisterDoctorInAppointmentService(string userId, string doctorName, string phone, string email,string role)
        {
            try
            {
                // Create a gRPC channel to connect to the Appointment service
                using var channel = GrpcChannel.ForAddress(_appointmentServiceUrl);

                // Create the client using the generated gRPC class
                var client = new Appointment.AppointmentClient(channel);

                // Prepare the request message
                var request = new DoctorRequest
                {
                    UserId = userId,
                    DoctorName = doctorName,
                    Phone = phone,
                    Email = email,
                    Role = role
                };

                // Call the RegisterDoctor method in the Appointment service
                var response = await client.RegisterDoctorAsync(request);

                if (response.Success)
                {
                    Console.WriteLine("Doctor registered successfully in Appointment DB.");
                }
                else
                {
                    Console.WriteLine("Failed to register doctor: " + response.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while sending data to Appointment service: " + ex.Message);
            }
        }
    }
}
