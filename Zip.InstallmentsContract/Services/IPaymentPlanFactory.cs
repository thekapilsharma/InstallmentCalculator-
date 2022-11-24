using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsModel;
using Zip.InstallmentsService;

namespace Zip.InstallmentsContract.Services
{
    public interface IPaymentPlanFactory
    {
        PaymentPlan CreatePaymentPlan(InstallmentRequest request);
    }
}
