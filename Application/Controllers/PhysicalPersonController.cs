using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.DTO.Request.PhysicalPerson;
using Domain.DTO.Response.PhysicalPerson;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhysicalPersonController : ControllerBase
    {
        private readonly IPhysicalPersonService _physicalPerson;

        public PhysicalPersonController(IPhysicalPersonService physicalPerson)
        {
            _physicalPerson = physicalPerson;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PhysicalPersonResponse), 200)]
        public async Task<IActionResult> Post(PhysicalPersonRequest physicalPersonRequest, CancellationToken ct)
        {
            var response = await _physicalPerson.CreatePhysicalPerson(physicalPersonRequest, ct);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PhysicalPersonResponse>), 200)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var response = await _physicalPerson.GetAllPhysicalPerson(ct);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(PhysicalPersonResponse), 200)]
        public async Task<IActionResult> GetPerId([FromRoute] int id, CancellationToken ct)
        {
            var response = await _physicalPerson.GetPerIdPhysicalPerson(id, ct);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken ct)
        {
            var response = await _physicalPerson.DeletePhysicalPerson(id, ct);
            return Ok(response);
        }
    }
}
