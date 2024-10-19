using GraduateTraineeEnrollmentMVC.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace GraduateTraineeEnrollmentMVC.Controllers
{
    public class StreamAjaxController : Controller
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IConfiguration _configuration;
        private string endPoint;
        public StreamAjaxController(IHttpClientService httpClientService, IConfiguration configuration)
        {
            _httpClientService = httpClientService;
            _configuration = configuration;
            endPoint = _configuration["EndPoint:CivicaApi"];
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
