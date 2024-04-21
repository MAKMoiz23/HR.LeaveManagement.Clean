using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<LeaveAllocationController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new LeaveAllocationQuery());
            return Ok(result);
        }

        // GET api/<LeaveAllocationController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new LeaveAllocationDetailsQuery(id));
            return Ok(result);
        }

        // POST api/<LeaveAllocationController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLeaveAllocationCommand model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }

        // PUT api/<LeaveAllocationController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateLeaveAllocationCommand model)
        {
            await _mediator.Send(model);
            return Ok();
        }

        // DELETE api/<LeaveAllocationController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveAllocationCommand(id));
            return Ok();
        }
    }
}
