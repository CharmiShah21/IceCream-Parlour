using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamParlour.Models
{
    public class IceCream
    {
        [Key]
        public int IceCreamId { get; set; }
        public string IceCreamName { get; set; }
        public string IceCreamDescription { get; set; }

        public int IceCreamPrice { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }


        [ForeignKey("Flavour")]
        public int FlavourId { get; set; }
        public Flavour Flavour { get; set; }


        [ForeignKey("Distributor")]
        public int DistributorId { get; set; }
        public Distributor Distributor { get; set; }


        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
