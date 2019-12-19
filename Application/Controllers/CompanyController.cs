using Domain.DTO.Request.Company;
using Domain.DTO.Response.Company;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpPost]
        [ProducesResponseType(typeof(CompanyResponse), 200)]
        public async Task<IActionResult> Post([FromBody] CompanyRequest companyRequest, CancellationToken ct)
        {
            var response = await _companyService.CreateCompany(companyRequest, ct);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CompanyResponse>), 200)]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            var response = await _companyService.GetAllCompany(ct);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(CompanyResponse), 200)]
        public async Task<IActionResult> Get([FromRoute]int id, CancellationToken ct)
        {
            var response = await _companyService.GetPerIdCompany(id, ct);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken ct)
        {
            var response = await _companyService.DeleteCompany(id, ct);
            return Ok(response);
        }
    }
}
