using RecruitmentProcessApi.Models;

namespace RecruitmentProcessApi.Validations
{
    public interface IworkFlowValidator
    {
        bool IsExistWorkflowOrderNo(WorkflowStep w);

    }
}
