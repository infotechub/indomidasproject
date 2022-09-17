using ComplaintService.Client.Models;
using ComplaintService.Client.Services;
using ComplaintService.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ComplaintService.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        public ITokenService _tokenService { get; }
        private readonly IComplainHttpClient _complainHttpClient;
       
        public HomeController(ILogger<HomeController> logger, ITokenService tokenService, IComplainHttpClient complainHttpClient)
        {
            _logger = logger;
            _tokenService = tokenService;
            _complainHttpClient = complainHttpClient;
        }

        


        public async Task<IActionResult> Index()
        {
            var httpClient = await _complainHttpClient.GetClient();

            var response = await httpClient.GetAsync("api/convertion").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var complainString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var conversionViewModel = JsonConvert.DeserializeObject<List<ConversionVM>>(complainString).ToList();

                var convlist = from aereply in conversionViewModel
                               select new
                               {
                                   Id = aereply.Id,
                                   Name = aereply.MeasurementType,
                                   ConvFrom = aereply.ConvertFrom,
                                   ConvTo = aereply.ConvertTo,
                                   Isdeleted = aereply.IsDeleted,
                               };

                var convert = convlist.ToList();




                ViewBag.convertList = convert.OrderBy(x => x.Id).Where(x => x.Isdeleted == false).ToList().OrderBy(x => x.Name);
                var convertList = convert.OrderBy(x => x.Id).Where(x => x.Isdeleted == false).ToList().OrderBy(x => x.Name);

                ViewBag.MeasureList = convert.OrderBy(x => x.Id).ToList().OrderBy(x => x.Name);

                return View(conversionViewModel);

                //return Json(convertList);

            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            throw new Exception($"There is a problem with fetching data from the Complain API: {response.ReasonPhrase}");
        }


        public async Task<IActionResult> Measurementtt(string measurementtype)
        {
            var httpClient = await _complainHttpClient.GetClient();

            var response = await httpClient.GetAsync("api/convertion").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var complainString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var conversionViewModel = JsonConvert.DeserializeObject<List<ConversionVM>>(complainString).ToList();

                var convlist = from aereply in conversionViewModel
                               select new
                               {
                                   Id = aereply.Id,
                                   Name = aereply.MeasurementType,
                                   ConvFrom = aereply.ConvertFrom,
                                   ConvTo = aereply.ConvertTo,
                                   Isdeleted = aereply.IsDeleted,
                               };

                var convert = convlist.ToList();



              
                ViewBag.convertList = convert.OrderBy(x => x.Id).Where(x => x.Isdeleted == false).ToList().OrderBy(x => x.Name);
                var convertList = convert.OrderBy(x => x.Id).Where(x => x.Name == measurementtype).ToList().OrderBy(x => x.ConvFrom);
              

                var convtt = from aereply in convertList
                               select new
                               {
                                   Id = aereply.Id,
                                   Name = aereply.ConvFrom
                                  
                               };

                var reslt = convtt.ToList();
                ViewBag.MeasureList = convert.OrderBy(x => x.Id).ToList().OrderBy(x => x.Name);
                
                // return View(conversionViewModel);

                return Json(reslt);

            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            throw new Exception($"There is a problem with fetching data from the Complain API: {response.ReasonPhrase}");
        }

        public async Task<IActionResult> Measurementtttt(string measurementtype)
        {
            var httpClient = await _complainHttpClient.GetClient();

            var response = await httpClient.GetAsync("api/convertion").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var complainString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var conversionViewModel = JsonConvert.DeserializeObject<List<ConversionVM>>(complainString).ToList();

                var convlist = from aereply in conversionViewModel
                               select new
                               {
                                   Id = aereply.Id,
                                   Name = aereply.MeasurementType,
                                   ConvFrom = aereply.ConvertFrom,
                                   ConvTo = aereply.ConvertTo,
                                   Isdeleted = aereply.IsDeleted,
                               };

                var convert = convlist.ToList();




                ViewBag.convertList = convert.OrderBy(x => x.Id).Where(x => x.Isdeleted == false).ToList().OrderBy(x => x.Name);
                var convertList = convert.OrderBy(x => x.Id).Where(x => x.Name == measurementtype).ToList().OrderBy(x => x.ConvTo);


                var convtt = from aereply in convertList
                             select new
                             {
                                 Id = aereply.Id,
                                 Name = aereply.ConvTo

                             };

                var reslt = convtt.ToList();
                ViewBag.MeasureList = convert.OrderBy(x => x.Id).ToList().OrderBy(x => x.Name);

                // return View(conversionViewModel);

                return Json(reslt);

            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            throw new Exception($"There is a problem with fetching data from the Complain API: {response.ReasonPhrase}");
        }
        public async Task<IActionResult> Measurementt(int Id)
        {
            var httpClient = await _complainHttpClient.GetClient();

            var response = await httpClient.GetAsync("api/convertion/1").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var complainString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var conversionViewModel = JsonConvert.DeserializeObject<List<ConversionVM>>(complainString).ToList();

                var convlist = from aereply in conversionViewModel
                               select new
                               {
                                   Id = aereply.Id,
                                   Name = aereply.MeasurementType,
                                   ConvFrom = aereply.ConvertFrom,
                                   ConvTo = aereply.ConvertTo,
                                   Isdeleted = aereply.IsDeleted,
                               };

                var convert = convlist.ToList();




                ViewBag.convertList = convert.OrderBy(x => x.Id).Where(x => x.Isdeleted == false).ToList().OrderBy(x => x.Name);

                ViewBag.MeasureList = convert.OrderBy(x => x.Id).ToList().OrderBy(x => x.Name);

                return View(conversionViewModel);

            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            throw new Exception($"There is a problem with fetching data from the Complain API: {response.ReasonPhrase}");
        }

        public async Task<IActionResult> ComplaintDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var httpClient = await _complainHttpClient.GetClient();

            var response = await httpClient.GetAsync("api/complaint/1").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var complainString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var complainViewModel = JsonConvert.DeserializeObject<ComplainVM>(complainString);
                    //ViewBag.Id = complainViewModel.Id;


                return View(complainViewModel);

            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            throw new Exception($"There is a problem with fetching data from the Complain API: {response.ReasonPhrase}");

        }

        // [HttpPost]
        public async Task<IActionResult> MeasurementConversion(string measurementtype, string convfrom, string convto, int measurementvalue)
        {
            if(measurementtype == null && convfrom == null && convto == null && measurementvalue == 0)
            {
                return NotFound();
            }
            if (convfrom == convto)
            {
                var err = "You can not convert from" + convfrom + "to" + convto;
            }

            var httpClient = await _complainHttpClient.GetClient();

            var response = await httpClient.GetAsync("api/convertion").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var complainString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var conversionViewModel = JsonConvert.DeserializeObject<List<ConversionVM>>(complainString).ToList();

                var convlist = from aereply in conversionViewModel
                               select new
                               {
                                   Id = aereply.Id,
                                   Name = aereply.MeasurementType,
                                   ConvFrom = aereply.ConvertFrom,
                                   ConvTo = aereply.ConvertTo,
                                   Isdeleted = aereply.IsDeleted,
                                   Metric2Imperial = aereply.Metric2imperial,
                                   Imperial2Metric = aereply.Imperial2Metric
                               };

                var convert = convlist.ToList();
                var convertLis = convert.OrderBy(x => x.Id).Where(x => x.Name == measurementtype && x.ConvFrom == convfrom && x.ConvTo == convto).FirstOrDefault();
                var singledata = convert.OrderBy(x => x.Id).FirstOrDefault();
                
                if (singledata.Metric2Imperial != null)
                {
                    if (convfrom == "Celsius")
                    {
                      
                        var ans = (measurementvalue * Convert.ToDouble(singledata.Metric2Imperial)) + 5;
                        return Json(ans);
                    }
                    if(convfrom == "Kilometer")
                    {
                        var ans = measurementvalue / Convert.ToDouble(singledata.Metric2Imperial);
                        return Json(ans);
                    }
                    if (convfrom == "Litre")
                    {
                        var ans = measurementvalue / Convert.ToDouble(singledata.Metric2Imperial);
                        return Json(ans);
                    }
                    if (convfrom == "Kilogram")
                    {
                        var ans = measurementvalue * Convert.ToDouble(singledata.Metric2Imperial);
                        return Json(ans);

                    }
                    if (convfrom == "Acres")
                    {
                        var ans = measurementvalue / Convert.ToDouble(singledata.Metric2Imperial);
                        return Json(ans);
                    }
                    
                    
                }
                else
                {

                    if (convfrom == "Fahrenheit")
                    {
                        var ans = (measurementvalue - 32) * Convert.ToDouble(singledata.Imperial2Metric);
                        return Json(ans);
                    }
                    if (convfrom == "Meter")
                    {
                        var ans = measurementvalue * Convert.ToDouble(singledata.Imperial2Metric);
                        return Json(ans);
                    }
                    if (convfrom == "Gallon")
                    {
                        var ans = measurementvalue * Convert.ToDouble(singledata.Imperial2Metric);
                        return Json(ans);
                    }
                    if (convfrom == "Pound")
                    {
                        var ans = measurementvalue / Convert.ToDouble(singledata.Imperial2Metric);
                        return Json(ans);
                    }
                    if (convfrom == "Square Meters")
                    {
                        var ans = measurementvalue * Convert.ToDouble(singledata.Imperial2Metric);
                        return Json(ans);
                    }
                
                }
                

            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            throw new Exception($"There is a problem with fetching data from the Complain API: {response.ReasonPhrase}");

        }

        public IActionResult Complaint()
        {
            return View();
        }

        

        //public async Task<IActionResult> Weather()
        //{
        //    var data = new List<WeatherModel>();
        //    var token = await _tokenService.GetToken("complaintApi.read");
        //    using (var client = new HttpClient())
        //    {
        //        client.SetBearerToken(token.AccessToken);
        //        var result = await client.GetAsync("https://localhost:44393/weatherforecast");
        //        if (result.IsSuccessStatusCode)
        //        {
        //            var model = await result.Content.ReadAsStringAsync();
        //            data = JsonConvert.DeserializeObject<List<WeatherModel>>(model);
        //            return View(data);
        //        }
        //        else
        //        {
        //            throw new Exception("Failed to get Data from API");
        //        }
        //    }
        //}



        public async Task<IActionResult> Weather()
        {
            var httpClient = await _complainHttpClient.GetClient();

            var response = await httpClient.GetAsync("api/complaint").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var complainString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var complainViewModel = JsonConvert.DeserializeObject<List<ComplainVM>>(complainString).ToList();

                return View(complainViewModel);
            }

            throw new Exception($"There is a problem with fetching data from the Complain API: {response.ReasonPhrase}");
        }

        [Authorize(Policy = "CanCreateAndModifyData")]
        public async Task<IActionResult> Privacy()
        {
            var client = new HttpClient();
            var metaDataResponse = await client.GetDiscoveryDocumentAsync("https://localhost:5005");
            var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            var response = await client.GetUserInfoAsync(new UserInfoRequest
            {
                Address = metaDataResponse.UserInfoEndpoint,
                Token = accessToken
            });
            if (response.IsError)
            {
                throw new Exception("Problem while fetching data from the UserInfo endpoint", response.Exception);
            }
            var addressClaim = response.Claims.FirstOrDefault(c => c.Type.Equals("address"));
            User.AddIdentity(new ClaimsIdentity(new List<Claim> { new Claim(addressClaim.Type.ToString(), addressClaim.Value.ToString()) }));
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
