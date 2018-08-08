using Microsoft.EntityFrameworkCore;

namespace RecruitmentProcessApi.Models
{
    public class RecruitmentContext : DbContext
    {
        public RecruitmentContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<WorkflowStep> workFlowSteps { get; set; }
        public DbSet<ApplicantProfile> applicantProfiles { get; set; }
    }
}
