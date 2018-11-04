using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVCCoreNet.Models
{
    public class MVCContext : DbContext
    {
        public MVCContext (DbContextOptions<MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Lib> Lib { get; set; }
        public DbSet<Categorie> Categorie { get; set; }
        public DbSet<Hebergement> Hebergement { get; set; }
        public DbSet<Lien> Lien { get; set; }
    }
}
