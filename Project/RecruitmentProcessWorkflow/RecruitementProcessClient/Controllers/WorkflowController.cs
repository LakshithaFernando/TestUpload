using Newtonsoft.Json;
using RecruitmentProcessClient.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace RecruitmentProcessClient.Controllers
{
    public class WorkflowController : Controller
    {

        private readonly string baseAddress = ConfigurationManager.AppSettings["BaseAddress"];

        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applications/json"));
                var response = client.GetAsync("api/workflow/get").Result;
                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<RecruitmentStep> steps = JsonConvert
                                                            .DeserializeObject<IEnumerable<RecruitmentStep>>
                                                                    (response.Content.ReadAsStringAsync().Result);
                    return View(steps);
                }
                else
                {
                    return View(HttpStatusCode.BadRequest);
                }
            }
        }
    }
}