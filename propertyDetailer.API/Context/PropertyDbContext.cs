using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace propertyDetailer.API.Context
{
    public class PropertyDbContext: DbContext
    {
        public PropertyDbContext(DbContextOptions options): base(options)
        {

        }
        DbSet<PropertyDetails> PropertyDetails { get; set; }
    }
}
