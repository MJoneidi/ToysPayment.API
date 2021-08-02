using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using ToysPayment.API.Models.Contracts;
using ToysPayment.API.Models.Dto;

namespace ToysPayment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IPaymentProcessor _paymentProcessor;

        public PaymentController(ILogger<PaymentController> logger, IPaymentProcessor paymentProcessor)
        {
            _logger = logger;
            _paymentProcessor = paymentProcessor;
        }



        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PaymentRequest paymentRequest)
        {
            try
            {
                _logger.LogInformation($"----- Getting payment request : CustomerID:{paymentRequest.CustomerID}, Amount:{paymentRequest.Amount})");

                var response = await _paymentProcessor.ProcessAsync(paymentRequest);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, "Internal Error");
        }
    }
}
