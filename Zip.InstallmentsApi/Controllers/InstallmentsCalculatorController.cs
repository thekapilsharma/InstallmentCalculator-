using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Zip.InstallmentsApi.Validator;
using Zip.InstallmentsContract.Services;
using Zip.InstallmentsModel;

namespace Zip.InstallmentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallmentsCalculatorController : ControllerBase
    {
        private readonly IPaymentPlanFactory _paymentPlanFactory;
        private readonly ILogger _logger;
        public InstallmentsCalculatorController(IPaymentPlanFactory paymentPlanFactory, ILogger logger)
        {
            _paymentPlanFactory= paymentPlanFactory;
            _logger= logger;
        }

        /// <summary>
        /// Creats the installments.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult CreatInstallments([FromBody]InstallmentRequest request)
        {
            _logger.LogInformation("Installment request received for",request);
            //This can be replaced with fluent validation or any other validation process.
            InstallmentRequestValidator installmentRequestValidator = new InstallmentRequestValidator();
            ValidationResult validationResult = installmentRequestValidator.Validate(request);

            if(!validationResult.IsValid)
            {
                _logger.LogError("Installment request failed for", request);

                return BadRequest(validationResult.Errors.Select(x=>x.ErrorMessage));
            }

            var result = _paymentPlanFactory.CreatePaymentPlan(request);
            _logger.LogInformation("Installment request completed for", request);

            return Ok(result);
        }
    }
}
