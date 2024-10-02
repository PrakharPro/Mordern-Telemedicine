using Microsoft.AspNetCore.Mvc;
using Telemedicine_AppintmentBookingAPI.Models;
using Telemedicine_AppintmentBookingAPI.Service.IService;
using Telemedicine_AuthAPI.Models.Dto;

namespace Telemedicine_AppintmentBookingAPI.Controllers
{
    [ApiController]
    [Route("api/appoint")]
    public class AppointmentController : Controller
    {
        private readonly IAppointService _appointService;

        public AppointmentController(IAppointService appointService)
        {
            _appointService = appointService;
        }

        [HttpPut("updatepatient")]
        public IActionResult UpdatePatientdetails([FromBody] Patient patient)
        {
            var result = _appointService.UpdatePatientDetails(patient);
            ResponseDto resultDto = new ResponseDto();
            if (!result.Equals("OK"))
            {
                resultDto.IsSuccess = false;
                resultDto.Message = "Error Encountered";
                return Ok(resultDto);
            }
            resultDto.Message = "Update is success";
            return Ok(resultDto);
        }

        [HttpPut("updatedoctor")]
        public IActionResult UpdateDoctordetails([FromBody] Doctor doctor)
        {
            var result = _appointService.UpdateDoctorDetails(doctor);
            ResponseDto resultDto = new ResponseDto();
            if (!result.Equals("OK"))
            {
                resultDto.IsSuccess = false;
                resultDto.Message = "Error Encountered";
                return Ok(resultDto);
            }
            resultDto.Message = "Update is success";
            return Ok(resultDto);
        }
    }
}
