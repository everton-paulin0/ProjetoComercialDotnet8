using Microsoft.EntityFrameworkCore;
using ProjetoComercial.Data;
using ProjetoComercial.Interfaces;
using ProjetoComercial.Models;

namespace ProjetoComercial.Services;

public class EstoqueService : IEstoqueService
{
    private readonly AppDbContext _context;

    public EstoqueService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Movimentar(int codigoProduto, int quantidade, string tipo, string descricao)
    {
        var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.CodigoProduto == codigoProduto);
        if (produto == null) throw new Exception("Produto não encontrado.");

        if (tipo.ToUpperInvariant() == "SAIDA" && produto.Estoque < quantidade)
            throw new Exception("Estoque insuficiente.");

        if (tipo.ToUpperInvariant() == "ENTRADA")
            produto.Estoque += quantidade;
        else
            produto.Estoque -= quantidade;

        var mov = new MovimentacaoEstoque
        {
            CodigoProduto = codigoProduto,
            Quantidade = quantidade,
            Tipo = tipo.ToUpperInvariant(),
            Descricao = descricao,
            Data = DateTime.UtcNow
        };

        _context.Movimentacoes.Add(mov);
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();

        return produto.Estoque;
    }
}
