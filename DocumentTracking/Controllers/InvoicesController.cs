using DocumentTracking.Api.Controllers.Base;
using DocumentTracking.Infrastructure.Command;
using DocumentTracking.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DocumentTracking.Api.Controllers
{
    public class InvoicesController : AuthorizedControllersBase
    {
        public InvoicesController(IMediator mediator):base(mediator)
        {
        }
       
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAll()
        {
            var querie = new GetAllInvoiceQuerie();
            var customers = await GetMediator.Send(querie);
            if (customers != null && customers.Count > 0)
            {
                return Ok(customers);
            }
            return NoContent();
        }

        
        [HttpGet("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(long id)
        {
            var querie = new GetByIdInvoiceQuerie() { Id = id };

            var result = await GetMediator.Send(querie);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Created([FromBody]CreateInvoiceCommand invoiceModel)
        {
           // CreateInvoiceCommand command = mapper.Map<InvoiceModel, CreateInvoiceCommand>(invoiceModel);

            var result = await GetMediator.Send(invoiceModel);
            return CreatedAtAction(nameof(GetById), result, result.Id);
        }


        //[HttpPut("{id}")]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(500)]
        //public async Task<IActionResult> Put(long id, [FromBody]InvoiceModel invoiceModel)
        //{

        //  //  _iCustomerService.Update(customerModel);

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(long id)
        {
            DeleteInvoiceCommand deleteInvoiceCommand = new DeleteInvoiceCommand() {Id =id };
            await GetMediator.Publish(deleteInvoiceCommand);
            return NoContent();
        }
    }
}
