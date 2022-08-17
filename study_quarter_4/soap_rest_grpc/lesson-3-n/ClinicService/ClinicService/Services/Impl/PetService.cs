using ClinicService.Data;
using ClinicServiceProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using static ClinicServiceProtos.PetService;

namespace ClinicService.Services.Impl
{
    public class PetService : PetServiceBase
    {
        private readonly ClinicServiceDbContext _dbContext;
        private readonly ILogger<PetService> _logger;

        public PetService(ClinicServiceDbContext dbContext,
            ILogger<PetService> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public override Task<ClinicServiceProtos.CreatePetResponse> CreatePet(ClinicServiceProtos.CreatePetRequest request, ServerCallContext context)
        {
            var pet = new Pet
            {
                ClientId = request.ClientId,
                Name = request.Name,
                Birthday = request.Birthday.ToDateTime()
            };

            _dbContext.Add(pet);
            _dbContext.SaveChanges();

            var response = new CreatePetResponse
            {
                PetId = pet.PetId
            };

            return Task.FromResult(response);
        }

        public override Task<GetPetsResponse> GetPets(GetPetsRequest request, ServerCallContext context)
        {
            var response = new GetPetsResponse();
            response.Pets.AddRange(_dbContext.Pets.Select(pet => new PetResponse
            {
                PetId = pet.PetId,
                ClientId = pet.ClientId,
                Name = pet.Name,
                Birthday = pet.Birthday.ToUniversalTime().ToTimestamp()
            }).ToList());

            return Task.FromResult(response);
        }
    }
}
