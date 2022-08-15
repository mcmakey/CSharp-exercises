using ClinicService.Data;

namespace ClinicService.Services.Impl
{
    public class ConsultationRepository : IConsultationRepository
    {

        private readonly ClinicServiceDbContext _dbContext;
        private readonly ILogger<ConsultationRepository> _logger;

        public ConsultationRepository(ClinicServiceDbContext dbContext, ILogger<ConsultationRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public int Add(Consultation item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Consultation item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Consultation> GetAll()
        {
            throw new NotImplementedException();
        }

        public Consultation? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Consultation item)
        {
            throw new NotImplementedException();
        }
    }
}
