using GraduateTraineeEnrollmentMVC.Implementation;
using GraduateTraineeEnrollmentMVC.Infrastructure;
using GraduateTraineeEnrollmentMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace GraduateTraineeEnrollmentMVC.Controllers
{
    public class StreamController : Controller
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IConfiguration _configuration;
        private string endPoint;
        public StreamController(IHttpClientService httpClientService, IConfiguration configuration)
        {
            _httpClientService = httpClientService;
            _configuration = configuration;
            endPoint = _configuration["EndPoint:CivicaApi"];
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddStreamViewModel viewModel = new AddStreamViewModel();
            viewModel.DegreeList = GetDegrees();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(AddStreamViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //string endPoint = _configuration["EndPoint:CivicaApi"];
                string apiUrl = $"{endPoint}Steam/Create";
                var response = _httpClientService.PostHttpResponseMessage<AddStreamViewModel>(apiUrl, viewModel, HttpContext.Request);
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<AddStreamViewModel>>(data);

                    if (serviceResponse != null && serviceResponse.Success && serviceResponse.Data != null)
                    {
                        return View(serviceResponse.Data);
                    }
                    else
                    {
                        TempData["SuccessMessage"] = serviceResponse.Message;
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    string errorData = response.Content.ReadAsStringAsync().Result;
                    var errorResponse = JsonConvert.DeserializeObject<ServiceResponse<AddStreamViewModel>>(errorData);

                    if (errorResponse != null)
                    {
                        TempData["ErrorMessage"] = errorResponse.Message;
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Something went wrong please try after some time.";
                    }

                    return RedirectToAction("Index");
                }
            }
            return View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var apiUrl = $"{endPoint}Steam/GetStreamById/" + id;
            var response = _httpClientService.GetHttpResponseMessage<UpdateStreamViewModel>(apiUrl, HttpContext.Request);

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<UpdateStreamViewModel>>(data);

                if (serviceResponse != null && serviceResponse.Success && serviceResponse.Data != null)
                {
                    serviceResponse.Data.Degrees = GetDegrees();
                    return View(serviceResponse.Data);
                }
                else
                {
                    TempData["ErrorMessage"] = serviceResponse.Message;
                    return RedirectToAction("Index");
                }
            }
            else
            {
                string errorData = response.Content.ReadAsStringAsync().Result;
                var errorResponse = JsonConvert.DeserializeObject<ServiceResponse<UpdateStreamViewModel>>(errorData);

                if (errorResponse != null)
                {
                    TempData["ErrorMessage"] = errorResponse.Message;
                }
                else
                {
                    TempData["ErrorMessage"] = "Something went wrong please try after some time.";
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(UpdateStreamViewModel updateStream)
        {
            if (ModelState.IsValid)
            {
                var apiUrl = $"{endPoint}Steam/ModifyStream";
                HttpResponseMessage response = _httpClientService.PutHttpResponseMessage(apiUrl, updateStream, HttpContext.Request);

                if (response.IsSuccessStatusCode)
                {
                    string successResponse = response.Content.ReadAsStringAsync().Result;
                    var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<string>>(successResponse);
                    TempData["successMessage"] = serviceResponse.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    string errorResponse = response.Content.ReadAsStringAsync().Result;
                    var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<string>>(errorResponse);

                    if (errorResponse != null)
                    {
                        TempData["ErrorMessage"] = serviceResponse.Message;
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Something went wrong please try after some time.";
                    }
                }
            }
            updateStream.Degrees = GetDegrees();
            return View(updateStream);
        }


        /*        public IActionResult Index()
                {
                    ServiceResponse<IEnumerable<StreamViewModel>> response = new ServiceResponse<IEnumerable<StreamViewModel>>();
                    response = _httpClientService.ExecuteApiRequest<ServiceResponse<IEnumerable<StreamViewModel>>>
                        ($"{endPoint}Steam/GetAllStream", HttpMethod.Get, HttpContext.Request);
                    if (response.Success)
                    {
                        return View(response.Data);
                    }
                    return View(new List<StreamViewModel>());
                }*/

        public IActionResult Index(int page = 1, int pageSize = 2)
        {
            var apiGetPositionsUrl = $"{endPoint}Steam/GetAllStreamByPagination" + "?page=" + page + "&pageSize=" + pageSize;
            var apiGetCountUrl = $"{endPoint}Steam/StreamsCount";
            ServiceResponse<int> countOfPosition = new ServiceResponse<int>();
            countOfPosition = _httpClientService.ExecuteApiRequest<ServiceResponse<int>>
                (apiGetCountUrl, HttpMethod.Get, HttpContext.Request);
            int totalCount = countOfPosition.Data;
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            ViewBag.CurrentPage = page;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;
            ServiceResponse<IEnumerable<StreamViewModel>> response = new ServiceResponse<IEnumerable<StreamViewModel>>();
            response = _httpClientService.ExecuteApiRequest<ServiceResponse<IEnumerable<StreamViewModel>>>
                (apiGetPositionsUrl, HttpMethod.Get, HttpContext.Request);
            if (response.Success)
            {
                return View(response.Data);
            }
            return View(new List<StreamViewModel>());
        }

        public IActionResult Details(int id)
        {
            //string endPoint = _configuration["EndPoint:CivicaApi"];
            var apiUrl = $"{endPoint}Steam/GetStreamById/" + id;
            var response = _httpClientService.GetHttpResponseMessage<AddStreamViewModel>(apiUrl, HttpContext.Request);

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<AddStreamViewModel>>(data);

                if (serviceResponse != null && serviceResponse.Success && serviceResponse.Data != null)
                {
                    return View(serviceResponse.Data);
                }
                else
                {
                    TempData["ErrorMessage"] = serviceResponse.Message;
                    return RedirectToAction("Index");
                }
            }
            else
            {
                string errorData = response.Content.ReadAsStringAsync().Result;
                var errorResponse = JsonConvert.DeserializeObject<ServiceResponse<AddStreamViewModel>>(errorData);

                if (errorResponse != null)
                {
                    TempData["ErrorMessage"] = errorResponse.Message;
                }
                else
                {
                    TempData["ErrorMessage"] = "Something went wrong please try after some time.";
                }

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            var apiUrl = $"{endPoint}Steam/GetStreamById/" + id;
            var response = _httpClientService.GetHttpResponseMessage<StreamViewModel>(apiUrl, HttpContext.Request);

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<StreamViewModel>>(data);

                if (serviceResponse != null && serviceResponse.Success && serviceResponse.Data != null)
                {
                    return View(serviceResponse.Data);
                }
                else
                {
                    TempData["ErrorMessage"] = serviceResponse.Message;
                    return RedirectToAction("Index");
                }
            }
            else
            {
                string errorData = response.Content.ReadAsStringAsync().Result;
                var errorResponse = JsonConvert.DeserializeObject<ServiceResponse<StreamViewModel>>(errorData);

                if (errorResponse != null)
                {
                    TempData["ErrorMessage"] = errorResponse.Message;
                }
                else
                {
                    TempData["ErrorMessage"] = "Something went wrong please try after some time.";
                }

                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int streamId)
        {
            var apiUrl = $"{endPoint}Steam/Remove/" + streamId;
            //var response = _httpClientService.GetHttpResponseMessage<string>(apiUrl, HttpContext.Request);

            var response = _httpClientService.ExecuteApiRequest<ServiceResponse<string>>
                ($"{apiUrl}", HttpMethod.Delete, HttpContext.Request);

            if (response.Success)
            {
                TempData["SuccessMessage"] = response.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = response.Message;
                return RedirectToAction("Index");
            }


        }

        private List<DegreeViewModel> GetDegrees()
        {
            ServiceResponse<IEnumerable<DegreeViewModel>> response = new ServiceResponse<IEnumerable<DegreeViewModel>>();
            string endPoint = _configuration["EndPoint:CivicaApi"];
            response = _httpClientService.ExecuteApiRequest<ServiceResponse<IEnumerable<DegreeViewModel>>>
                ($"{endPoint}Degree/GetAll", HttpMethod.Get, HttpContext.Request);

            if (response.Success)
            {
                return response.Data.ToList();
            }
            return new List<DegreeViewModel>();
        }
    }
}
