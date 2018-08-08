using Newtonsoft.Json;
using RecruitementProcessClient.Util;
using RecruitmentProcessClient.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RecruitmentProcessClient.Controllers
{
    public class RecruitmentController : Controller
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
                                                                    (response.Content.ReadAsStringAsync().Result)
                                                                    .Where(r => r.IsActive);
                    return View(steps);
                }
                else
                {
                    return View(HttpStatusCode.BadRequest);
                }
            }
        }

        public ActionResult Recruitment(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applications/json"));
                var response = client.GetAsync("api/workflow/get/" + id.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    RecruitmentStep step = JsonConvert
                                            .DeserializeObject<RecruitmentStep>
                                                (response.Content.ReadAsStringAsync().Result);

                    return View("Update", step);
                }
                else
                {
                    return View(HttpStatusCode.BadRequest);
                }
            }
        }

        public async Task<ActionResult> Update(RecruitmentStep recruitmentStep)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    var content = new StringContent(JsonConvert.SerializeObject(recruitmentStep),
                                                                        Encoding.UTF8, "application/Json");
                    var responseMessage = await client.PostAsync("api/workflow/update", content);
                    responseMessage.EnsureSuccessStatusCode();

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Error"] = ErrorData.GetError(null, false);

                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ErrorData.GetError(ex.Message);
            }

            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public async Task<ActionResult> Save(RecruitmentStep recruitmentStep)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseAddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    var content = new StringContent(JsonConvert.SerializeObject(recruitmentStep),
                                                                        Encoding.UTF8, "application/Json");
                    var responseMessage = await client.PostAsync("api/workflow/save", content);
                    responseMessage.EnsureSuccessStatusCode();

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Error"] = ErrorData.GetError(null, false);

                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ErrorData.GetError(ex.Message);
            }

            return View("Add");
        }

        public ActionResult ViewProcess()
        {
            return View();
        }

        public JsonResult Get(string applicantNo)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applications/json"));
                var response = client.GetAsync("api/recruitment/get/" + applicantNo).Result;

                if (response.IsSuccessStatusCode)
                {
                    var obj = response.Content.ReadAsStringAsync().Result;
                    return Json(obj, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Error = "Error", message = "Bad Request" });
                }

            }
        }
    }
}