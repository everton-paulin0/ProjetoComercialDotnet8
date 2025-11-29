using Microsoft.EntityFrameworkCore;
using ProjetoComercial.Data;
using ProjetoComercial.Interfaces;

namespace ProjetoComercial.Services;

public class ComissaoService : IComissaoService
{
    private readonly AppDbContext _context;

    public ComissaoService(AppDbContext context)
    {
        _context = context;
    }

    public decimal CalcularComissao(decimal valor)
    {
        if (valor < 100m) return 0m;
        if (valor < 500m) return valor * 0.01m;
        return valor * 0.05m;
    }

    public async Task<Dictionary<string, decimal>> CalcularComissaoTotal()
    {
        var vendas = await _context.Vendas.ToListAsync();
        return vendas
            .GroupBy(v => v.Vendedor)
            .ToDictionary(g => g.Key, g => g.Sum(v => CalcularComissao(v.Valor)));
    }
}
