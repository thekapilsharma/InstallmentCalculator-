using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Zip.InstallmentsContract.Services;
using Zip.InstallmentsModel;

namespace Zip.InstallmentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallmentsCalculatorController : ControllerBase
    {
        private readonly IPaymentPlanFactory _paymentPlanFactory;
        public InstallmentsCalculatorController(IPaymentPlanFactory paymentPlanFactory)
        {
            _paymentPlanFactory= paymentPlanFactory;
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
        public IActionResult CreatInstallments([FromBody]InstallmentRequest request)
        {
            //This can be replaced with fluent validation or any other validation process.
            if(request.NoOfInstallments==0 || request.Frequency == 0)
            {
                return BadRequest();
            }

            var result = _paymentPlanFactory.CreatePaymentPlan(request);
            return Ok(result);
        }
    }
}
