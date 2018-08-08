using RecruitmentProcessApi.DTOs;
using RecruitmentProcessApi.Models;
using System.Collections.Generic;

namespace RecruitmentProcessApi.Repository
{
    public interface IrecruitmentRepository
    {
        void Save(ApplicantProfile ap);
       IEnumerable<RecruitmentDTO> Get(string id);
    }
}
