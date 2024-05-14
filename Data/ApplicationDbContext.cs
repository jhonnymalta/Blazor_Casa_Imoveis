using Blazor_Casa_Imoveis.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blazor_Casa_Imoveis.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // models here
        public DbSet<Category> Categories { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<ImovelImage> ImovelImages { get; set; }
    }
}
