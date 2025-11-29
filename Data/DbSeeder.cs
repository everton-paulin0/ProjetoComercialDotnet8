using System.Text.Json;
using ProjetoComercial.Models;

namespace ProjetoComercial.Data;

public static class DbSeeder
{
    public static void SeedIfEmpty(AppDbContext ctx)
    {
        if (!ctx.Vendas.Any())
        {
            var vendasJson = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Data", "seed", "vendas.json"));
            using var doc = JsonDocument.Parse(vendasJson);
            var root = doc.RootElement.GetProperty("vendas");
            foreach (var el in root.EnumerateArray())
            {
                ctx.Vendas.Add(new Venda
                {
                    Vendedor = el.GetProperty("vendedor").GetString() ?? "",
                    Valor = el.GetProperty("valor").GetDecimal()
                });
            }
            ctx.SaveChanges();
        }

        if (!ctx.Produtos.Any())
        {
            var estoqueJson = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Data", "seed", "estoque.json"));
            using var doc = JsonDocument.Parse(estoqueJson);
            var root = doc.RootElement.GetProperty("estoque");
            foreach (var el in root.EnumerateArray())
            {
                ctx.Produtos.Add(new Produto
                {
                    CodigoProduto = el.GetProperty("codigoProduto").GetInt32(),
                    DescricaoProduto = el.GetProperty("descricaoProduto").GetString() ?? "",
                    Estoque = el.GetProperty("estoque").GetInt32()
                });
            }
            ctx.SaveChanges();
        }
    }
}
