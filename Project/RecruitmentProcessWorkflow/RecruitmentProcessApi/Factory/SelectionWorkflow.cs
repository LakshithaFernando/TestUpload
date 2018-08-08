using RecruitmentProcessApi.DTOs;

namespace RecruitmentProcessApi.Factory
{
    public class SelectionWorkflow : IworkflowFactory
    {
        private readonly SelectionDTO selectionDTO;
        public SelectionWorkflow(SelectionDTO selectionDTO)
        {
            this.selectionDTO = selectionDTO;
        }

        public bool IsSuccess()
        {
            return (selectionDTO.IsAseniorDeveloper && selectionDTO.IsGraduate
                                               && (selectionDTO.YearsOfExperience >= 5));
        }
    }
}
