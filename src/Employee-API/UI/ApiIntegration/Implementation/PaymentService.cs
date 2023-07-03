using Employee.Domain.Entities;
using RestSharp;
using UI.ApiIntegration.Abstract;

namespace UI.ApiIntegration.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _config;
        private readonly string apiUrl;
        private readonly RestClient apiClient;
        private readonly int _apiTimeout;
        private readonly int _responseTimeout;
        public PaymentService(IConfiguration config)
        {
            this._config = config;
            apiUrl = $"{config["api"]}api/Payment/";
            _responseTimeout = Convert.ToInt32(config["ResponseTimeout"]);
            var nasReadApiOptions = new RestClientOptions(apiUrl)
            {
                ThrowOnAnyError = false
            };
            apiClient = new RestClient(nasReadApiOptions);
            _apiTimeout = Convert.ToInt32(config["APITimeout"]);
        }
        public async Task<List<EmployeePayment>> GetPaymentEmpById(long id)
        {

            List<EmployeePayment>? lst;
            try
            {
                var request = new RestRequest($"GetByEmployeeId?Id={id}", Method.Get);
                request.Timeout = _apiTimeout;
                var response = await apiClient.ExecuteAsync<List<EmployeePayment>>(request);
                lst = response?.Data;
                return lst;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
