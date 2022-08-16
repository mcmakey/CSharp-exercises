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
            _dbContext.Pets.Add(item);
            _dbContext.SaveChanges();

            return item.PetId;
        }

        public void Delete(Pet item)
        {
            if (item is null)
            {
                throw new NullReferenceException();
            }

            Delete(item.PetId);
        }

        public void Delete(int id)
        {
            var pet = GetById(id);

            if (pet is null)
            {
                throw new KeyNotFoundException();
            }

            _dbContext.Remove(pet);
            _dbContext.SaveChanges();
        }

        public IList<Pet> GetAll()
        {
            return _dbContext.Pets.ToList();
        }

        public Pet? GetById(int id)
        {
            return _dbContext.Pets.FirstOrDefault(pet => pet.PetId == id);
        }

        public void Update(Pet item)
        {
            if (item is null)
            {
                throw new NullReferenceException();
            }

            var pet = GetById(item.PetId);

            if (pet is null)
            {
                throw new KeyNotFoundException();
            }

            pet.ClientId = item.ClientId;
            pet.Name = item.Name;
            pet.Birthday = item.Birthday;

            _dbContext.Update(pet);
            _dbContext.SaveChanges();
        }
    }
}
