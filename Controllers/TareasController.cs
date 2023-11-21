using Microsoft.AspNetCore.Mvc;

namespace EspTareas.Controllers;

[ApiController]
[Route("[controller]")]
public class TareasController : ControllerBase
{

    private readonly ILogger<TareasController> _logger;
    private TareaRepository TareaRepository;

    public TareasController(ILogger<TareasController> logger)
    {
        _logger = logger;
        TareaRepository = new TareaRepository();
    }

    [HttpPost("/api/tarea")]
    public ActionResult CreateTarea(Tarea tarea)
    {
        TareaRepository.Create(tarea);
        return Ok();
    }

    [HttpPut("/api/tarea/{Id}")]
    public ActionResult UpdateTarea(int Id, Tarea tarea)
    {
        TareaRepository.Update(tarea, Id);
        return Ok();
    }

    [HttpPut("/api/tarea/{Id}/Estado{estado}")]
    public ActionResult ActEstado(int Id, int estado)
    {
        TareaRepository.ActEstado(Id, estado);
        return Ok();
    }

    [HttpGet("/api/tarea/usuario/{IdUser}")]
    public ActionResult<IEnumerable<Tarea>> GetbyUser(int IdUser)
    {
        return Ok(TareaRepository.GetTareasByUser(IdUser));
    }

    [HttpGet("/api/tarea/tablero/{IdTab}")]
    public ActionResult<IEnumerable<Tarea>> GetbyTab(int IdTab)
    {
        return Ok(TareaRepository.GetTareasByTab(IdTab));
    }

    [HttpGet("/api/tarea/{Estado}")]
    public ActionResult<IEnumerable<Tarea>> GetbyEst(int Estado)
    {
        return Ok(TareaRepository.GetTareasByEst(Estado));
    }

    [HttpDelete("/api/tarea/{Id}")]
    public ActionResult DelTarea(int Id)
    {
        TareaRepository.Remove(Id);
        return Ok();
    }

}
