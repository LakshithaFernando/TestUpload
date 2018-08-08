using RecruitmentProcessApi.DTOs;

namespace RecruitmentProcessApi.Factory
{
    public class AssessmentWorkflow : IworkflowFactory
    {
        private readonly AssessmentDTO assessmentDTO;
        public AssessmentWorkflow(AssessmentDTO assessmentDTO)
        {
            this.assessmentDTO = assessmentDTO;
        }
        public bool IsSuccess()
        {
            return (assessmentDTO.IsCoreAPIused && (assessmentDTO.IsAngularUsed || assessmentDTO.IsMvcUsed)
                                           && assessmentDTO.IsDIused);
        }
    }
}
