using Microsoft.AspNetCore.Mvc;

namespace EspTareas.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{

    private readonly ILogger<UsuarioController> _logger;
    private UsuarioRepository UsersRepository;

    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        UsersRepository = new UsuarioRepository();
    }

    [HttpPost("/api/usuario")]
    public ActionResult CreateUser(Usuario User)
    {
        UsersRepository.Create(User);
        return Ok();
    }

    [HttpGet("/api/usuarios")]
    public ActionResult<IEnumerable<Usuario>> GetAllUsers()
    {
        return Ok(UsersRepository.GetAll());
    }

    [HttpGet("/api/usuario/{Id}")]
    public ActionResult<Usuario> GetUser(int Id)
    {
        return Ok(UsersRepository.GetById(Id));
    }

    [HttpPut("/api/usuario/{Id}/Nombre")]
    public ActionResult UpdateUser(int Id, String Nombre)
    {
        UsersRepository.Update(Nombre, Id);
        return Ok();
    }

}
