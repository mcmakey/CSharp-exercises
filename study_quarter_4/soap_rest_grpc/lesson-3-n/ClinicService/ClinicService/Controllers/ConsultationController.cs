using ClinicService.Data;
using ClinicService.Models.Requests;
using ClinicService.Services;
using ClinicService.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationRepository _consultationRepository;
        private readonly ILogger<ConsultationController> _logger;

        public ConsultationController(ConsultationRepository consultationRepository, ILogger<ConsultationController> logger)
        {
            _consultationRepository = consultationRepository;
            _logger = logger;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public IActionResult Create([FromBody] CreateConsultationRequest createRequest) =>
            Ok(_consultationRepository.Add(new Consultation
            {
                ClientId = createRequest.ClientId,
                PetId = createRequest.PetId,
                ConsultationDate = createRequest.ConsultationDate,
                Description = createRequest.Description
            }));

        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdateConsultationRequest updateRequest)
        {
            _consultationRepository.Update(new Consultation
            {
                ConsultationId = updateRequest.ConsultationId,
                ClientId = updateRequest.ClientId,
                PetId = updateRequest.PetId,
                ConsultationDate = updateRequest.ConsultationDate,
                Description = updateRequest.Description
            });

            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] int consultationId)
        {
            _consultationRepository.Delete(consultationId);

            return Ok();
        }

        [HttpGet("get-all")]
        [ProducesResponseType(typeof(IList<Consultation>), StatusCodes.Status200OK)]
        public IActionResult GetAll() =>
            Ok(_consultationRepository.GetAll());

        [HttpGet("get/{id}")]
        [ProducesResponseType(typeof(Consultation), StatusCodes.Status200OK)]
        public IActionResult GetById([FromRoute] int consultationId) =>
            Ok(_consultationRepository.GetById(consultationId));
    }
}
