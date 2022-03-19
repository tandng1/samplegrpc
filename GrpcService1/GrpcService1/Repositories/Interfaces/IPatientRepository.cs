using GrpcService1.Entities;
using System.Threading.Tasks;

namespace GrpcService1.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<PatientEntity> GetPatient(string SoHS);

        Task<bool> CreatePatient(PatientEntity patient);
        Task<bool> UpdatePatient(PatientEntity patient);
        Task<bool> DeletePatient(string SoHS);
    }
}
