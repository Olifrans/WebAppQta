using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppQta;

namespace WebAppQta.Models
{
    public class WebAppQtaContext : DbContext
    {
        public WebAppQtaContext (DbContextOptions<WebAppQtaContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppQta.Qta> Qta { get; set; }
    }
}
