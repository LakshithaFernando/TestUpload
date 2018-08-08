using RecruitmentProcessApi.Models;
using System;
using System.Linq;

namespace RecruitmentProcessApi.Validations
{
    public class WorkflowValidator : IworkFlowValidator
    {
        private RecruitmentContext context;

        public WorkflowValidator(RecruitmentContext context)
        {
            this.context = context;
        }

        public bool IsExistWorkflowOrderNo(WorkflowStep workFlow)
        {
            if (workFlow.IsActive)
            {
                var result = this.context.workFlowSteps
                                      .Where(w => w.OrderNo.Equals(workFlow.OrderNo)
                                           && w.IsActive && !w.Id.Equals(workFlow.Id))
                                                  .FirstOrDefault();

                return (result != null); 
            }

            return false;
        }

        public bool IsActiveWorkflow(int o)
        {
            throw new NotImplementedException();
        }

    }
}
