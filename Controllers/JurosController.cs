using Microsoft.AspNetCore.Mvc;
using ProjetoComercial.Interfaces;

namespace ProjetoComercial.Controllers;

[ApiController]
[Route("api/juros")]
public class JurosController : ControllerBase
{
    private readonly IJurosService _service;

    public JurosController(IJurosService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Calcular([FromBody] JurosDTO dto)
    {
        var juros = _service.Calcular(dto.Valor, dto.Vencimento);
        return Ok(new { Juros = juros });
    }
}

public class JurosDTO
{
    public decimal Valor { get; set; }
    public DateTime Vencimento { get; set; }
}
