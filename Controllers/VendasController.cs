using Microsoft.AspNetCore.Mvc;
using ProjetoComercial.Data;
using ProjetoComercial.Interfaces;
using ProjetoComercial.Models;

namespace ProjetoComercial.Controllers;

[ApiController]
[Route("api/vendas")]
public class VendasController : ControllerBase
{
    private readonly IComissaoService _service;
    private readonly AppDbContext _ctx;

    public VendasController(IComissaoService service, AppDbContext ctx)
    {
        _service = service;
        _ctx = ctx;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Venda venda)
    {
        _ctx.Vendas.Add(venda);
        await _ctx.SaveChangesAsync();
        return CreatedAtAction(nameof(Post), new { id = venda.Id }, venda);
    }

    [HttpGet("comissoes")]
    public async Task<IActionResult> Comissoes()
    {
        var resultado = await _service.CalcularComissaoTotal();
        return Ok(resultado);
    }
}
