using Domain.DTO.Request.HomeOffice;
using Domain.DTO.Response.HomeOffice;
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
    public class HomeOfficeService : IHomeOfficeService
    {
        private readonly IHomeOfficeRepository _homeOffice;
        private readonly IUnitOfWork _unit;

        public HomeOfficeService(IHomeOfficeRepository homeOffice, IUnitOfWork unit)
        {
            _homeOffice = homeOffice;
            _unit = unit;
        }

        public async Task<HomeOfficeResponse> CreateHomeOffice(HomeOfficeRequest request, CancellationToken ct)
        {
            HomeOffice existingHomeOffice = await _homeOffice.FirstOrDefaultAsync(hom => hom.Cpf == request.Cpf, ct);
            if(existingHomeOffice == null)
            {
                var homeOffice = new HomeOffice
                {
                    Cpf = request.Cpf,
                    Description = request.Description,
                    Email = request.Email,
                    EntityId = Guid.NewGuid(),
                    Experience = request.Experience,
                    Name = request.Name,
                    Portfolio = request.Portfolio,
                    Sexo = request.Sexo,
                    Skills = request.Skills,
                    UserType = Domain.Enum.UserEnum.HomeOffice
                };
                _homeOffice.Add(homeOffice);
                await _unit.CommitAsync(ct);
            }
            else
            {
                existingHomeOffice.Cpf = request.Cpf;
                existingHomeOffice.Description = request.Description;
                existingHomeOffice.Email = request.Email;
                existingHomeOffice.Experience = request.Experience;
                existingHomeOffice.Name = request.Name;
                existingHomeOffice.Portfolio = request.Portfolio;
                existingHomeOffice.Sexo = request.Sexo;
                existingHomeOffice.Skills = request.Skills;
                _homeOffice.Update(existingHomeOffice);
                await _unit.CommitAsync(ct);
            }

            return new HomeOfficeResponse
            {
                Cpf = existingHomeOffice.Cpf,
                Description = existingHomeOffice.Description,
                Email = existingHomeOffice.Email,
                Experience = existingHomeOffice.Experience,
                Id = existingHomeOffice.Id,
                Name = existingHomeOffice.Name,
                Portfolio = existingHomeOffice.Portfolio,
                Sexo = existingHomeOffice.Sexo,
                Skills = existingHomeOffice.Skills,
                Active = existingHomeOffice.Active
            };
        }

        public async Task<bool> DeleteHomeOffice(int id, CancellationToken ct)
        {
            IQueryable<HomeOffice> query = _homeOffice;
            var response = await query.FirstOrDefaultAsync(hom => hom.Id == id, ct);

            if (response == null)
                return false;

            _homeOffice.Delete(response);
            await _unit.CommitAsync(ct);
            return true;
        }

        public async Task<IEnumerable<HomeOfficeResponse>> GetAllHomeOffice(CancellationToken ct)
        {
            IQueryable<HomeOffice> query = _homeOffice;
            var response = await query.OrderBy(hom => hom.Name).Select(hom => new HomeOfficeResponse
            {
                Cpf = hom.Cpf,
                Description = hom.Description,
                Email = hom.Email,
                Experience = hom.Experience,
                Id = hom.Id,
                Name = hom.Name,
                Portfolio = hom.Portfolio,
                Sexo = hom.Sexo,
                Skills = hom.Skills,
                Active = hom.Active
            }).ToListAsync(ct);

            if (response == null)
                return null;

            return response;
        }

        public async Task<HomeOfficeResponse> GetPerIdHomeOffice(int id, CancellationToken ct)
        {
            IQueryable<HomeOffice> query = _homeOffice;
            var response = await query.FirstOrDefaultAsync(hom => hom.Id == id, ct);

            if (response == null)
                return null;

            return new HomeOfficeResponse
            {
                Cpf = response.Cpf,
                Description = response.Description,
                Email = response.Email,
                Experience = response.Experience,
                Id = response.Id,
                Name = response.Name,
                Portfolio = response.Portfolio,
                Sexo = response.Sexo,
                Skills = response.Skills,
                Active = response.Active
            };
        }
    }
}
