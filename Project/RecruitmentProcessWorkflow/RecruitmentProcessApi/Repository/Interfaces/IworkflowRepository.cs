using RecruitmentProcessApi.Models;
using System.Collections.Generic;

namespace RecruitmentProcessApi.Repository.Interfaces
{
    public interface IworkflowRepository
    {
        IEnumerable<WorkflowStep> GetWorkFlows();
        void UpdateWorkFlow(WorkflowStep w);
        void AddWorkFlow(WorkflowStep w);
        WorkflowStep GetWorkFlow(int i);
    }
}
