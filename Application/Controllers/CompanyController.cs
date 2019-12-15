using Domain.DTO.Request.Company;
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
        public async Task<IActionResult> Post([FromBody] CompanyRequest company, CancellationToken ct)
        {
            var response = await _companyService.CreateCompany(company, ct);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            var response = await _companyService.GetAllCompany(ct);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute]int id, CancellationToken ct)
        {
            var response = await _companyService.GetPerIdCompany(id, ct);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken ct)
        {
            var response = await _companyService.DeleteCompany(id, ct);
            return Ok(response);
        }
    }
}
