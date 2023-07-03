using Employee.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.ApiIntegration.Abstract;

namespace UI.Pages.Employee
{
    public class EmployeeViewModel : PageModel
    {
        private readonly ILogger<EmployeeViewModel> logger;
        private readonly IEmployeeService employeeService;
        private readonly IPaymentService paymentService;

        public EmployeeViewModel(ILogger<EmployeeViewModel> logger
            , IEmployeeService employeeService
            , IPaymentService paymentService)
        {
            this.logger = logger;
            this.employeeService = employeeService;
            this.paymentService = paymentService;
        }
        [BindProperty]
        public EmployeeDetail Employee { get; set; }
        [BindProperty]
        public double Payment { get; set; }
        public async Task OnGet(int? id)
        {
            try
            {
                Employee = await employeeService.GetById(Convert.ToInt32(id));
                var result = await paymentService.GetPaymentEmpById(Convert.ToInt32(id));
                Payment = result.Sum(x => x.AmountPayed);
            }
            catch (Exception ex)
            {
                logger.LogInformation($"EmployeeViewModel/OnGet: {ex.Message}");
            }
        }
        public async Task OnGetPaymentDetails(long id)
        {
            try
            {
                var result = await paymentService.GetPaymentEmpById(id);
            }
            catch (Exception ex)
            {
                logger.LogInformation($"EmployeeViewModel/OnGetPaymentDetails: {ex.Message}");
            }
        }
    }
}
