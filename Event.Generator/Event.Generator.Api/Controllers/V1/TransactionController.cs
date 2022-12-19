using Microsoft.AspNetCore.Mvc;

using Event.Generator.Domain.Models;
using Event.Generator.Services.RabbitMqService.Interfaces;
using Event.Generator.Dal;
using Event.Generator.Application.Interfaces;

namespace Event.Generator.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionHandler _transactionHandler;

        public TransactionController(ITransactionHandler transactionHandler)
        {
            _transactionHandler =  transactionHandler;
        }
        /// <summary>
        /// Evalueate and Register a Transaction
        /// </summary>
        /// <response code="200">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RegisterTransaction([FromBody] Transaction transaction)
        {
            try
            {
                var Trans = await _transactionHandler.Execute(transaction);
                
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status400BadRequest, String.Format("Transaction could not be verified: {0}", ex.Message));
            }
        }


    }
}
