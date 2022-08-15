using ClinicService.Data;

namespace ClinicService.Services.Impl
{
    public class PetRepository : IPetRepository
    {

        private readonly ClinicServiceDbContext _dbContext;
        private readonly ILogger<PetRepository> _logger;

        public PetRepository(ClinicServiceDbContext dbContext, ILogger<PetRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public int Add(Pet item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Pet item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Pet> GetAll()
        {
            throw new NotImplementedException();
        }

        public Pet? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Pet item)
        {
            throw new NotImplementedException();
        }
    }
}
