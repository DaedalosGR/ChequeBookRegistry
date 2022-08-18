using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChequebookRegistry.Models;

namespace ChequebookRegistry.Data
{
    public class ChequebookRegistryContext : DbContext
    {
        public ChequebookRegistryContext (DbContextOptions<ChequebookRegistryContext> options)
            : base(options)
        {
        }

        public DbSet<ChequebookRegistry.Models.Cheques> Cheques { get; set; } = default!;

        public DbSet<ChequebookRegistry.Models.Customers>? Customers { get; set; }

        public DbSet<ChequebookRegistry.Models.Payees>? Payees { get; set; }

        public DbSet<ChequebookRegistry.Models.UpcomingPayments>? UpcomingPayments { get; set; }
    }
}
