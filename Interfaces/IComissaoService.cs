namespace ProjetoComercial.Interfaces;

public interface IComissaoService
{
    decimal CalcularComissao(decimal valorVenda);
    Task<Dictionary<string, decimal>> CalcularComissaoTotal();
}
