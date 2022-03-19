using Grpc.Core;
using GrpcService1;
using GrpcService1.Database;
using GrpcService1.Entities;

namespace GrpcService1.Services
{
    public class PatientService : Patient.PatientBase
    {
        private readonly ILogger<GreeterService> _logger;
        private HISDbContext db = null;
        public PatientService(ILogger<GreeterService> logger, HISDbContext db)
        {
            _logger = logger;
            this.db = db;
        }

        public override Task<PatientModels> SelectAll(Empty request, ServerCallContext context)
        {
            PatientModels responseData = new PatientModels();
            var query = from pat in db.Patients
                        select new PatientModel()
                        {
                            PatientID = pat.SoHS,
                            FirstName = pat.Ho,
                            LastName = pat.Ten,
                        };
            responseData.Items.AddRange(query.ToArray());
            return Task.FromResult(responseData);
        }

        public override Task<PatientModel> SelectByID(PatientFilter requestData, ServerCallContext context)
        {
            var data = db.Patients.Find(requestData.PatientID);
            PatientModel pat = new PatientModel()
            {
                PatientID = data.SoHS,
                FirstName = data.Ho,
                LastName = data.Ten
            };
            return Task.FromResult(pat);
        }

        public override Task<Empty> Insert(PatientModel requestData, ServerCallContext context)
        {
            db.Patients.Add(new PatientEntity()
            {
                SoHS = requestData.PatientID,
                Ho = requestData.FirstName,
                Ten = requestData.LastName
            });
            db.SaveChanges();
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> Update(PatientModel requestData, ServerCallContext context)
        {
            db.Patients.Update(new PatientEntity()
            {
                SoHS = requestData.PatientID,
                Ho = requestData.FirstName,
                Ten = requestData.LastName
            });
            db.SaveChanges();
            return Task.FromResult(new Empty());
        }

        public override Task<Empty> Delete(PatientFilter requestData, ServerCallContext context)
        {
            var data = db.Patients.Find(requestData.PatientID);
            db.Patients.Remove(new PatientEntity()
            {
                SoHS = requestData.PatientID,
                Ho = data.Ho,
                Ten = data.Ten
            });
            db.SaveChanges();
            return Task.FromResult(new Empty());
        }


    }
}