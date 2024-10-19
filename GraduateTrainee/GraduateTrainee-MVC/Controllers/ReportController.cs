using GraduateTraineeEnrollmentMVC.Infrastructure;
using GraduateTraineeEnrollmentMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduateTraineeEnrollmentMVC.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly IHttpClientService _httpClientService;

        private readonly IConfiguration _configuration;

        private string endPoint;

        public ReportController(IHttpClientService httpClientService, IConfiguration configuration)
        {
            _httpClientService = httpClientService;
            _configuration = configuration;
            endPoint = _configuration["EndPoint:CivicaApi"];
        }


        public IActionResult Index()
        {
            ServiceResponse<IEnumerable<ReportViewModel>> response = new ServiceResponse<IEnumerable<ReportViewModel>>();
            string endPoint = _configuration["EndPoint:CivicaApi"];
            response = _httpClientService.ExecuteApiRequest<ServiceResponse<IEnumerable<ReportViewModel>>>
                ($"{endPoint}GraduateTrainee/GetTraineeEnrollmentReport", HttpMethod.Get, HttpContext.Request);

            if (response.Success)
            {
                return View(response.Data);
            }
            return View(new List<ReportViewModel>());
        }
    }
}
