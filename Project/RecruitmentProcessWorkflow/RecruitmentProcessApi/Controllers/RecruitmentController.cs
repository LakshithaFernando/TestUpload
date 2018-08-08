using Microsoft.AspNetCore.Mvc;
using RecruitmentProcessApi.DTOs;
using RecruitmentProcessApi.Models;
using RecruitmentProcessApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace RecruitmentProcessApi.Controllers
{
    [Produces("application/json")]
    [Route("api/recruitment")]
    public class RecruitmentController : Controller
    {
        private readonly IrecruitmentRepository repository;

        //Constructor
        public RecruitmentController(IrecruitmentRepository repository) => this.repository = repository;

        [HttpPost]
        [Route("save")]
        public IActionResult SaveRecruitment([FromBody]ApplicantProfile applicantProfile)
        {
            try
            {
                repository.Save(applicantProfile);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("get/{applicantNo}")]
        public IEnumerable<RecruitmentDTO> GetRecruitmentDetails(string applicantNo)
        {
            try
            {
                var result = repository.Get(applicantNo);
                if (result.Count() > 0)
                {
                    return result;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("selection/{orderId}/{applicantNo}")]
        public IActionResult Selection(int orderId, string applicantNo, [FromBody]SelectionDTO selection)
        {
            try
            {
                if (selection != null)
                {

                    bool isSuccess = (selection.IsAseniorDeveloper && selection.IsGraduate
                                                                        && (selection.YearsOfExperience >= 5));

                    var profile = new ApplicantProfile
                    {
                        ApplicantNo = applicantNo,
                        WorkFlowId = orderId,
                        IsSuccess = isSuccess
                    };
                    repository.Save(profile);
                    return Ok(profile);
                }
                return BadRequest(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("assessment/{orderId}/{applicantNo}")]
        public IActionResult Assessment(int orderId, string applicantNo, [FromBody]AssessmentDTO assessment)
        {
            try
            {
                if (assessment != null)
                {
                    bool isSuccess = (assessment.IsCoreAPIused && (assessment.IsAngularUsed || assessment.IsMvcUsed)
                                                                                                       && assessment.IsDIused);

                    var profile = new ApplicantProfile
                    {
                        ApplicantNo = applicantNo,
                        WorkFlowId = orderId,
                        IsSuccess = isSuccess
                    };
                    repository.Save(profile);
                    return Ok(profile);
                }
                return BadRequest(HttpStatusCode.BadRequest);
            }
            catch (Exception)
            {
                return BadRequest(HttpStatusCode.BadRequest);
            }
        }


        [HttpPost]
        [Route("technical/{orderId}/{applicantNo}")]
        public IActionResult TechnicalInterView(int orderId, string applicantNo, [FromBody]TechnicalDTO technical)
        {
            try
            {
                if (technical != null)
                {
                    bool isSuccess = (technical.isKnowDesignPattern && technical.isKnowMVC);

                    var profile = new ApplicantProfile
                    {
                        ApplicantNo = applicantNo,
                        WorkFlowId = orderId,
                        IsSuccess = isSuccess
                    };
                    repository.Save(profile);
                    return Ok(profile);
                }
                return BadRequest(HttpStatusCode.BadRequest);
            }
            catch (Exception)
            {
                return BadRequest(HttpStatusCode.BadRequest);
            }
        }


        [HttpPost]
        [Route("hr/{orderId}/{applicantNo}")]
        public IActionResult HrInterview(int orderId, string applicantNo, [FromBody]HrDTO hr)
        {
            try
            {
                if (hr != null)
                {
                    bool isSuccess = (hr.NoticePeriod < 2 && hr.Salary <= 20000 && hr.IsEnglishFluent);
                    var profile = new ApplicantProfile
                    {
                        ApplicantNo = applicantNo,
                        WorkFlowId = orderId,
                        IsSuccess = isSuccess
                    };
                    repository.Save(profile);
                    return Ok(profile);
                }
                return BadRequest(HttpStatusCode.BadRequest);
            }
            catch (Exception)
            {
                return BadRequest(HttpStatusCode.BadRequest);
            }
        }


        [HttpPost]
        [Route("final/{orderId}/{applicantNo}")]
        public IActionResult FinalInterView(int orderId, string applicantNo, [FromBody]FinalDTO final)
        {
            try
            {
                if (final != null)
                {
                    bool isSuccess = (final.IsAteamPlayer && final.IsEnglishSpeaking && final.IsGoodPersonality);
                    var profile = new ApplicantProfile
                    {
                        ApplicantNo = applicantNo,
                        WorkFlowId = orderId,
                        IsSuccess = isSuccess
                    };
                    repository.Save(profile);
                    return Ok(profile);
                }
                return BadRequest(HttpStatusCode.BadRequest);
            }
            catch (Exception)
            {
                return BadRequest(HttpStatusCode.BadRequest);
            }
        }
    }
}