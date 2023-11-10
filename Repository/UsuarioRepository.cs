namespace EspTareas;
using System.Data.SQLite;
public class UsuarioRepository
    {
        private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";

        public List<Usuarios> GetAll()
        {
            var queryString = @"SELECT * FROM Usuario;";
            List<Usuarios> users = new List<Usuarios>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var usuario = new Usuarios();
                        usuario.Id = Convert.ToInt32(reader["id"]);
                        usuario.Nombredeusuario = reader["nombre_de_usuario"].ToString();

                        users.Add(usuario);
                    }
                }
                connection.Close();
            }
            return users;
        }

        public void Create(Usuarios user)
        {
            var query = $"INSERT INTO Usuario (nombre_de_usuario) VALUES (@nombre_de_usuario)";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@nombre_de_usuario", user.Nombredeusuario));

                command.ExecuteNonQuery();

                connection.Close();   
            }
        }
    }