using Domain.DTO.Request.Company;
using Domain.DTO.Response.Company;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ICompanyService
    {
        Task<CompanyResponse> CreateCompany(CompanyRequest companyRequest, CancellationToken ct);
        Task<IEnumerable<CompanyResponse>> GetAllCompany(CancellationToken ct);
        Task<CompanyResponse> GetPerIdCompany(int id, CancellationToken ct);
        Task<bool> DeleteCompany(int id, CancellationToken ct);
    }   
}
