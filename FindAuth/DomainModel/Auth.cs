using Newtonsoft.Json;

namespace CVS.Novologix.TransactionSearch.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Auth
    {
        
		[Key]
        public int AuthRef { get; set; }
        [Required]
        [StringLength(60)]
        public string TransactionType { get; set; }
        public int AuthLineCount { get; set; }
        [StringLength(30)]
        public string AuthSource { get; set; }
        [StringLength(50)]
        public string InInterchangeChannel { get; set; }
        public DateTime ProcessDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        [StringLength(20)]
        public string PayerResponsibilityCode { get; set; }
        [StringLength(10)]
        public string DiagnosisCode { get; set; }
        [StringLength(50)]
        public string PlaceOfServiceDescription { get; set; }
        [StringLength(50)]
        public string AuthTransactionStatus { get; set; }
        public string BillingProviderID { get; set; }
        public string WorkflowStatus { get; set; }
        public string SubscriberMemberID { get; set; }
        public string SubscriberFirstName { get; set; }
        public string SubscriberLastName { get; set; }

        public string PlanCode { get; set; }
        public string PlanDescription { get; set; }
        public string BillingProviderNPI { get; set; }
        public string BillingProviderName { get; set; }

        public string DerivedStatus { get; set; }

        public string RequestedDrugName { get; set; }
    }
}
