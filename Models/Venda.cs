namespace ProjetoComercial.Models;

public class Venda 
{
    public int Id { get; set; }
    public string Vendedor { get; set; } = string.Empty;
    public decimal Valor { get; set; }
}
