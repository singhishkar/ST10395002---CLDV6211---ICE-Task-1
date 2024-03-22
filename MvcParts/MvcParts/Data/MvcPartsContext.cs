using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcParts.Models;

namespace MvcParts.Data
{
    public class MvcPartsContext : DbContext
    {
        public MvcPartsContext (DbContextOptions<MvcPartsContext> options)
            : base(options)
        {
        }

        public DbSet<MvcParts.Models.Parts> Parts { get; set; } = default!;
    }
}
