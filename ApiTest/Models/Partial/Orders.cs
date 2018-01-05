using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApiTest.Models
{
    [MetadataType(typeof(OrdersMD))]
    public partial class Orders
    {
        public class OrdersMD
        {
            [Key]
            public int OrderID { get; set; }

            [StringLength(5)]
            public string CustomerID { get; set; }

            public int? EmployeeID { get; set; }

            public DateTime? OrderDate { get; set; }

            public DateTime? RequiredDate { get; set; }

            public DateTime? ShippedDate { get; set; }

            public int? ShipVia { get; set; }

            [Column(TypeName = "money")]
            public decimal? Freight { get; set; }

            [StringLength(40)]
            public string ShipName { get; set; }

            [StringLength(60)]
            public string ShipAddress { get; set; }

            [StringLength(15)]
            public string ShipCity { get; set; }

            [StringLength(15)]
            public string ShipRegion { get; set; }

            [StringLength(10)]
            public string ShipPostalCode { get; set; }

            [StringLength(15)]
            public string ShipCountry { get; set; }

            [JsonIgnore]
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<Order_Details> Order_Details { get; set; }
        }
    }
}