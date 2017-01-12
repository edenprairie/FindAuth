using ElasticsearchCRUD.ContextAddDeleteUpdate.CoreTypeAttributes;

namespace CVS.Novologix.TransactionSearch.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person.StateProvince")]
    public partial class StateProvince
    {
        public StateProvince()
        {
            Address = new HashSet<Address>();
        }

		[Key]
        public int StateProvinceID { get; set; }

        [Required]
        [StringLength(3)]
        public string StateProvinceCode { get; set; }

        [Required]
        [StringLength(3)]
        public string CountryRegionCode { get; set; }

		[ElasticsearchBoolean]
        public bool IsOnlyStateProvinceFlag { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int TerritoryID { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Address> Address { get; set; }

        public virtual CountryRegion CountryRegion { get; set; }
    }
}
