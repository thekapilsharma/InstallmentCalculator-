using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Zip.InstallmentsApi.Controllers;
using Zip.InstallmentsContract.Services;
using Zip.InstallmentsModel;

namespace Zip.InstallmentsService.Test.Controller
{
    public class InstallmentsCalculatorControllerTest
    {
        private readonly  Mock<IPaymentPlanFactory> _planFactoryMock;

        public InstallmentsCalculatorControllerTest()
        {
            _planFactoryMock = new Mock<IPaymentPlanFactory>();
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
                FrequencyType = FrequencyType.Day,
                NoOfInstallments = 4
            };
            // Act
            var controller = new InstallmentsCalculatorController(_planFactoryMock.Object);

            var paymentPlan = controller.CreatInstallments(installmentRequest);

            // Assert
            paymentPlan.ShouldNotBeNull();

        }
    }
}
