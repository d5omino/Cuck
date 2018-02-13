using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cuck.Models;

namespace Cuck.Data
{
    public class CuckContext : DbContext
    {
        public CuckContext (DbContextOptions<CuckContext> options)
            : base(options)
        {
        }

        public DbSet<Cuck.Models.Cucklist> Cucklist { get; set; }
    }
}
