namespace EspTareas;

public class Tablero
{
    private int id;
    private int idusuariopropietario;
    private string nombre;
    private string descripcion;

    public int Id { get => id; set => id = value; }
    public int Idusuariopropietario { get => idusuariopropietario; set => idusuariopropietario = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
}