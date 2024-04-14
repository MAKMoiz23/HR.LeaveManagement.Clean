using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveTypeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new LeaveTypesQuery());
            return Ok(result);
        }

        // GET api/<LeaveTypeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new LeaveTypeDetailsQuery(id));
            return Ok(result);
        }

        // POST api/<LeaveTypeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLeaveTypeCommand model)
        {
            var result = await _mediator.Send(model);
            return Ok(result);
        }

        // PUT api/<LeaveTypeController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateLeaveTypeCommand model)
        {
            await _mediator.Send(model);
            return Ok();
        }

        // DELETE api/<LeaveTypeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveTypeCommand(id));
            return Ok();
        }
    }
}
