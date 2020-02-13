using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uppgift2.Models;

namespace Uppgift2.DbContext
{
    public class GenraContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public GenraContext(DbContextOptions<GenraContext> options)
        : base(options)
        {
        }
        public DbSet<Genra> Genra { get; set; }
    }
}
