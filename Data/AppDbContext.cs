using Microsoft.EntityFrameworkCore;
using ProjetoComercial.Models;

namespace ProjetoComercial.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Venda> Vendas => Set<Venda>();
    public DbSet<Produto> Produtos => Set<Produto>();
    public DbSet<MovimentacaoEstoque> Movimentacoes => Set<MovimentacaoEstoque>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Produto>()
        .Property(p => p.Id)
        .ValueGeneratedOnAdd();

        modelBuilder.Entity<Produto>().HasData(
            new Produto { Id = 1, CodigoProduto = 101, DescricaoProduto = "Caneta Azul", Estoque = 150 },
            new Produto { Id = 2, CodigoProduto = 102, DescricaoProduto = "Caderno Universitário", Estoque = 75 },
            new Produto { Id = 3, CodigoProduto = 103, DescricaoProduto = "Borracha Branca", Estoque = 200 },
            new Produto { Id = 4, CodigoProduto = 104, DescricaoProduto = "Lápis Preto HB", Estoque = 320 },
            new Produto { Id = 5, CodigoProduto = 105, DescricaoProduto = "Marcador de Texto Amarelo", Estoque = 90 }
        );

        modelBuilder.Entity<Venda>()
        .Property(p => p.Id)
        .ValueGeneratedOnAdd();

        modelBuilder.Entity<Venda>().HasData(
        // João Silva
        new Venda { Id = 1, Vendedor = "João Silva", Valor = 1200.50m },
        new Venda { Id = 2, Vendedor = "João Silva", Valor = 950.75m },
        new Venda { Id = 3, Vendedor = "João Silva", Valor = 1800.00m },
        new Venda { Id = 4, Vendedor = "João Silva", Valor = 1400.30m },
        new Venda { Id = 5, Vendedor = "João Silva", Valor = 1100.90m },
        new Venda { Id = 6, Vendedor = "João Silva", Valor = 1550.00m },
        new Venda { Id = 7, Vendedor = "João Silva", Valor = 1700.80m },
        new Venda { Id = 8, Vendedor = "João Silva", Valor = 250.30m },
        new Venda { Id = 9, Vendedor = "João Silva", Valor = 480.75m },
        new Venda { Id = 10, Vendedor = "João Silva", Valor = 320.40m },

        // Maria Souza
        new Venda { Id = 11, Vendedor = "Maria Souza", Valor = 2100.40m },
        new Venda { Id = 12, Vendedor = "Maria Souza", Valor = 1350.60m },
        new Venda { Id = 13, Vendedor = "Maria Souza", Valor = 950.20m },
        new Venda { Id = 14, Vendedor = "Maria Souza", Valor = 1600.75m },
        new Venda { Id = 15, Vendedor = "Maria Souza", Valor = 1750.00m },
        new Venda { Id = 16, Vendedor = "Maria Souza", Valor = 1450.90m },
        new Venda { Id = 17, Vendedor = "Maria Souza", Valor = 400.50m },
        new Venda { Id = 18, Vendedor = "Maria Souza", Valor = 180.20m },
        new Venda { Id = 19, Vendedor = "Maria Souza", Valor = 90.75m },

        // Carlos Oliveira
        new Venda { Id = 20, Vendedor = "Carlos Oliveira", Valor = 800.50m },
        new Venda { Id = 21, Vendedor = "Carlos Oliveira", Valor = 1200.00m },
        new Venda { Id = 22, Vendedor = "Carlos Oliveira", Valor = 1950.30m },
        new Venda { Id = 23, Vendedor = "Carlos Oliveira", Valor = 1750.80m },
        new Venda { Id = 24, Vendedor = "Carlos Oliveira", Valor = 1300.60m },
        new Venda { Id = 25, Vendedor = "Carlos Oliveira", Valor = 300.40m },
        new Venda { Id = 26, Vendedor = "Carlos Oliveira", Valor = 500.00m },
        new Venda { Id = 27, Vendedor = "Carlos Oliveira", Valor = 125.75m },

        // Ana Lima
        new Venda { Id = 28, Vendedor = "Ana Lima", Valor = 1000.00m },
        new Venda { Id = 29, Vendedor = "Ana Lima", Valor = 1100.50m },
        new Venda { Id = 30, Vendedor = "Ana Lima", Valor = 1250.75m },
        new Venda { Id = 31, Vendedor = "Ana Lima", Valor = 1400.20m },
        new Venda { Id = 32, Vendedor = "Ana Lima", Valor = 1550.90m },
        new Venda { Id = 33, Vendedor = "Ana Lima", Valor = 1650.00m },
        new Venda { Id = 34, Vendedor = "Ana Lima", Valor = 75.30m },
        new Venda { Id = 35, Vendedor = "Ana Lima", Valor = 420.90m },
        new Venda { Id = 36, Vendedor = "Ana Lima", Valor = 315.40m }
    );
    }
}
