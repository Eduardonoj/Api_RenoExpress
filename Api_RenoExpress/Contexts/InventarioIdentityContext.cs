using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_RenoExpress.Models;

namespace Api_RenoExpress.Contexts
{
    public class InventarioIdentityContext : IdentityDbContext<ApplicationUser>
    {
       
            public InventarioIdentityContext(DbContextOptions<InventarioIdentityContext> options) : base(options)
            {

            }
        
    }
}
