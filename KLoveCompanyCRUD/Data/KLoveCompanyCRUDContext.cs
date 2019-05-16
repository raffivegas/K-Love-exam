using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KLoveCompanyCRUD.Models;

namespace KLoveCompanyCRUD.Models
{
    public class KLoveCompanyCRUDContext : DbContext
    {
        public KLoveCompanyCRUDContext (DbContextOptions<KLoveCompanyCRUDContext> options)
            : base(options)
        {
        }
        public DbSet<KLoveCompanyCRUD.Models.Department> Department { get; set; }
        public DbSet<KLoveCompanyCRUD.Models.Employee> Employee { get; set; }

    }
}
