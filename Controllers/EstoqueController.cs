using Microsoft.AspNetCore.Mvc;
using ProjetoComercial.Interfaces;
using ProjetoComercial.Models;

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

    [HttpPost("movimentar")]
    public async Task<IActionResult> Movimentar([FromBody] MovimentacaoDTO dto)
    {
        var estoqueFinal = await _service.Movimentar(dto.CodigoProduto, dto.Quantidade, dto.Tipo, dto.Descricao);
        return Ok(new { EstoqueFinal = estoqueFinal });
    }
}

public class MovimentacaoDTO
{
    public int CodigoProduto { get; set; }
    public int Quantidade { get; set; }
    public string Tipo { get; set; } = string.Empty; // ENTRADA or SAIDA
    public string Descricao { get; set; } = string.Empty;
}
