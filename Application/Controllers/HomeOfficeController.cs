using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.DTO.Request.HomeOffice;
using Domain.DTO.Response.HomeOffice;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeOfficeController : ControllerBase
    {
        private readonly IHomeOfficeService _homeOffice;

        public HomeOfficeController(IHomeOfficeService homeOffice)
        {
            _homeOffice = homeOffice;
        }

        [HttpPost]
        [ProducesResponseType(typeof(HomeOfficeResponse), 200)]
        public async Task<IActionResult> Post([FromBody] HomeOfficeRequest homeOfficeRequest, CancellationToken ct)
        {
            var response = await _homeOffice.CreateHomeOffice(homeOfficeRequest, ct);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<HomeOfficeResponse>), 200)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var response = await _homeOffice.GetAllHomeOffice(ct);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(HomeOfficeResponse), 200)]
        public async Task<IActionResult> GetPerId([FromRoute] int id, CancellationToken ct)
        {
            var response = await _homeOffice.GetPerIdHomeOffice(id, ct);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken ct)
        {
            var response = await _homeOffice.DeleteHomeOffice(id, ct);
            return Ok(response);
        }
    }
}
