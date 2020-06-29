using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IceCreamParlour.Models
{
    public class ParlourContext:DbContext
    {
        public ParlourContext(DbContextOptions<ParlourContext> options) : base(options) { }

        public DbSet<IceCream> IceCreams { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Flavour> Flavours { get; set; }


        public DbSet<Distributor> Distributors { get; set; }


        public DbSet<Category> Categories { get; set; }


    }
}
