using proj1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace proj1.DAL
{

    public class WebContext : DbContext
    {

        public WebContext()
            : base("WebContext")
        {
        }

        public DbSet<Hotel> hotels { get; set; }
        public DbSet<RecommendationHotel> RecommendationsHotel { get; set; }
        public DbSet<Rest> rests { get; set; }
        public DbSet<RecommendationRest> RecommendationsRest { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
    }