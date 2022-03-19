using GrpcService1.Entities;
using GrpcService1.Repositories.Interfaces;

namespace GrpcService1.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IConfiguration _configuration;
        private string connectionstring = "";

        public PatientRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            connectionstring = _configuration.GetValue<string>("ConnectionStrings:HISDatabase");
        }

        public Task<bool> CreatePatient(PatientEntity patient)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePatient(string SoHS)
        {
            throw new NotImplementedException();
        }

        public Task<PatientEntity> GetPatient(string SoHS)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePatient(PatientEntity patient)
        {
            throw new NotImplementedException();
        }
    }
}
