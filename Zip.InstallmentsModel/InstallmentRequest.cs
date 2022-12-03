

using System.ComponentModel.DataAnnotations;

namespace Zip.InstallmentsModel
{
    /// <summary>
    /// Installment request class
    /// </summary>
    public class InstallmentRequest
    {
        /// <summary>
        /// Product Amount
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Installment Frequency
        /// </summary>
        public int Frequency { get; set; }
        /// <summary>
        /// Installment Frequency Type
        /// </summary>
        public FrequencyTypes FrequencyType { get; set; }
        /// <summary>
        /// No Of Installments
        /// </summary>
        public int NoOfInstallments {get;set;}
    }
}
