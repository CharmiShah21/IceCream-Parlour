using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IceCreamParlour.Models
{
    public class Flavour
    {
        [Key]
        public int FlavourId { get; set; }
        public string FlavourName { get; set; }
        public string FlavourDescription { get; set; }
    }
}
