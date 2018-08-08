using RecruitmentProcessApi.DTOs;

namespace RecruitmentProcessApi.Factory
{
    public class HrWorkflow : IworkflowFactory
    {
        private readonly HrDTO hrDTO;
        public HrWorkflow(HrDTO hrDTO)
        {
            this.hrDTO = hrDTO;
        }
        public bool IsSuccess()
        {
            return (hrDTO.NoticePeriod < 2 && hrDTO.Salary <= 20000 
                                                    && hrDTO.IsEnglishFluent);
        }
    }
}
