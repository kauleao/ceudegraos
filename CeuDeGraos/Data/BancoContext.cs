using CeuDeGraos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity;

namespace CeuDeGraos.Data;

public class BancoContext : DbContext
{

    public BancoContext(DbContextOptions<BancoContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>().ToTable("DBUsuario");
    }

    public DbSet<Usuario> Usuarios { get; set; }


}