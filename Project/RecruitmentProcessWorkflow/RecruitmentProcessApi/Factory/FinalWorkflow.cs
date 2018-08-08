using RecruitmentProcessApi.DTOs;

namespace RecruitmentProcessApi.Factory
{
    public class FinalWorkflow : IworkflowFactory
    {
        private readonly FinalDTO finalDTO;
        public FinalWorkflow(FinalDTO finalDTO)
        {
            this.finalDTO = finalDTO;
        }
        public bool IsSuccess()
        {
            return (finalDTO.IsAteamPlayer && finalDTO.IsEnglishSpeaking 
                                                    && finalDTO.IsGoodPersonality);
        }
    }
}
