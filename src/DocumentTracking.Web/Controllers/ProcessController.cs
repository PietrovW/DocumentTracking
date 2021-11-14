using AutoMapper;
using DocumentTracking.Command;
using DocumentTracking.Controllers.Base;
using DocumentTracking.Models;
using DocumentTracking.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentTracking.Controllers
{
    public class ProcessController : AuthorizedControllersBase
    {
        private readonly IMapper mapper;
        public ProcessController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            this.mapper = mapper;
        }
       
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            GetAllInvoiceQuerie querie = new GetAllInvoiceQuerie();
            var customers = await GetMediator.Send(querie);
            if (customers != null && customers.Count() > 0)
            {
                return Ok(customers);
            }
            return NoContent();
        }
        
        /// <summary>
        /// Get customer by id.
        /// </summary>
        // GET api/Invoices
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(long id)
        {
            GetByIdProcessQuerie querie = new GetByIdProcessQuerie() { Id = id };

            var result = await GetMediator.Send(querie);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(ProcessModel model)
        {
            CreateProcessCommand command = mapper.Map<ProcessModel, CreateProcessCommand>(model);

            var result = await GetMediator.Send(command);
            return CreatedAtAction(nameof(GetById), result, result.Id);
        }


        //[HttpPut("{id}")]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(500)]
        //public async Task<IActionResult> Put(long id, [FromBody]ProcessModel model)
        //{

        //    //_iCustomerService.Update(model);

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(long id)
        {
            DeleteProcessCommand deleteCommand = new DeleteProcessCommand() {Id =id };
            await GetMediator.Publish(deleteCommand);
            return NoContent();
        }
    }
}
