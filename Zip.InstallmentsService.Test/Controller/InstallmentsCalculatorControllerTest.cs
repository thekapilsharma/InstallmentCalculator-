using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;
using Zip.InstallmentsApi.Controllers;
using Zip.InstallmentsContract.Services;
using Zip.InstallmentsModel;

namespace Zip.InstallmentsService.Test.Controller
{
    public class InstallmentsCalculatorControllerTest
    {
        private readonly  Mock<IPaymentPlanFactory> _planFactoryMock;
        private readonly Mock<ILogger> _mockLogger;
        public InstallmentsCalculatorControllerTest()
        {
            _planFactoryMock = new Mock<IPaymentPlanFactory>();
            _mockLogger = new Mock<ILogger>();
        }
        [Fact]
        public void WhenCreatePaymentPlanWithValidOrderAmount_ShouldReturnValidPaymentPlan()
        {
            // Arrange
            _planFactoryMock.Setup(_ => _.CreatePaymentPlan(It.IsAny<InstallmentRequest>())).Returns(new PaymentPlan() { PurchaseAmount = 100 });
             var installmentRequest = new InstallmentRequest()
            {
                Amount = 100,
                Frequency = 14,
                FrequencyType = FrequencyTypes.Day,
                NoOfInstallments = 4
            };
            // Act
            var controller = new InstallmentsCalculatorController(_planFactoryMock.Object,_mockLogger.Object);

            var paymentPlan = controller.CreatInstallments(installmentRequest);

            // Assert
            paymentPlan.ShouldNotBeNull();

        }


        /// <summary>
        /// Whens the create payment plan with invalid order amount should return validation error bad request.
        /// </summary>
        [Fact]
        public void WhenCreatePaymentPlanWithInValidOrderAmount_ShouldReturnBadRequest()
        {
            // Arrange
            _planFactoryMock.Setup(_ => _.CreatePaymentPlan(It.IsAny<InstallmentRequest>())).Returns(new PaymentPlan() {  });
            var installmentRequest = new InstallmentRequest()
            {
                Amount = 0,
                Frequency = 14,
                FrequencyType = FrequencyTypes.Day,
                NoOfInstallments = 4
            };
            // Act
            var controller = new InstallmentsCalculatorController(_planFactoryMock.Object, _mockLogger.Object);

            var paymentPlan = controller.CreatInstallments(installmentRequest);

            // Assert

            paymentPlan.ShouldBeOfType<BadRequestObjectResult>();
           
        }
    }
}
