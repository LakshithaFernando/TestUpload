using RecruitmentProcessApi.DTOs;
using RecruitmentProcessApi.Exceptions;
using RecruitmentProcessApi.Models;
using RecruitmentProcessApi.Validations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecruitmentProcessApi.Repository
{
    public class RecruitmentRepository : IrecruitmentRepository
    {
        private readonly RecruitmentContext context;
        private IrecruitmentValidator validator;

        public RecruitmentRepository(RecruitmentContext context)
        {
            this.context = context;
            validator = new RecruitmentValidator(this.context);
        }

        public IEnumerable<RecruitmentDTO> Get(string id)
        {
            try
            {
                var result = (from ap in context.applicantProfiles
                              join ws in context.workFlowSteps on ap.WorkFlowId equals ws.OrderNo
                              where ap.ApplicantNo.Equals(id) && ws.IsMainWorkflow && ws.IsActive
                              select new RecruitmentDTO
                              {
                                  WorkFlowName = ws.Description,
                                  Status = ap.IsSuccess
                              }).AsEnumerable();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Save(ApplicantProfile applicantProfile)
        {
            if (validator.IsActiveWorkflow(applicantProfile.WorkFlowId))
            {
                var obj = context.applicantProfiles.Where(a => a.ApplicantNo.Equals(applicantProfile.ApplicantNo)
                                                                                && a.WorkFlowId == applicantProfile.WorkFlowId)
                                                                .FirstOrDefault();

                if (obj == null)
                {
                    context.applicantProfiles.Add(applicantProfile);
                }
                else
                {
                    obj.IsSuccess = applicantProfile.IsSuccess;
                }
                context.SaveChanges(); 
            }
            else
            {
                throw new InactiveWorkflowException("Inactive Workflow");
            }
        }
    }
}
