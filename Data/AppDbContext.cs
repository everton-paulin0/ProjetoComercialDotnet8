using Microsoft.EntityFrameworkCore;
using ProjetoComercial.Models;

namespace ProjetoComercial.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Venda> Vendas => Set<Venda>();
    public DbSet<Produto> Produtos => Set<Produto>();
    public DbSet<MovimentacaoEstoque> Movimentacoes => Set<MovimentacaoEstoque>();
}
