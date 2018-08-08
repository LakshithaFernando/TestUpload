using RecruitmentProcessApi.Models;
using System;
using System.Linq;

namespace RecruitmentProcessApi.Validations
{
    public class RecruitmentValidator : IrecruitmentValidator
    {
        private RecruitmentContext context;

        public RecruitmentValidator(RecruitmentContext context)
        {
            this.context = context;
        }
        public bool IsActiveWorkflow(int orderId)
        {
            var isActive = (from w in context.workFlowSteps
                            where w.OrderNo.Equals(orderId) &&
                                w.IsMainWorkflow && w.IsActive
                            select w);

            return isActive.Count() > 0;
        }
    }
}
