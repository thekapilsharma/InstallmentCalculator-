using Shouldly;
using Xunit;
using Zip.InstallmentsContract.Services;
using Zip.InstallmentsModel;

namespace Zip.InstallmentsService.Test
{
    public class PaymentPlanFactoryTests
    {
        [Fact]
        public void WhenCreatePaymentPlanWithValidOrderAmount_ShouldReturnValidPaymentPlan()
        {
            // Arrange
            var paymentPlanFactory = new PaymentPlanFactory();
            var installmentRequest = new InstallmentRequest()
            {
                Amount =100,
                Frequency =14,
                FrequencyType = FrequencyTypes.Day,
                NoOfInstallments=4
            };
            // Act
            var paymentPlan = paymentPlanFactory.CreatePaymentPlan(installmentRequest);

            // Assert
            paymentPlan.ShouldNotBeNull();
            paymentPlan.Installments[0].Amount.Equals(25);

        }
    }
}
