using Microsoft.AspNetCore.Mvc;
using ProjetoComercial.Interfaces;
using ProjetoComercial.Models;
using ProjetoComercial.Services;

namespace ProjetoComercial.Controllers;

[ApiController]
[Route("api/estoque")]
public class EstoqueController : ControllerBase
{
    private readonly IEstoqueService _service;

    public EstoqueController(IEstoqueService service)
    {
        _service = service;
    }

    // GET api/estoque
    [HttpGet]
    public async Task<IActionResult> GetEstoqueGeral()
    {
        var estoque = await _service.ObterEstoqueGeral();
        return Ok(estoque);
    }

    // GET api/estoque/10
    [HttpGet("{codigoProduto:int}")]
    public async Task<IActionResult> GetEstoquePorProduto(int codigoProduto)
    {
        var estoque = await _service.ObterEstoquePorProduto(codigoProduto);

        if (estoque == null)
            return NotFound("Produto não encontrado");

        return Ok(estoque);
    }

   

    // POST api/estoque/movimentar
    [HttpPost("movimentar")]
    public async Task<IActionResult> Movimentar([FromBody] MovimentacaoDTO dto)
    {
        var quantidadeAtual = await _service.Movimentar(
            dto.CodigoProduto,
            dto.Quantidade,
            dto.Tipo,
            dto.Descricao
        );

        return Ok(new { QuantidadeAtual = quantidadeAtual });
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> AtualizarProduto(Produto produto)
    {
        await _service.Atualizar(produto);
        return Ok(new { mensagem = "Produto atualizado com sucesso." });
    }

    public class MovimentacaoDTO
    {
        public int CodigoProduto { get; set; }
        public int Quantidade { get; set; }
        public string Tipo { get; set; } = string.Empty; // ENTRADA or SAIDA
        public string Descricao { get; set; } = string.Empty;
    }
}




