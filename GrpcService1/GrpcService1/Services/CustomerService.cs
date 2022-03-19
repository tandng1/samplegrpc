using Grpc.Core;

namespace GrpcService1.Services
{
    public class CustomerService : Customer.CustomerBase
    {
        private readonly ILogger<CustomerService> _logger;
        public CustomerService(ILogger<CustomerService> logger)
        {
            _logger = logger;
        }
        public override Task<CustomerDataModel> GetCustomerInfo(CustomerFindModel request, ServerCallContext context)
        {
            CustomerDataModel result = new CustomerDataModel();
            if (request.UserId == 1)
            {
                result.FirstName = "Mohamad";
                result.LastName = "Lawand";
            }
            else if (request.UserId == 2)
            {
                result.FirstName = "Richard";
                result.LastName = "Feynman";
            }
            else if (request.UserId == 3)
            {
                result.FirstName = "Bruce";
                result.LastName = "Wayne";
            }
            else
            {
                result.FirstName = "James";
                result.LastName = "Bond";
            }

            return Task.FromResult(result);
        }
        public override async Task GetAllCustomers(AllCustomerModel request, IServerStreamWriter<CustomerDataModel> responseStream, ServerCallContext context)
        {
            var allCustomers = new List<CustomerDataModel>();

            var c1 = new CustomerDataModel();
            c1.FirstName = "Mohamad Lawand";
            c1.LastName = "mohamad@mail.com";
            allCustomers.Add(c1);

            var c2 = new CustomerDataModel();
            c2.FirstName = "Richard Feynman";
            c2.LastName = "richard@physics.com";
            allCustomers.Add(c2);

            var c3 = new CustomerDataModel();
            c3.FirstName = "Bruce Wayne";
            c3.LastName = "bruce@gotham.com";
            allCustomers.Add(c3);

            var c4 = new CustomerDataModel();
            c4.FirstName = "James Bond";
            c4.LastName = "007@outlook.com";
            allCustomers.Add(c4);

            foreach (var item in allCustomers)
            {
                await responseStream.WriteAsync(item);
            }
        }
    }
}
