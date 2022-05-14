using Javascript_Fetch_Upload_Dotnet_Core_5_with_EF.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Javascript_Fetch_Upload_Dotnet_Core_5_with_EF.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Imagemodel> Imagemodels { get; set; }
    }
}
