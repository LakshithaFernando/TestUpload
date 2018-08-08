namespace RecruitmentProcessApi.Models.Interfaces
{
    interface IApplicantProfile
    {
        int Id { get; set; }
        string ApplicantNo { get; set; }
        int WorkFlowId { get; set; }
        bool IsSuccess { get; set; }
    }
}
