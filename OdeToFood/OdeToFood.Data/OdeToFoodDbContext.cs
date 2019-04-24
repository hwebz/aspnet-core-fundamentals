using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    // dotnet ef dbcontext info -s ..\OdeToFood\OdeToFood.csproj
    // dotnet ef migrations add initialcreate -s ..\OdeToFood\OdeToFood.csproj
    // dotnet ef database update -s ..\OdeToFood\OdeToFood.csproj
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options) : base(options) { }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
