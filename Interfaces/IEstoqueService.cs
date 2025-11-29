using ProjetoComercial.Models;

namespace ProjetoComercial.Interfaces;

public interface IEstoqueService
{
    Task<Produto> Movimentar(int codigoProduto, int quantidade, string tipo, string descricao);
    Task<List<Produto>> ObterEstoqueGeral();
    Task<Produto> ObterEstoquePorProduto(int codigoProduto);
    Task Atualizar(Produto produto);
}
