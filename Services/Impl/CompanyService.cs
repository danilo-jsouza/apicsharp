using Domain.DTO.Request.Company;
using Domain.DTO.Response.Company;
using Domain.Exceptions;
using Domain.Models;
using Domain.Models.Adress;
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
                        UserType = Domain.Enum.UserEnum.Company,
                        CompanyAdress = new CompanyAdress
                        {
                            City = companyRequest.CompanyAdressRequest.City,
                            State = companyRequest.CompanyAdressRequest.State
                        }
                    };
                    _company.Add(company);
                    existingCompany = company;
                }
                else
                {
                    existingCompany.CompanyName = companyRequest.CompanyName;
                    existingCompany.FantasyName = companyRequest.FantasyName;
                    existingCompany.Email = companyRequest.Email;
                    existingCompany.CompanyAdress.State = companyRequest.CompanyAdressRequest.State;
                    existingCompany.CompanyAdress.City = companyRequest.CompanyAdressRequest.City;
                    _company.Update(existingCompany);
                }
                await _unit.CommitAsync(ct);
                return new CompanyResponse
                {
                    Id = existingCompany.Id,
                    CompanyName = existingCompany.CompanyName,
                    FantasyName = existingCompany.FantasyName,
                    Cnpj = existingCompany.Cnpj,
                    Email = existingCompany.Email,
                    CompanyAdressResponse = new CompanyAdressResponse
                    {
                        City = existingCompany.CompanyAdress.City,
                        State = existingCompany.CompanyAdress.State
                    }
                };
            }
            catch (Exception ex) when (!(ex is BasicException))
            {
                throw new InternalServerError("Error processing your request.", ex);
            }
        }

        public async Task<bool> DeleteCompany(int id, CancellationToken ct)
        {
            try
            {
                IQueryable<Company> query = _company;
                var company = await query.FirstOrDefaultAsync(com => com.Id == id, ct);

                if (company == null)
                    throw new NotFoundException("Company not found.");

                _company.Delete(company);
                await _unit.CommitAsync(ct);
                return true;
            }
            catch (Exception ex) when (!(ex is BasicException))
            {
                throw new InternalServerError("Error processing your request.", ex);
            }

        }

        public async Task<IEnumerable<CompanyResponse>> GetAllCompany(CancellationToken ct)
        {
            try
            {
                IQueryable<Company> query = _company;
                var company = await query
                    .OrderBy(com => com.CompanyName)
                    .Take(100)
                    .Select(com => new CompanyResponse
                    {
                        Cnpj = com.Cnpj,
                        Email = com.Email,
                        FantasyName = com.FantasyName,
                        CompanyName = com.CompanyName,
                        Id = com.Id,
                        Active = com.Active,
                        CompanyAdressResponse = new CompanyAdressResponse
                        {
                            City = com.CompanyAdress.City,
                            State = com.CompanyAdress.State
                        }
                    }).ToListAsync(ct);

                if (company == null)
                    throw new NotFoundException("Company not found.");

                return company;
            }
            catch (Exception ex) when (!(ex is BasicException))
            {
                throw new InternalServerError("Error processing your request.", ex);
            }
        }

        public async Task<CompanyResponse> GetPerIdCompany(int id, CancellationToken ct)
        {
            try
            {
                IQueryable<Company> query = _company;
                var company = await query.FirstOrDefaultAsync(com => com.Id == id, ct);

                if (company == null)
                    throw new NotFoundException("Company not found.");

                return new CompanyResponse
                {
                    Id = company.Id,
                    CompanyName = company.CompanyName,
                    FantasyName = company.FantasyName,
                    Cnpj = company.Cnpj,
                    Email = company.Email,
                    Active = company.Active,
                    CompanyAdressResponse = new CompanyAdressResponse
                    {
                        City = company.CompanyAdress.City,
                        State = company.CompanyAdress.State
                    }
                };

            }
            catch (Exception ex) when (!(ex is BasicException))
            {
                throw new InternalServerError("Error processing your request.", ex);
            }
        }
    }
}
