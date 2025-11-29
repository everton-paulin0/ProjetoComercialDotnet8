using System.Diagnostics;

namespace ProjetoComercial.Models;

public class Produto 
{
    

    public int Id { get; set; }
    public int CodigoProduto { get; set; }
    public string DescricaoProduto { get; set; } = string.Empty;
    public int Estoque { get; set; }

    public void Atualizar (int id, int codigoProduto, string descricaoProduto)
    {
        Id = id;
        CodigoProduto = codigoProduto;
        DescricaoProduto = descricaoProduto;
        
    }
}


