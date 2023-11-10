namespace EspTareas;

public class Tareas
{
    private int id;
    private int idtablero;
    private string nombre;
    private int estado;
    private string descripcion;
    private string color;
    private int idusuarioasignado;
    private EstadoTarea Estado;

    public int Id { get => id; set => id = value; }
    public int Idtablero { get => idtablero; set => idtablero = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public int Estado1 { get => estado; set => estado = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public string Color { get => color; set => color = value; }
    public int Idusuarioasignado { get => idusuarioasignado; set => idusuarioasignado = value; }
    public EstadoTarea Estado2 { get => Estado; set => Estado = value; }
}