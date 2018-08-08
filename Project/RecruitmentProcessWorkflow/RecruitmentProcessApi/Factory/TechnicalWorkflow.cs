using RecruitmentProcessApi.DTOs;

namespace RecruitmentProcessApi.Factory
{
    public class TechnicalWorkflow : IworkflowFactory
    {
        private readonly TechnicalDTO technicalDTO;

        public TechnicalWorkflow(TechnicalDTO technicalDTO)
        {
            this.technicalDTO = technicalDTO;
        }
        public bool IsSuccess()
        {
            return (technicalDTO.isKnowDesignPattern && technicalDTO.isKnowMVC);
        }
    }
}
