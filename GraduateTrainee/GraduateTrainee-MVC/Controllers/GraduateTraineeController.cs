using GraduateTraineeEnrollmentMVC.Infrastructure;
using GraduateTraineeEnrollmentMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GraduateTraineeEnrollmentMVC.Controllers
{
    public class GraduateTraineeController : Controller
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IConfiguration _configuration;
        private string endPoint;

        public GraduateTraineeController(IHttpClientService httpClientService, IConfiguration configuration)
        {
            _httpClientService = httpClientService;
            _configuration = configuration;
            endPoint = _configuration["EndPoint:CivicaApi"];
        }

        public IActionResult Index()
        {

            ServiceResponse<IEnumerable<GraduateTraineeViewModel>> response = new ServiceResponse<IEnumerable<GraduateTraineeViewModel>>();

            response = _httpClientService.ExecuteApiRequest<ServiceResponse<IEnumerable<GraduateTraineeViewModel>>>
                ($"{endPoint}GraduateTrainee/GetAll", HttpMethod.Get, HttpContext.Request);
            if (response.Success)
            {
                return View(response.Data);
            }

            return View(new List<GraduateTraineeViewModel>());
            //return View();
        }

        public IActionResult Create()
        {
            AddGraduateTraineeViewModel viewModel = new AddGraduateTraineeViewModel();
            //viewModel.degrees = GetDegrees();

            //viewModel.streams = GetStreams();

            IEnumerable<DegreeViewModel> degrees = GetDegrees();
            ViewBag.Degrees = degrees;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(AddGraduateTraineeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Adding file name string to view model
                IFormFile imageFile = viewModel.File;
                if (imageFile != null && imageFile.Length > 0)
                {
                    var fileName = AddImageFileToPath(imageFile);
                    viewModel.Image = fileName;
                }
                string apiUrl = $"{endPoint}GraduateTrainee/AddTrainee";
                var response = _httpClientService.PostHttpResponseMessage(apiUrl, viewModel, HttpContext.Request);
                if (response.IsSuccessStatusCode)
                {
                    string successResponse = response.Content.ReadAsStringAsync().Result;
                    var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<string>>(successResponse);
                    TempData["successMessage"] = serviceResponse.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    string errorData = response.Content.ReadAsStringAsync().Result;
                    var errorResponse = JsonConvert.DeserializeObject<ServiceResponse<string>>(errorData);
                    if (errorResponse != null)
                    {
                        TempData["errorMessage"] = errorResponse.Message;
                    }
                    else
                    {
                        TempData["errorMesssage"] = "Something went wrong try after some time";
                        return RedirectToAction("Index");
                    }
                }
                return RedirectToAction();
            }
            //viewModel.degrees = GetDegrees();
            //viewModel.streams = GetStreams(viewModel.DegreeId);
            IEnumerable<DegreeViewModel> degrees = GetDegrees();
            ViewBag.Degrees = degrees;
            return View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var apiUrl = $"{endPoint}GraduateTrainee/GetById/" + id;
            var response = _httpClientService.GetHttpResponseMessage<AddGraduateTraineeViewModel>(apiUrl, HttpContext.Request);


            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<AddGraduateTraineeViewModel>>(data);
                if (serviceResponse != null && serviceResponse.Success && serviceResponse.Data != null)
                {
                    AddGraduateTraineeViewModel ViewModel = serviceResponse.Data;
                    //ViewModel.degrees = GetDegrees();
                    //ViewModel.streams = GetStreams(ViewModel.DegreeId);
                    IEnumerable<DegreeViewModel> degrees = GetDegrees();
                    ViewBag.Degrees = degrees;
                    ViewBag.StreamId = serviceResponse.Data.StreamId;
                    return View(ViewModel);
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
                var errorResponse = JsonConvert.DeserializeObject<ServiceResponse<AddGraduateTraineeViewModel>>(errorData);
                if (errorResponse != null)
                {
                    TempData["ErrorMessage"] = errorResponse.Message;
                }
                else
                {
                    TempData["ErrorMessage"] = "Something went wrong.Please try after sometime.";
                }
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(AddGraduateTraineeViewModel viewModel)
        {
            
            if (ModelState.IsValid)
            {
                // Adding file name string to view model
                IFormFile imageFile = viewModel.File;
                if (imageFile != null && imageFile.Length > 0)
                {
                    var fileName = AddImageFileToPath(imageFile);
                    viewModel.Image = fileName;
                }
                var apiUrl = $"{endPoint}GraduateTrainee/UpdateTrainee";
                HttpResponseMessage response = _httpClientService.PutHttpResponseMessage(apiUrl, viewModel, HttpContext.Request);
                if (response.IsSuccessStatusCode)
                {
                    string successResponse = response.Content.ReadAsStringAsync().Result;
                    var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<string>>(successResponse);
                    TempData["successMessage"] = serviceResponse.Message;
                    return RedirectToAction("Index");
                }
                else
                {
                    string errorData = response.Content.ReadAsStringAsync().Result;
                    var errorResponse = JsonConvert.DeserializeObject<ServiceResponse<string>>(errorData);
                    if (errorResponse != null)
                    {
                        TempData["errorMessage"] = errorResponse.Message;
                    }
                    else
                    {
                        TempData["errorMesssage"] = "Something went wrong try after some time";
                        return RedirectToAction("Index");
                    }
                }
            }
            IEnumerable<DegreeViewModel> degrees = GetDegrees();
            ViewBag.Degrees = degrees;
            return View(viewModel);
        }

        public IActionResult Details(int id)
        {

            var apiUrl = $"{endPoint}GraduateTrainee/GetById/" + id;
            var response = _httpClientService.GetHttpResponseMessage<AddGraduateTraineeViewModel>(apiUrl, HttpContext.Request);

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<AddGraduateTraineeViewModel>>(data);

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
                var errorResponse = JsonConvert.DeserializeObject<ServiceResponse<AddGraduateTraineeViewModel>>(errorData);

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

            var apiUrl = $"{endPoint}GraduateTrainee/GetById/" + id;
            var response = _httpClientService.GetHttpResponseMessage<AddGraduateTraineeViewModel>(apiUrl, HttpContext.Request);

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<AddGraduateTraineeViewModel>>(data);

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
                var errorResponse = JsonConvert.DeserializeObject<ServiceResponse<AddGraduateTraineeViewModel>>(errorData);

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
        public IActionResult DeleteConfirmed(int graduateTraineeId)
        {
            var apiUrl = $"{endPoint}GraduateTrainee/Remove/" + graduateTraineeId;
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

        private string AddImageFileToPath(IFormFile imageFile)
        {
            // Process the uploaded file(eq. save it to disk)
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", imageFile.FileName);

            // Save the file to storage and set path
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(stream);
                return imageFile.FileName;
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
        private List<StreamViewModel> GetStreams()
        {
            ServiceResponse<IEnumerable<StreamViewModel>> response = new ServiceResponse<IEnumerable<StreamViewModel>>();
            response = _httpClientService.ExecuteApiRequest<ServiceResponse<IEnumerable<StreamViewModel>>>
                ($"{endPoint}Steam/GetAllStream", HttpMethod.Get, HttpContext.Request);

            if (response.Success)
            {
                return response.Data.ToList();
            }
            return new List<StreamViewModel>();
        }
        private List<StreamViewModel> GetStreams(int id)
        {
            ServiceResponse<IEnumerable<StreamViewModel>> response = new ServiceResponse<IEnumerable<StreamViewModel>>();
            string endPoint = _configuration["EndPoint:CivicaApi"];
            response = _httpClientService.ExecuteApiRequest<ServiceResponse<IEnumerable<StreamViewModel>>>
                ($"{endPoint}Steam/GetStreamByDegreeId/" + id, HttpMethod.Get, HttpContext.Request);

            if (response.Success)
            {
                return response.Data.ToList();
            }
            return new List<StreamViewModel>();
        }
    }
}
