using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamParlour.Models
{
    public class Distributor
    {
        [Key]
        public int DistributorId { get; set; }
        public string DistributorName { get; set; }
        public int DistributorContactNo { get; set; }
    }
}
