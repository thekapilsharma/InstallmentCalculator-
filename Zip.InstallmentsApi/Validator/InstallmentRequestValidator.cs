using FluentValidation;
using Zip.InstallmentsModel;

namespace Zip.InstallmentsApi.Validator
{
    public class InstallmentRequestValidator : AbstractValidator<InstallmentRequest>
    {
        public InstallmentRequestValidator()
        {
            RuleFor(request => request.Amount).GreaterThan(0).WithMessage("Please provide a valid Amount");
            RuleFor(request => request.NoOfInstallments).GreaterThan(0).WithMessage("Please provide valid No Of Installments");
            RuleFor(request => request.Frequency).GreaterThan(0).WithMessage("Please enter valid Frequency");
            RuleFor(request => request.FrequencyType).IsInEnum().WithMessage("Please provide valid Frequency Type");
        }
    }
}
