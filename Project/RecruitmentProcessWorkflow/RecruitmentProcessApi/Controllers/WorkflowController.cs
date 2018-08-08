using Microsoft.AspNetCore.Mvc;
using RecruitmentProcessApi.Exceptions;
using RecruitmentProcessApi.Models;
using RecruitmentProcessApi.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace RecruitmentProcessApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Workflow")]
    public class WorkflowController : Controller
    {
        private IworkflowRepository repository;

        //Constructor
        public WorkflowController(IworkflowRepository repository) => this.repository = repository;

        [HttpGet]
        [Route("get")]
        public IEnumerable<WorkflowStep> GetWorkFlowSteps() => repository.GetWorkFlows();

        [HttpGet]
        [Route("get/{id}")]
        public WorkflowStep GetWorkFlow(int id) => repository.GetWorkFlow(id);

        [HttpPost]
        [Route("update")]
        public IActionResult UpdateWorkFlow([FromBody]WorkflowStep workFlowStep)
        {
            try
            {
                repository.UpdateWorkFlow(workFlowStep);
                return Ok();
            }
            catch (DuplicateOrderIdException)
            {
                return StatusCode(501);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        [HttpPost]
        [Route("save")]
        public IActionResult AddWorkFlow([FromBody]WorkflowStep workFlowStep)
        {
            try
            {
                repository.AddWorkFlow(workFlowStep);
                return Ok();
            }
            catch (DuplicateOrderIdException)
            {
                return StatusCode(501);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}