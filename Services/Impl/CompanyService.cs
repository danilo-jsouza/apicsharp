using Domain.DTO.Request.Company;
using Domain.DTO.Response.Company;
using Domain.Models;
using Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _company;
        private readonly IUnitOfWork _unit;
        public CompanyService(ICompanyRepository company, IUnitOfWork unit)
        {
            _company = company;
            _unit = unit;
        }
        public async Task<CompanyResponse> CreateCompany(CompanyRequest companyRequest, CancellationToken ct)
        {
            try
            {
                Company existingCompany = _company.FirstOrDefault(com => com.Cnpj == companyRequest.Cnpj);
                if (existingCompany == null)
                {
                    var company = new Company
                    {
                        EntityId = Guid.NewGuid(),
                        CompanyName = companyRequest.CompanyName,
                        FantasyName = companyRequest.FantasyName,
                        Email = companyRequest.Email,
                        Cnpj = companyRequest.Cnpj,
                        UserType = Domain.Enum.UserEnum.Company
                    };
                    _company.Add(company);
                    existingCompany = company;
                }
                else
                {
                    existingCompany.CompanyName = companyRequest.CompanyName;
                    existingCompany.FantasyName = companyRequest.FantasyName;
                    existingCompany.Email = companyRequest.Email;
                    _company.Update(existingCompany);
                }
                await _unit.CommitAsync(ct);
                var response = new CompanyResponse
                {
                    Id = existingCompany.Id,
                    CompanyName = existingCompany.CompanyName,
                    FantasyName = existingCompany.FantasyName,
                    Cnpj = existingCompany.Cnpj,
                    Email = existingCompany.Email
                };

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteCompany(int id, CancellationToken ct)
        {
            try
            {
                IQueryable<Company> query = _company;
                var response = await query.FirstOrDefaultAsync(com => com.Id == id, ct);
                
                if (response == null)
                    return false;

                _company.Delete(response);
                await _unit.CommitAsync(ct);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<IEnumerable<CompanyResponse>> GetAllCompany(CancellationToken ct)
        {
            try
            {
                IQueryable<Company> query = _company;
                var response = await query
                    .OrderBy(com => com.CompanyName)
                    .Take(100)
                    .Select(com => new CompanyResponse
                    {
                        Cnpj = com.Cnpj,
                        Email = com.Email,
                        FantasyName = com.FantasyName,
                        CompanyName = com.CompanyName,
                        Id = com.Id,
                        Active = com.Active
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

        public async Task<CompanyResponse> GetPerIdCompany(int id, CancellationToken ct)
        {
            try
            {
                IQueryable<Company> query = _company;
                var response = await query.FirstOrDefaultAsync(com => com.Id == id, ct);

                if (response == null)
                    return null;

                return new CompanyResponse
                {
                    Id = response.Id,
                    CompanyName = response.CompanyName,
                    FantasyName = response.FantasyName,
                    Cnpj = response.Cnpj,
                    Email = response.Email,
                    Active = response.Active
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
