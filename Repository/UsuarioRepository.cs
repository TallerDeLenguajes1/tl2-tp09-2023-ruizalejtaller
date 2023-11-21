namespace EspTareas;
using System.Data.SQLite;
public class UsuarioRepository
    {
        private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";

        public List<Usuario> GetAll()
        {
            var queryString = @"SELECT * FROM Usuario;";
            List<Usuario> users = new List<Usuario>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(reader["id"]);
                        usuario.Nombredeusuario = reader["nombre_de_usuario"].ToString();

                        users.Add(usuario);
                    }
                }
                connection.Close();
            }
            return users;
        }

        public void Create(Usuario user)
        {
            using SQLiteConnection connection = new(cadenaConexion);
            var query = $"INSERT INTO Usuario (nombre_de_usuario) VALUES (@nombre_de_usuario)";
        
            var command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@nombre_de_usuario", user.Nombredeusuario));

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(string Nombre, int id)
        {
            SQLiteConnection connection = new(cadenaConexion);
            string query = @"UPDATE Usuario SET nombre_de_usuario = @nombre WHERE id = @id;";
            
            var command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@id", id));
            command.Parameters.Add(new SQLiteParameter("@nombre", Nombre));

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Remove(int id)
        {
            SQLiteConnection connection = new(cadenaConexion);
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM Usuario WHERE id = '{id}';";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Usuario GetById(int id)
        {
            SQLiteConnection connection = new(cadenaConexion);
            var user = new Usuario();
            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Usuario WHERE id = @idUser";
            command.Parameters.Add(new SQLiteParameter("@idUser", id));
            connection.Open();
            using(SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    user.Id = Convert.ToInt32(reader["id"]);
                    user.Nombredeusuario = reader["nombre_de_usuario"].ToString();

                }
            }
            connection.Close();

            return (user);

        }
    }