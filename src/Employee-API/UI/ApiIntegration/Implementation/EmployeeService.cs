using Employee.Domain.Entities;
using RestSharp;
using UI.ApiIntegration.Abstract;

namespace UI.ApiIntegration.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IConfiguration _config;
        private readonly string apiUrl;
        private readonly RestClient apiClient;
        private readonly int _apiTimeout;
        private readonly int _responseTimeout;
        public EmployeeService(IConfiguration config)
        {
            this._config = config;
            apiUrl = $"{config["api"]}api/Employee/";
            _responseTimeout = Convert.ToInt32(config["ResponseTimeout"]);
            var nasReadApiOptions = new RestClientOptions(apiUrl)
            {
                ThrowOnAnyError = false
            };
            apiClient = new RestClient(nasReadApiOptions);
            _apiTimeout = Convert.ToInt32(config["APITimeout"]);
        }

        public async Task<List<EmployeeDetail>> GetAllEmployee()
        {
            List<EmployeeDetail>? lst;
            try
            {
                var request = new RestRequest("GetAll", Method.Get);
                request.Timeout = _apiTimeout;
                var response = await apiClient.ExecuteAsync<List<EmployeeDetail>>(request);
                lst = response?.Data;
                return lst;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<EmployeeDetail> GetById(long id)
        {

            EmployeeDetail? lst;
            try
            {
                var request = new RestRequest($"GetById?Id={id}", Method.Get);
                request.Timeout = _apiTimeout;
                var response = await apiClient.ExecuteAsync<EmployeeDetail>(request);
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
