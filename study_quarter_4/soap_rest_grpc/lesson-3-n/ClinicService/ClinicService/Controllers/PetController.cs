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
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;
        private readonly ILogger<PetController> _logger;

        public PetController(IPetRepository petRepository, ILogger<PetController> logger)
        {
            _petRepository = petRepository;
            _logger = logger;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public IActionResult Create([FromBody] CreatePetRequests createRequest) =>
            Ok(_petRepository.Add(new Pet
            {
                ClientId = createRequest.ClientId,
                Name = createRequest.Name,
                Birthday = createRequest.Birthday,
            }));


        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdatePetRequest updateRequest)
        {
            _petRepository.Update(new Pet
            {
                PetId = updateRequest.PetId,
                ClientId = updateRequest.ClientId,
                Name = updateRequest.Name,
                Birthday = updateRequest.Birthday,
            });

            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] int petId)
        {
            _petRepository.Delete(petId);

            return Ok();
        }

        [HttpGet("get-all")]
        [ProducesResponseType(typeof(IList<Pet>), StatusCodes.Status200OK)]
        public IActionResult GetAll() =>
            Ok(_petRepository.GetAll());

        [HttpGet("get/{id}")]
        [ProducesResponseType(typeof(Pet), StatusCodes.Status200OK)]
        public IActionResult GetById([FromRoute] int petId) =>
            Ok(_petRepository.GetById(petId));
    }
}
