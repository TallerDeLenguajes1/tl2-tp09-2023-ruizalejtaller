namespace EspTareas;
using System.Data.SQLite;
public class TableroRepository
    {
        private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";

        public List<Tablero> GetAll()
        {
            var queryString = @"SELECT * FROM Tablero;";
            List<Tablero> tableros = new List<Tablero>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tab = new Tablero();
                        tab.Id = Convert.ToInt32(reader["id"]);
                        tab.Idusuariopropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                        tab.Nombre = reader["nombre"].ToString();
                        tab.Descripcion = reader["descripcion"].ToString();

                        tableros.Add(tab);
                    }
                }
                connection.Close();
            }
            return tableros;
        }


        public void Create(Tablero tab)
        {
            using SQLiteConnection connection = new(cadenaConexion);
            var query = $"INSERT INTO Tablero (id_usuario_propietario, nombre, descripcion) VALUES (@idpropietario,@nombre,@descripcion)";
        
            var command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@idpropietario", tab.Idusuariopropietario));
            command.Parameters.Add(new SQLiteParameter("@nombre", tab.Nombre));
            command.Parameters.Add(new SQLiteParameter("@descripcion", tab.Descripcion));

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Tablero tab, int id)
        {
            SQLiteConnection connection = new(cadenaConexion);
            string query = @"UPDATE Tablero SET id_usuario_propietario = @iduser, nombre = @nombre, descripcion = @desc WHERE id = @id;";
            
            var command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@id", id));
            command.Parameters.Add(new SQLiteParameter("@iduser", tab.Idusuariopropietario));
            command.Parameters.Add(new SQLiteParameter("@nombre", tab.Nombre));
            command.Parameters.Add(new SQLiteParameter("@desc", tab.Descripcion));
            
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Tablero GetById(int id)
        {
            SQLiteConnection connection = new(cadenaConexion);
            var tab = new Tablero();
            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Tablero WHERE id = @idtab";
            command.Parameters.Add(new SQLiteParameter("@idtab", id));
            connection.Open();
            using(SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    tab.Id = Convert.ToInt32(reader["id"]);
                    tab.Idusuariopropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                    tab.Nombre = reader["nombre"].ToString();
                    tab.Descripcion = reader["descripcion"].ToString();
                }
            }
            connection.Close();

            return (tab);
        }

         public List<Tablero> GetByUser(int idUser)
        {
            SQLiteConnection connection = new(cadenaConexion);
            var Ltab = new List<Tablero>();
            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = "SELECT * FROM Tablero WHERE id_usuario_propietario = @idUser";
            command.Parameters.Add(new SQLiteParameter("@idUser", idUser));
            
            connection.Open();
            using(SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Tablero tab = new Tablero();
                    tab.Id = Convert.ToInt32(reader["id"]);
                    tab.Idusuariopropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                    tab.Nombre = reader["nombre"].ToString();
                    tab.Descripcion = reader["descripcion"].ToString();
                    Ltab.Add(tab);
                }
            }
            connection.Close();

            return Ltab;
        }

        public void Remove(int id)
        {
            SQLiteConnection connection = new(cadenaConexion);
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"DELETE FROM Tablero WHERE id = '{id}';";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }