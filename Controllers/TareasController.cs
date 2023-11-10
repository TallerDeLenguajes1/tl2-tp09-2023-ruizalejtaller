using Microsoft.AspNetCore.Mvc;

namespace EspTareas.Controllers;

[ApiController]
[Route("[controller]")]
public class TareasController : ControllerBase
{

    private readonly ILogger<TareasController> _logger;
    private UsuarioRepository UsersRepository;

    public TareasController(ILogger<TareasController> logger)
    {
        _logger = logger;
        UsersRepository = new UsuarioRepository();
    }

    [HttpPost("CreateUser")]
    public ActionResult CreateUser(Usuarios User)
    {
        UsersRepository.Create(User);
        return Ok();
    }

    [HttpGet("GetAllUsers")]
    public ActionResult<IEnumerable<Usuarios>> GetAllUsers()
    {
        return Ok(UsersRepository.GetAll());
    }
}
