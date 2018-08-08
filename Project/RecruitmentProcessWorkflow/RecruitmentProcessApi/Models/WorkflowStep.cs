using RecruitmentProcessApi.Models.Interfaces;

namespace RecruitmentProcessApi.Models
{
    public class WorkflowStep : IWorkflowStep
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsMainWorkflow { get; set; }
        public int OrderNo { get; set; }
       
    }
}
