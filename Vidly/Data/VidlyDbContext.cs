using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Vidly.Models;

namespace Vidly.Data
{
    public class VidlyDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<MembershipType> MemberShipTypes { get; set; }

        public DbSet<MovieGenre> MovieGenres { get; set; }
    }
}