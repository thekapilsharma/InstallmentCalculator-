using System;

namespace Zip.InstallmentsService
{
    /// <summary>
    /// Data structure which defines all the properties for a purchase installment plan.
    /// </summary>
    public class PaymentPlan
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the purchase amount.
        /// </summary>
        /// <value>
        /// The purchase amount.
        /// </value>
        public decimal PurchaseAmount { get; set; }
        /// <summary>
        /// Gets or sets the installments.
        /// </summary>
        /// <value>
        /// The installments.
        /// </value>
        public List<Installment>? Installments { get; set; }
    }
}
