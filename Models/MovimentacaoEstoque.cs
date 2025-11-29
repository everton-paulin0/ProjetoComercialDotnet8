using System.ComponentModel.DataAnnotations;

namespace ProjetoComercial.Models;

public class MovimentacaoEstoque
{

    public int Id { get; set; }
    public int CodigoProduto { get; set; }
    public int Quantidade { get; set; }
    public string Tipo { get; set; } = string.Empty; // "ENTRADA" or "SAIDA"
    public string Descricao { get; set; } = string.Empty;
    public DateTime Data { get; set; } = DateTime.UtcNow;
}
