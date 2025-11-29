using Microsoft.EntityFrameworkCore;
using ProjetoComercial.Data;
using ProjetoComercial.Interfaces;

namespace ProjetoComercial.Services;

public class ComissaoService : IComissaoService
{
    private readonly AppDbContext _context;

    public ComissaoService(AppDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    private int DecimalParaCentavos(decimal valor)
    {
        return (int)Math.Round(valor * 100, 0);
    }

    
    private decimal CentavosParaDecimal(int centavos)
    {
        return centavos / 100m;
    }

    
    private int CalcularComissaoCentavos(int valorCentavos)
    {
        if (valorCentavos < 10000) return 0;           
        if (valorCentavos < 50000) return (int)Math.Round(valorCentavos * 0.01m);
        return (int)Math.Round(valorCentavos * 0.05m);
    }

    
    public decimal CalcularComissao(decimal valor)
    {
        int valorCentavos = DecimalParaCentavos(valor);
        int comissaoCentavos = CalcularComissaoCentavos(valorCentavos);
        return CentavosParaDecimal(comissaoCentavos);
    }

    
    public async Task<Dictionary<string, decimal>> CalcularComissaoTotal()
    {
        if (_context?.Vendas == null)
            return new Dictionary<string, decimal>();

        var vendas = await _context.Vendas.ToListAsync();

        return vendas
            .GroupBy(v => v.Vendedor ?? "Desconhecido") 
            .ToDictionary(
                g => g.Key,
                g =>
                {
                    int totalCentavos = g
                        .Where(v => v != null)               
                        .Sum(v => CalcularComissaoCentavos(DecimalParaCentavos(v.Valor)));

                    return CentavosParaDecimal(totalCentavos);
                }
            );
    }
}
