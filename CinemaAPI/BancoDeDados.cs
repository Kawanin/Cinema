using Microsoft.EntityFrameworkCore;

public class BancoDeDados : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseMySQL("server=localhost;port=3306;database=Cinema;user=root;password=positivo");
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Ingresso> Ingresso { get; set; }
    public DbSet<ProdutoBomboniere> Produtos { get; set; }
    public DbSet<Sala> Sala { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Ingresso>()
        //     .HasOne(f => f.Cliente)
        //     .WithMany(c => c.Ingressos)
        //     .HasForeignKey(f => f.ClienteID);

        // modelBuilder.Entity<Ingresso>()
        //     .HasOne(f => f.Filme)
        //     .WithMany(f => f.Ingressos)
        //     .HasForeignKey(f => f.FilmeID);

        // modelBuilder.Entity<Ingresso>()
        //     .HasMany(p => p.CarrinhoBomboniere)
        //     .WithMany(c => c.Ingressos);
    }
}
