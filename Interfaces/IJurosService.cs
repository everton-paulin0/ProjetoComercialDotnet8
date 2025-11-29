namespace ProjetoComercial.Interfaces;

public interface IJurosService
{
    decimal Calcular(decimal valor, DateTime vencimento);
}
