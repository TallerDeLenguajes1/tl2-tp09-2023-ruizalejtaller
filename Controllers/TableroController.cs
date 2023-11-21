using Microsoft.AspNetCore.Mvc;

namespace EspTareas.Controllers;

[ApiController]
[Route("[controller]")]
public class TableroController : ControllerBase
{

    private readonly ILogger<TableroController> _logger;
    private TableroRepository TabRepository;

    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
        TabRepository = new TableroRepository();
    }

    [HttpPost("/api/tablero")]
    public ActionResult CreateTab(Tablero tab)
    {
        TabRepository.Create(tab);
        return Ok();
    }

    [HttpGet("/api/tableros")]
    public ActionResult<IEnumerable<Tablero>> GetAllTab()
    {
        return Ok(TabRepository.GetAll());
    }
}
