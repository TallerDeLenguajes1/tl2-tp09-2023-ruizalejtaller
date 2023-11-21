namespace EspTareas;
using System.Data.SQLite;
public class TareaRepository
    {
        private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";

        public void Create(Tarea tarea)
        {
            using SQLiteConnection connection = new(cadenaConexion);
            var query = $"INSERT INTO Tarea (id_tablero, nombre, estado, descripcion, color, id_usuario_asignado) VALUES (@idtab,@nombre,@est,@descripcion,@color,@idusuario)";
        
            var command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@idtab", tarea.Idtablero));
            command.Parameters.Add(new SQLiteParameter("@nombre", tarea.Nombre));
            command.Parameters.Add(new SQLiteParameter("@est", tarea.Estado));
            command.Parameters.Add(new SQLiteParameter("@descripcion", tarea.Descripcion));
            command.Parameters.Add(new SQLiteParameter("@color", tarea.Color));
            command.Parameters.Add(new SQLiteParameter("@idusuario", tarea.Idusuarioasignado));

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }


        public void Update(Tarea tarea, int id)
        {
            SQLiteConnection connection = new(cadenaConexion);
            string query = @"UPDATE Tarea SET id = @id, id_tablero = @idtab, nombre = @nombre, estado = @est, descripcion = @descripcion, color = @color, id_usuario_asignado = @idusuario WHERE id = @id;";
            
            var command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@id", id));
            command.Parameters.Add(new SQLiteParameter("@idtab", tarea.Idtablero));
            command.Parameters.Add(new SQLiteParameter("@nombre", tarea.Nombre));
            command.Parameters.Add(new SQLiteParameter("@est", tarea.Estado));
            command.Parameters.Add(new SQLiteParameter("@descripcion", tarea.Descripcion));
            command.Parameters.Add(new SQLiteParameter("@color", tarea.Color));
            command.Parameters.Add(new SQLiteParameter("@idusuario", tarea.Idusuarioasignado));

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }


        public void ActEstado(int id, int estado)
        {
            SQLiteConnection connection = new(cadenaConexion);
            string query = @"UPDATE Tarea SET id = @id, id_tablero = @idtab, nombre = @nombre, estado = @est, descripcion = @descripcion, color = @color, id_usuario_asignado = @idusuario WHERE id = @id;";
            
            var tarea = GetTareaById(id);

            var command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@id", id));
            command.Parameters.Add(new SQLiteParameter("@idtab", tarea.Idtablero));
            command.Parameters.Add(new SQLiteParameter("@nombre", tarea.Nombre));
            command.Parameters.Add(new SQLiteParameter("@est", (EstadoTarea) estado));
            command.Parameters.Add(new SQLiteParameter("@descripcion", tarea.Descripcion));
            command.Parameters.Add(new SQLiteParameter("@color", tarea.Color));
            command.Parameters.Add(new SQLiteParameter("@idusuario", tarea.Idusuarioasignado));

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Tarea GetTareaById(int Id)
        {
            var queryString = @"SELECT * FROM Tarea WHERE id = @id ;";

            using (SQLiteConnection connection = new(cadenaConexion))
            {
                SQLiteCommand command = new(queryString, connection);
                var tarea = new Tarea();
                command.Parameters.Add(new SQLiteParameter("@id", Id));
                
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        tarea.Id = Convert.ToInt32(reader["id"]);
                        tarea.Idtablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["nombre"].ToString();
                        tarea.Estado = (EstadoTarea) Convert.ToInt32(reader["id_tablero"]);
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        if(int.TryParse(reader["id_usuario_asignado"].ToString(), out int idusa))
                            tarea.Idusuarioasignado = idusa;
                    }
                }
                connection.Close();
                return tarea;
            }   
        }
        
        public List<Tarea> GetTareasByUser(int IdUser)
        {
            var queryString = @"SELECT * FROM Tarea WHERE id_usuario_asignado = @idUsuario ;";
            List<Tarea> tareasuser = new List<Tarea>();
            using (SQLiteConnection connection = new(cadenaConexion))
            {
                SQLiteCommand command = new(queryString, connection);
                command.Parameters.Add(new SQLiteParameter("@idUsuario", IdUser));
                
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tareasuser.Add(GetTareaById(Convert.ToInt32(reader["id"])));
                    }
                }
                connection.Close();
            }
            return tareasuser;
        }


        public List<Tarea> GetTareasByTab(int IdTab)
        {
            var queryString = @"SELECT * FROM Tarea WHERE id_tablero = @idTab ;";
            List<Tarea> tareasuser = new List<Tarea>();
            using (SQLiteConnection connection = new(cadenaConexion))
            {
                SQLiteCommand command = new(queryString, connection);
                command.Parameters.Add(new SQLiteParameter("@idTab", IdTab));
                
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tareasuser.Add(GetTareaById(Convert.ToInt32(reader["id"])));
                    }
                }
                connection.Close();
            }
            return tareasuser;
        }

        public List<Tarea> GetTareasByEst(int estado)
        {
            var queryString = @"SELECT * FROM Tarea WHERE estado = @estado ;";
            List<Tarea> tareasuser = new List<Tarea>();
            using (SQLiteConnection connection = new(cadenaConexion))
            {
                SQLiteCommand command = new(queryString, connection);
                command.Parameters.Add(new SQLiteParameter("@estado", estado));
                
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tareasuser.Add(GetTareaById(Convert.ToInt32(reader["id"])));
                    }
                }
                connection.Close();
            }
            return tareasuser;
        }

        public void Remove(int id)
        {
            SQLiteConnection connection = new(cadenaConexion);
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM Tarea WHERE id = '{id}';";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }