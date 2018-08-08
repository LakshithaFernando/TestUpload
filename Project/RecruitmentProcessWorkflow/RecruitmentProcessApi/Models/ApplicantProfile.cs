using RecruitmentProcessApi.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentProcessApi.Models
{
    public class ApplicantProfile : IApplicantProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ApplicantNo { get; set; }
        public int WorkFlowId { get; set; }
        public bool IsSuccess { get; set; }
    }
}
