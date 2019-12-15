using Domain.DTO.Request.Freelancer;
using Domain.DTO.Response.Freelancer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IFreelancerService
    {
        Task<FreelancerResponse> CreateFreelancer(FreelancerRequest freelancerRequest, CancellationToken ct);
        Task<IEnumerable<FreelancerResponse>> GetAllFreelancer(CancellationToken ct);
        Task<FreelancerResponse> GetPerIdFreelancer(int id, CancellationToken ct);
        Task<bool> DeleteFreelancer(int id, CancellationToken ct);
    }
}
