namespace EspTareas;

public class Tarea
{
    private int id;
    private int idtablero;
    private string nombre;
    private string descripcion;
    private string color;
    private int idusuarioasignado;
    private EstadoTarea estado;

    public int Id { get => id; set => id = value; }
    public int Idtablero { get => idtablero; set => idtablero = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public string Color { get => color; set => color = value; }
    public int Idusuarioasignado { get => idusuarioasignado; set => idusuarioasignado = value; }
    public EstadoTarea Estado { get => estado; set => estado = value; }
}