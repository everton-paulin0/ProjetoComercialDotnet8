using ProjetoComercial.Interfaces;

namespace ProjetoComercial.Services;

public class JurosService : IJurosService
{
    public decimal Calcular(decimal valor, DateTime vencimento)
    {
        var dias = (DateTime.Today - vencimento.Date).Days;
        if (dias <= 0) return 0m;
        decimal multaPorDia = valor * 0.025m; // 2.5% ao dia
        return Math.Round(multaPorDia * dias, 2);
    }
}
