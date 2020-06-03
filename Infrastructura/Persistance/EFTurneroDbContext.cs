using Aplicacion.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructura
{
    // internal para que no la usen los que dependan de infrastructura
    public class EFTurneroDbContext : DbContext, IRepository
    {
        public EFTurneroDbContext(DbContextOptions<EFTurneroDbContext> options)
            : base(options)
        {
        }

        public DbSet<Turnero> Turneros { get; set; }

        override public int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
