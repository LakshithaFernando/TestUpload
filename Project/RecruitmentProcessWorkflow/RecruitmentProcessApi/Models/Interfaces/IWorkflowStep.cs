namespace RecruitmentProcessApi.Models.Interfaces
{
    public interface IWorkflowStep
    {
        int Id { get; set; }
        string Description { get; set; }
        bool IsActive { get; set; }
        bool IsMainWorkflow { get; set; }
        int OrderNo { get; set; }

    }
}
