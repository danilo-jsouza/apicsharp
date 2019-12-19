using Domain.DTO.Request.HomeOffice;
using Domain.DTO.Response.HomeOffice;
using Domain.Exceptions;
using Domain.Models;
using Domain.Models.Adress;
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

        public async Task<HomeOfficeResponse> CreateHomeOffice(HomeOfficeRequest homeOfficeRequest, CancellationToken ct)
        {
            try
            {
                HomeOffice existingHomeOffice = await _homeOffice.FirstOrDefaultAsync(hom => hom.Cpf == homeOfficeRequest.Cpf, ct);
                if (existingHomeOffice == null)
                {
                    var homeOffice = new HomeOffice
                    {
                        Cpf = homeOfficeRequest.Cpf,
                        Description = homeOfficeRequest.Description,
                        Email = homeOfficeRequest.Email,
                        EntityId = Guid.NewGuid(),
                        Experience = homeOfficeRequest.Experience,
                        Name = homeOfficeRequest.Name,
                        Portfolio = homeOfficeRequest.Portfolio,
                        Sexo = homeOfficeRequest.Sexo,
                        Skills = homeOfficeRequest.Skills,
                        UserType = Domain.Enum.UserEnum.HomeOffice,
                        HomeOfficeAdress = new HomeOfficeAdress
                        {
                            State = homeOfficeRequest.HomeOfficeAdressRequest.State,
                            City = homeOfficeRequest.HomeOfficeAdressRequest.City
                        }
                    };
                    _homeOffice.Add(homeOffice);
                    await _unit.CommitAsync(ct);
                    existingHomeOffice = homeOffice;
                }
                else
                {
                    existingHomeOffice.Cpf = homeOfficeRequest.Cpf;
                    existingHomeOffice.Description = homeOfficeRequest.Description;
                    existingHomeOffice.Email = homeOfficeRequest.Email;
                    existingHomeOffice.Experience = homeOfficeRequest.Experience;
                    existingHomeOffice.Name = homeOfficeRequest.Name;
                    existingHomeOffice.Portfolio = homeOfficeRequest.Portfolio;
                    existingHomeOffice.Sexo = homeOfficeRequest.Sexo;
                    existingHomeOffice.Skills = homeOfficeRequest.Skills;
                    existingHomeOffice.HomeOfficeAdress.City = homeOfficeRequest.HomeOfficeAdressRequest.City;
                    existingHomeOffice.HomeOfficeAdress.State = homeOfficeRequest.HomeOfficeAdressRequest.State;
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
                    Active = existingHomeOffice.Active,
                    HomeOfficeAdressResponse = new HomeOfficeAdressResponse
                    {
                        State = existingHomeOffice.HomeOfficeAdress.State,
                        City = existingHomeOffice.HomeOfficeAdress.City
                    }
                };
            }
            catch (Exception ex) when (!(ex is BasicException))
            {
                throw new InternalServerError("Error processing your request.", ex);
            }
        }

        public async Task<bool> DeleteHomeOffice(int id, CancellationToken ct)
        {
            try
            {
                IQueryable<HomeOffice> query = _homeOffice;
                var homeOffice = await query.FirstOrDefaultAsync(hom => hom.Id == id, ct);

                if (homeOffice == null)
                    throw new NotFoundException("Home Office not found.");

                _homeOffice.Delete(homeOffice);
                await _unit.CommitAsync(ct);
                return true;
            }
            catch (Exception ex) when (!(ex is BasicException))
            {
                throw new InternalServerError("Error processing your request.", ex);
            }
        }

        public async Task<IEnumerable<HomeOfficeResponse>> GetAllHomeOffice(CancellationToken ct)
        {
            try
            {
                IQueryable<HomeOffice> query = _homeOffice;
                var homeOffice = await query.OrderBy(hom => hom.Name).Select(hom => new HomeOfficeResponse
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
                    Active = hom.Active,
                    HomeOfficeAdressResponse = new HomeOfficeAdressResponse
                    {
                        City = hom.HomeOfficeAdress.City,
                        State = hom.HomeOfficeAdress.State
                    }
                }).ToListAsync(ct);

                if (homeOffice == null)
                    throw new NotFoundException("Home Office not found.");

                return homeOffice;
            }
            catch (Exception ex) when (!(ex is BasicException))
            {
                throw new InternalServerError("Error processing your request.", ex);
            }
        }

        public async Task<HomeOfficeResponse> GetPerIdHomeOffice(int id, CancellationToken ct)
        {
            try
            {
                IQueryable<HomeOffice> query = _homeOffice;
                var homeOffice = await query.FirstOrDefaultAsync(hom => hom.Id == id, ct);

                if (homeOffice == null)
                    throw new NotFoundException("Home Office not found.");

                return new HomeOfficeResponse
                {
                    Cpf = homeOffice.Cpf,
                    Description = homeOffice.Description,
                    Email = homeOffice.Email,
                    Experience = homeOffice.Experience,
                    Id = homeOffice.Id,
                    Name = homeOffice.Name,
                    Portfolio = homeOffice.Portfolio,
                    Sexo = homeOffice.Sexo,
                    Skills = homeOffice.Skills,
                    Active = homeOffice.Active,
                    HomeOfficeAdressResponse = new HomeOfficeAdressResponse
                    {
                        State = homeOffice.HomeOfficeAdress.State,
                        City = homeOffice.HomeOfficeAdress.City
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
