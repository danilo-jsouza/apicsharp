using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.DTO.Request.Freelancer;
using Microsoft.AspNetCore.Mvc;
using Services.Interface;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreelancerController : ControllerBase
    {
        private readonly IFreelancerService _freelancerService;

        public FreelancerController(IFreelancerService freelancerService)
        {
            _freelancerService = freelancerService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]FreelancerRequest freelancerRequest, CancellationToken ct)
        {
            var response = await _freelancerService.CreateFreelancer(freelancerRequest, ct);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken ct)
        {
            var response = await _freelancerService.GetAllFreelancer(ct);
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id, CancellationToken ct)
        {
            var response = await _freelancerService.GetPerIdFreelancer(id, ct);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken ct)
        {
            var response = await _freelancerService.DeleteFreelancer(id, ct);
            return Ok(response);
        }
    }
}
