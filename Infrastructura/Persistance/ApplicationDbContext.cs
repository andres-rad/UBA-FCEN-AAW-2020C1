using System;
using System.Collections.Generic;
using System.Text;
using Aplicacion.Interfaces;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    public class ApplicationDbContext : IdentityDbContext, IRepository
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Turnero> Turneros { get; set; }

    }
}
