using System.Collections.Generic;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using ProjetoComercial.Controllers;
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

    public async Task Atualizar(Produto produto)
    {
        var produtoDb = await _context.Produtos
        .FirstOrDefaultAsync(p => p.Id == produto.Id);

        if (produtoDb == null)
            throw new Exception("Produto não encontrado.");

        // Atualiza campos necessários
        produtoDb.CodigoProduto = produto.CodigoProduto;
        produtoDb.DescricaoProduto = produto.DescricaoProduto;        

        await _context.SaveChangesAsync();
    }

    public async Task<Produto> Movimentar(int codigoProduto, int quantidade, string tipo, string descricao)
    {
        tipo = tipo.Trim().ToUpper();

        if (tipo != "ENTRADA" && tipo != "SAIDA")
            throw new ArgumentException("Tipo deve ser ENTRADA ou SAIDA.");

        var mov = new MovimentacaoEstoque
        {
            CodigoProduto = codigoProduto,
            Quantidade = quantidade,
            Tipo = tipo,
            Descricao = descricao,
            Data = DateTime.UtcNow
        };

        await _context.Movimentacoes.AddAsync(mov);
        await _context.SaveChangesAsync();

        return await ObterEstoquePorProduto(codigoProduto);
    }

    public async Task<List<Produto>> ObterEstoqueGeral()
    {
        var produtos = await _context.Produtos.ToListAsync();
        var lista = new List<Produto>();

        foreach (var produto in produtos)
        {
            // Agora ObterEstoquePorProduto retorna um Produto pronto
            var produtoComEstoque = await ObterEstoquePorProduto(produto.CodigoProduto);

            lista.Add(produtoComEstoque);
        }

        return lista;
    }

    public async Task<Produto> ObterEstoquePorProduto(int codigoProduto)
    {
        var produto = await _context.Produtos
        .FirstOrDefaultAsync(p => p.CodigoProduto == codigoProduto);

        if (produto == null)
            throw new Exception("Produto não encontrado.");

        int entradas = await _context.Movimentacoes
            .Where(x => x.CodigoProduto == codigoProduto && x.Tipo == "ENTRADA")
            .SumAsync(x => x.Quantidade);

        int saidas = await _context.Movimentacoes
            .Where(x => x.CodigoProduto == codigoProduto && x.Tipo == "SAIDA")
            .SumAsync(x => x.Quantidade);

        int estoque = entradas - saidas;

        return new Produto
        {
            CodigoProduto = produto.CodigoProduto,
            DescricaoProduto = produto.DescricaoProduto,
            Estoque = estoque
        };
    }

    //public async Task<int> Movimentar(int codigoProduto, int quantidade, string tipo, string descricao)
    //{
    //    tipo = tipo.Trim().ToUpper();

    //    if (tipo != "ENTRADA" && tipo != "SAIDA")
    //        throw new ArgumentException("Tipo deve ser ENTRADA ou SAIDA.");

    //    var mov = new MovimentacaoEstoque
    //    {
    //        CodigoProduto = codigoProduto,
    //        Quantidade = quantidade,
    //        Tipo = tipo,
    //        Descricao = descricao,
    //        Data = DateTime.UtcNow
    //    };

    //    await _context.Movimentacoes.AddAsync(mov);
    //    await _context.SaveChangesAsync();

    //    return await ObterEstoquePorProduto(codigoProduto);
    //}

    //public async Task<List<Produto>> ObterEstoqueGeral()
    //{
    //    var produtos = await _context.Produtos.ToListAsync();
    //    var lista = new List<Produto>();

    //    foreach (var produto in produtos)
    //    {
    //        // Agora ObterEstoquePorProduto retorna um Produto pronto
    //        var produtoComEstoque = await ObterEstoquePorProduto(produto.CodigoProduto);

    //        lista.Add(produtoComEstoque);
    //    }

    //    return lista;
    //}

    //public async Task<Produto> ObterEstoquePorProduto(int codigoProduto)
    //{
    //    var produto = await _context.Produtos
    //    .FirstOrDefaultAsync(p => p.CodigoProduto == codigoProduto);

    //    if (produto == null)
    //        throw new Exception("Produto não encontrado.");

    //    int entradas = await _context.Movimentacoes
    //        .Where(x => x.CodigoProduto == codigoProduto && x.Tipo == "ENTRADA")
    //        .SumAsync(x => x.Quantidade);

    //    int saidas = await _context.Movimentacoes
    //        .Where(x => x.CodigoProduto == codigoProduto && x.Tipo == "SAIDA")
    //        .SumAsync(x => x.Quantidade);

    //    int estoque = entradas - saidas;

    //    return new Produto
    //    {
    //        CodigoProduto = produto.CodigoProduto,
    //        DescricaoProduto = produto.DescricaoProduto,
    //        Estoque = estoque
    //    };
    //}
}


