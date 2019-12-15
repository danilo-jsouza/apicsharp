using Domain.DTO.Request.Freelancer;
using Domain.DTO.Response.Freelancer;
using Domain.Models;
using Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class FreelancerService : IFreelancerService
    {
        private readonly IFreelancerRepository _freelancer;
        private readonly IUnitOfWork _unit;

        public FreelancerService(IFreelancerRepository freelancer, IUnitOfWork unit)
        {
            _freelancer = freelancer;
            _unit = unit;
        }
        public async Task<FreelancerResponse> CreateFreelancer(FreelancerRequest freelancerRequest, CancellationToken ct)
        {
            try
            {
                Freelancer existingFreelancer = await _freelancer.FirstOrDefaultAsync(free => free.Cpf == freelancerRequest.Cpf);
                if(existingFreelancer == null)
                {
                    var freelancer = new Freelancer
                    {
                        EntityId = Guid.NewGuid(),
                        Cpf = freelancerRequest.Cpf,
                        Name = freelancerRequest.Name,
                        Sexo = freelancerRequest.Sexo,
                        Skills = freelancerRequest.Skills,
                        Portfolio = freelancerRequest.Portfolio,
                        Experience = freelancerRequest.Experience,
                        Description = freelancerRequest.Description,
                        UserType = Domain.Enum.UserEnum.Freelancer,
                        Email = freelancerRequest.Email
                    };
                    _freelancer.Add(freelancer);
                    existingFreelancer = freelancer;
                }
                else
                {
                    existingFreelancer.Cpf = freelancerRequest.Cpf;
                    existingFreelancer.Description = freelancerRequest.Description;
                    existingFreelancer.Email = freelancerRequest.Email;
                    existingFreelancer.Experience = freelancerRequest.Experience;
                    existingFreelancer.Name = freelancerRequest.Name;
                    existingFreelancer.Portfolio = freelancerRequest.Portfolio;
                    existingFreelancer.Sexo = freelancerRequest.Sexo;
                    existingFreelancer.Skills = freelancerRequest.Skills;
                    _freelancer.Update(existingFreelancer);
                }
                await _unit.CommitAsync(ct);
                return new FreelancerResponse
                {
                    Cpf = existingFreelancer.Cpf,
                    Description = existingFreelancer.Description,
                    Email = existingFreelancer.Email,
                    Experience = existingFreelancer.Experience,
                    Id = existingFreelancer.Id,
                    Name = existingFreelancer.Name,
                    Portfolio = existingFreelancer.Portfolio,
                    Sexo = existingFreelancer.Sexo,
                    Skills = existingFreelancer.Skills
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteFreelancer(int id, CancellationToken ct)
        {
            IQueryable<Freelancer> query = _freelancer;
            var response = await query.FirstOrDefaultAsync(free => free.Id == id, ct);

            if (response == null)
                return false;

            _freelancer.Delete(response);
            await _unit.CommitAsync(ct);
            return true;
        }

        public async Task<IEnumerable<FreelancerResponse>> GetAllFreelancer(CancellationToken ct)
        {
            try
            {
                IQueryable<Freelancer> query = _freelancer;
                var response = await query.OrderBy(free => free.Name).Select(free => new FreelancerResponse
                {
                    Active = free.Active,
                    Cpf = free.Cpf,
                    Description = free.Description,
                    Email = free.Email,
                    Experience = free.Experience,
                    Id = free.Id,
                    Name = free.Name,
                    Portfolio = free.Portfolio,
                    Sexo = free.Sexo,
                    Skills = free.Skills
                }).ToListAsync(ct);

                if (response == null)
                    return null;

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FreelancerResponse> GetPerIdFreelancer(int id, CancellationToken ct)
        {
            IQueryable<Freelancer> query = _freelancer;
            var response = await query.FirstOrDefaultAsync(free => free.Id == id, ct);

            if (response == null)
                return null;

            return new FreelancerResponse
            {
                Active = response.Active,
                Cpf = response.Cpf,
                Description = response.Description,
                Email = response.Email,
                Experience = response.Experience,
                Id = response.Id,
                Name = response.Name,
                Portfolio = response.Portfolio,
                Sexo = response.Sexo,
                Skills = response.Skills
            };
        }
    }
}
