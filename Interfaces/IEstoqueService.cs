namespace ProjetoComercial.Interfaces;

public interface IEstoqueService
{
    Task<int> Movimentar(int codigoProduto, int quantidade, string tipo, string descricao);
}
