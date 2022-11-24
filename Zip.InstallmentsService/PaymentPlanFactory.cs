using System;
using System.Collections.Generic;
using Zip.InstallmentsContract.Services;
using Zip.InstallmentsModel;

namespace Zip.InstallmentsService
{
    /// <summary>
    /// This class is responsible for building the PaymentPlan according to the Zip product definition.
    /// </summary>
    public class PaymentPlanFactory: IPaymentPlanFactory
    {
        /// <summary>
        /// Builds the PaymentPlan instance.
        /// </summary>
        /// <param name="purchaseAmount">The total amount for the purchase that the customer is making.</param>
        /// <returns>The PaymentPlan created with all properties set.</returns>
        public PaymentPlan CreatePaymentPlan(InstallmentRequest request)
        {
            var installmentAmount= request.Amount/request.NoOfInstallments;

            List<Installment> installments = new List<Installment>();
            for (int i = 0; i < request.NoOfInstallments; i++)
            {
                if (i == 0)
                {
                    installments.Add(new Installment()
                    {
                        Amount = request.Amount / request.NoOfInstallments,
                        DueDate = DateTime.Now.Date,
                        Id = Guid.NewGuid(),
                    });
                }
                else
                {
                    installments.Add(new Installment()
                    {
                        Amount = request.Amount / request.NoOfInstallments,
                        DueDate = CalculateDueDate(request.FrequencyType,request.Frequency),
                        Id = Guid.NewGuid(),
                    });
                }
            }


            // TODO
            return new PaymentPlan() { Installments=installments,PurchaseAmount=request.Amount};
        }

        private DateTime CalculateDueDate(FrequencyType frequencyType,int Frequency)
        {
            switch (frequencyType)
            {
                case FrequencyType.Monthaly:
                    return DateTime.Now.AddMonths(Frequency).Date;
                case FrequencyType.Day:
                    return DateTime.Now.AddDays(Frequency).Date;
                default:
                    return DateTime.Now.Date;

            };
        }
    }
}
