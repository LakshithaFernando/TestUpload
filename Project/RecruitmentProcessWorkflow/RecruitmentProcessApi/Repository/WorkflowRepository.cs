using RecruitmentProcessApi.Exceptions;
using RecruitmentProcessApi.Models;
using RecruitmentProcessApi.Repository.Interfaces;
using RecruitmentProcessApi.Validations;
using System.Collections.Generic;
using System.Linq;

namespace RecruitmentProcessApi.Repository
{
    public class WorkflowRepository : IworkflowRepository
    {
        private readonly RecruitmentContext context;
        private IworkFlowValidator workflowValidator;

        public WorkflowRepository(RecruitmentContext context)
        {
            this.context = context;
            workflowValidator = new WorkflowValidator(this.context);
        }

        public void AddWorkFlow(WorkflowStep workFlowStep)
        {
            if (!workflowValidator.IsExistWorkflowOrderNo(workFlowStep))
            {
                context.workFlowSteps.Add(workFlowStep);
                context.SaveChanges();
            }
            else
            {
                throw new DuplicateOrderIdException();
            }
        }

        public WorkflowStep GetWorkFlow(int id) => context.workFlowSteps
                    .Where(w => w.Id.Equals(id))
                        .FirstOrDefault();

        public IEnumerable<WorkflowStep> GetWorkFlows() => context.workFlowSteps
                                                             .AsEnumerable().OrderBy(w => w.OrderNo)
                                                                    .ThenBy(w => w.IsActive);

        public void UpdateWorkFlow(WorkflowStep workFlowStep)
        {
            if (!workflowValidator.IsExistWorkflowOrderNo(workFlowStep))
            {
                var wfs = context.workFlowSteps.Find(workFlowStep.Id);
                if (wfs != null)
                {
                    wfs.IsActive = workFlowStep.IsActive;
                    wfs.OrderNo = workFlowStep.OrderNo;
                    wfs.Description = workFlowStep.Description;
                    context.workFlowSteps.Update(wfs);
                    context.SaveChanges();
                }
            }
            else
            {
                throw new DuplicateOrderIdException();
            }
        }
    }
}
