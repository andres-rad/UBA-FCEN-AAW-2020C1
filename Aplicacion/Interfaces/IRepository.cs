using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface IRepository
    {
        DbSet<Turnero> Turneros { get; set; }
        int SaveChanges();

    }
}
