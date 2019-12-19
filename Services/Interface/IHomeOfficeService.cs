using Domain.DTO.Request.HomeOffice;
using Domain.DTO.Response.HomeOffice;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IHomeOfficeService
    {
        Task<HomeOfficeResponse> CreateHomeOffice(HomeOfficeRequest homeOfficeRequest, CancellationToken ct);
        Task<IEnumerable<HomeOfficeResponse>> GetAllHomeOffice(CancellationToken ct);
        Task<HomeOfficeResponse> GetPerIdHomeOffice(int id, CancellationToken ct);
        Task<bool> DeleteHomeOffice(int id, CancellationToken ct);
    }
}
