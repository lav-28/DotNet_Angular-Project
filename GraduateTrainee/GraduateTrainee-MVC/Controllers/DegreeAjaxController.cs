using GraduateTraineeEnrollmentMVC.Infrastructure;
using GraduateTraineeEnrollmentMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GraduateTraineeEnrollmentMVC.Controllers
{
    public class DegreeAjaxController : Controller
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IConfiguration _configuration;
        private string endPoint;

        public DegreeAjaxController(IHttpClientService httpClientService, IConfiguration configuration)
        {
            _httpClientService = httpClientService;
            _configuration = configuration;
            endPoint = _configuration["EndPoint:CivicaApi"];
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }


        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(AddDegreeViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //string endPoint = _configuration["EndPoint:CivicaApi"];
        //        string apiUrl = $"{endPoint}Degree/Create";
        //        var response = _httpClientService.PostHttpResponseMessage<AddDegreeViewModel>(apiUrl, viewModel, HttpContext.Request);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string data = response.Content.ReadAsStringAsync().Result;
        //            var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<AddDegreeViewModel>>(data);

        //            if (serviceResponse != null && serviceResponse.Success && serviceResponse.Data != null)
        //            {
        //                return View(serviceResponse.Data);
        //            }
        //            else
        //            {
        //                TempData["SuccessMessage"] = serviceResponse.Message;
        //                return RedirectToAction("Index");
        //            }
        //        }
        //        else
        //        {
        //            string errorData = response.Content.ReadAsStringAsync().Result;
        //            var errorResponse = JsonConvert.DeserializeObject<ServiceResponse<AddDegreeViewModel>>(errorData);

        //            if (errorResponse != null)
        //            {
        //                TempData["ErrorMessage"] = errorResponse.Message;
        //            }
        //            else
        //            {
        //                TempData["ErrorMessage"] = "Something went wrong please try after some time.";
        //            }

        //            return RedirectToAction("Index");
        //        }
        //    }
        //    return View(viewModel);
        //}
        //public IActionResult Details(int id)
        //{
        //    //string endPoint = _configuration["EndPoint:CivicaApi"];
        //    var apiUrl = $"{endPoint}Degree/GetDegreeById/" + id;
        //    var response = _httpClientService.GetHttpResponseMessage<AddDegreeViewModel>(apiUrl, HttpContext.Request);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string data = response.Content.ReadAsStringAsync().Result;
        //        var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<AddDegreeViewModel>>(data);

        //        if (serviceResponse != null && serviceResponse.Success && serviceResponse.Data != null)
        //        {
        //            return View(serviceResponse.Data);
        //        }
        //        else
        //        {
        //            TempData["ErrorMessage"] = serviceResponse.Message;
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    else
        //    {
        //        string errorData = response.Content.ReadAsStringAsync().Result;
        //        var errorResponse = JsonConvert.DeserializeObject<ServiceResponse<AddDegreeViewModel>>(errorData);

        //        if (errorResponse != null)
        //        {
        //            TempData["ErrorMessage"] = errorResponse.Message;
        //        }
        //        else
        //        {
        //            TempData["ErrorMessage"] = "Something went wrong please try after some time.";
        //        }

        //        return RedirectToAction("Index");
        //    }
        //}
        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    //string endPoint = _configuration["EndPoint:CivicaApi"];
        //    var apiUrl = $"{endPoint}Degree/GetDegreeById/" + id;
        //    var response = _httpClientService.GetHttpResponseMessage<AddDegreeViewModel>(apiUrl, HttpContext.Request);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string data = response.Content.ReadAsStringAsync().Result;
        //        var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<AddDegreeViewModel>>(data);

        //        if (serviceResponse != null && serviceResponse.Success && serviceResponse.Data != null)
        //        {
        //            return View(serviceResponse.Data);
        //        }
        //        else
        //        {
        //            TempData["ErrorMessage"] = serviceResponse.Message;
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    else
        //    {
        //        string errorData = response.Content.ReadAsStringAsync().Result;
        //        var errorResponse = JsonConvert.DeserializeObject<ServiceResponse<AddDegreeViewModel>>(errorData);

        //        if (errorResponse != null)
        //        {
        //            TempData["ErrorMessage"] = errorResponse.Message;
        //        }
        //        else
        //        {
        //            TempData["ErrorMessage"] = "Something went wrong please try after some time.";
        //        }

        //        return RedirectToAction("Index");
        //    }
        //}
        //[HttpPost]
        //public IActionResult Edit(AddDegreeViewModel updateDegree)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //string endPoint = _configuration["EndPoint:CivicaApi"];
        //        var apiUrl = $"{endPoint}Degree/ModifyDegree";
        //        HttpResponseMessage response = _httpClientService.PutHttpResponseMessage(apiUrl, updateDegree, HttpContext.Request);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string successResponse = response.Content.ReadAsStringAsync().Result;
        //            var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<string>>(successResponse);
        //            TempData["SuccessMessage"] = serviceResponse.Message;
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            string errorResponse = response.Content.ReadAsStringAsync().Result;
        //            var serviceResponse = JsonConvert.DeserializeObject<ServiceResponse<string>>(errorResponse);
        //            if (errorResponse != null)
        //            {
        //                TempData["ErrorMessage"] = serviceResponse.Message;
        //            }
        //            else
        //            {
        //                TempData["ErrorMessage"] = "Something went wrong. Please try after sometime.";
        //            }
        //        }
        //    }
        //    return View(updateDegree);
        //}
        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    //string endPoint = _configuration["EndPoint:CivicaApi"];
        //    var apiUrl = $"{endPoint}Degree/GetDegreeById/" + id;
        //    var response = _httpClientService.GetHttpResponseMessage<DegreeViewModel>(apiUrl, HttpContext.Request);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string data = response.Content.ReadAsStringAsync().Result;
        //        var serviceResponse = JsonConvert
        //            .DeserializeObject<ServiceResponse<DegreeViewModel>>(data);
        //        if (serviceResponse != null && serviceResponse.Success && serviceResponse.Data != null)
        //        {
        //            return View(serviceResponse.Data);
        //        }
        //        else
        //        {
        //            TempData["ErrorMessage"] = serviceResponse.Message;
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    else
        //    {
        //        string errorData = response.Content.ReadAsStringAsync().Result;
        //        var errorResponse = JsonConvert
        //            .DeserializeObject<ServiceResponse<DegreeViewModel>>(errorData);
        //        if (errorResponse != null)
        //        {
        //            TempData["ErrorMessage"] = errorResponse.Message;
        //        }
        //        else
        //        {
        //            TempData["ErrorMessage"] = "Something went wrong. Please try after sometime.";
        //        }

        //        return RedirectToAction("Index");
        //    }
        //}
        //[HttpPost]
        //public IActionResult DeleteConfirmed(int degreeId)
        //{
        //    //string endPoint = _configuration["EndPoint:CivicaApi"];
        //    var apiUrl = $"{endPoint}Degree/Remove/" + degreeId;
        //    //var response = _httpClientService.GetHttpResponseMessage<string>(apiUrl, HttpContext.Request);

        //    var response = _httpClientService.ExecuteApiRequest<ServiceResponse<string>>
        //        ($"{apiUrl}", HttpMethod.Delete, HttpContext.Request);

        //    if (response.Success)
        //    {
        //        TempData["SuccessMessage"] = response.Message;
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        TempData["ErrorMessage"] = response.Message;
        //        return RedirectToAction("Index");
        //    }


        //}
    }
}
