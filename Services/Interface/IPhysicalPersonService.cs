using Domain.DTO.Request.PhysicalPerson;
using Domain.DTO.Response.PhysicalPerson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IPhysicalPersonService
    {
        Task<PhysicalPersonResponse> CreatePhysicalPerson(PhysicalPersonRequest physicalPersonRequest, CancellationToken ct);
        Task<IEnumerable<PhysicalPersonResponse>> GetAllPhysicalPerson(CancellationToken ct);
        Task<PhysicalPersonResponse> GetPerIdPhysicalPerson(int id, CancellationToken ct);
        Task<bool> DeletePhysicalPerson(int id, CancellationToken ct);
    }
}
