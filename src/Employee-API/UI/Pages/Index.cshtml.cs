using Employee.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.ApiIntegration.Abstract;

namespace UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IEmployeeService employeeService;

        public IndexModel(ILogger<IndexModel> logger
            , IEmployeeService employeeService)
        {
            _logger = logger;
            this.employeeService = employeeService;
        }

        [BindProperty]
        public List<EmployeeDetail> employeeList { get; set; }

        public async Task OnGet()
        {
            try
            {
                employeeList = await employeeService.GetAllEmployee();
            }
            catch (Exception ex)
            {

                _logger.LogError($"IndexModel/OnGet throws:{ex.Message}");
            }
        }
    }
}