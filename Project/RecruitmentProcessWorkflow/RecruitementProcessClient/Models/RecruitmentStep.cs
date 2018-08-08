using System.ComponentModel.DataAnnotations;

namespace RecruitmentProcessClient.Models
{
    public class RecruitmentStep
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Workflow Name")]
        public string Description { get; set; }
        [Display(Name ="Is Active")]
        public bool IsActive { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Only positive numbers are allowed")]
        [Required]
        [Display(Name = "Sequence no")]
        public int OrderNo { get; set; }
    }
}