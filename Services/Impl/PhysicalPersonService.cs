using Domain.DTO.Request.PhysicalPerson;
using Domain.DTO.Response.PhysicalPerson;
using Domain.Exceptions;
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
    public class PhysicalPersonService : IPhysicalPersonService
    {
        private readonly IPhysicalPersonRepository _physicalPerson;
        private readonly IUnitOfWork _unit;
        public PhysicalPersonService(IPhysicalPersonRepository physicalPerson, IUnitOfWork unit)
        {
            _physicalPerson = physicalPerson;
            _unit = unit;
        }
        public async Task<PhysicalPersonResponse> CreatePhysicalPerson(PhysicalPersonRequest physicalPersonRequest, CancellationToken ct)
        {
            try
            {
                PhysicalPerson existingPhysicalPerson = await _physicalPerson.FirstOrDefaultAsync(phy => phy.Cpf == physicalPersonRequest.Cpf, ct);

                if (existingPhysicalPerson == null)
                {
                    var physicalPerson = new PhysicalPerson
                    {
                        Cpf = physicalPersonRequest.Cpf,
                        Email = physicalPersonRequest.Email,
                        EntityId = Guid.NewGuid(),
                        Name = physicalPersonRequest.Name,
                        Sexo = physicalPersonRequest.Sexo,
                        UserType = Domain.Enum.UserEnum.PhysicalPerson
                    };
                    _physicalPerson.Add(physicalPerson);
                    await _unit.CommitAsync(ct);
                    existingPhysicalPerson = physicalPerson;
                }
                else
                {
                    existingPhysicalPerson.Cpf = physicalPersonRequest.Cpf;
                    existingPhysicalPerson.Email = physicalPersonRequest.Email;
                    existingPhysicalPerson.Name = physicalPersonRequest.Name;
                    existingPhysicalPerson.Sexo = physicalPersonRequest.Sexo;
                    _physicalPerson.Update(existingPhysicalPerson);
                    await _unit.CommitAsync(ct);
                }

                return new PhysicalPersonResponse
                {
                    Cpf = existingPhysicalPerson.Cpf,
                    Email = existingPhysicalPerson.Email,
                    Id = existingPhysicalPerson.Id,
                    Name = existingPhysicalPerson.Name,
                    Sexo = existingPhysicalPerson.Sexo
                };

            }
            catch (Exception ex)
            {
                throw new InternalServerError("Error processing your request.", ex);
            }
            
        }

        public async Task<bool> DeletePhysicalPerson(int id, CancellationToken ct)
        {
            try
            {
                IQueryable<PhysicalPerson> query = _physicalPerson;
                var physicalPerson = await query.FirstOrDefaultAsync(phy => phy.Id == id, ct);

                if (physicalPerson == null)
                    throw new NotFoundException("Physical Person not found.");

                _physicalPerson.Delete(physicalPerson);
                await _unit.CommitAsync(ct);
                return true;
            }
            catch (Exception ex)
            {
                throw new InternalServerError("Error processing your request.", ex);
            }
            
        }

        public async Task<IEnumerable<PhysicalPersonResponse>> GetAllPhysicalPerson(CancellationToken ct)
        {
            try
            {
                IQueryable<PhysicalPerson> query = _physicalPerson;
                var physicalPerson = await query.OrderBy(phy => phy.Name).Select(phy => new PhysicalPersonResponse
                {
                    Cpf = phy.Cpf,
                    Email = phy.Name,
                    Id = phy.Id,
                    Name = phy.Name,
                    Sexo = phy.Sexo
                }).ToListAsync(ct);

                if (physicalPerson == null)
                    throw new NotFoundException("Physical Person not found.");

                return physicalPerson;
            }
            catch (Exception ex)
            {
                throw new InternalServerError("Error processing your request.", ex);
            }
            
        }

        public async Task<PhysicalPersonResponse> GetPerIdPhysicalPerson(int id, CancellationToken ct)
        {
            try
            {
                IQueryable<PhysicalPerson> query = _physicalPerson;
                var physicalPerson = await query.FirstOrDefaultAsync(phy => phy.Id == id, ct);

                if (physicalPerson == null)
                    throw new NotFoundException("Physical Person not found.");

                return new PhysicalPersonResponse
                {
                    Cpf = physicalPerson.Cpf,
                    Email = physicalPerson.Email,
                    Id = physicalPerson.Id,
                    Name = physicalPerson.Name,
                    Sexo = physicalPerson.Sexo
                };
            }
            catch (Exception ex)
            {
                throw new InternalServerError("Error processing your request.", ex);
            }
            
        }
    }
}
