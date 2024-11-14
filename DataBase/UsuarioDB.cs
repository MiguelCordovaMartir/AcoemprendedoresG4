using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Clave3_Grupo4.Clases;
using System.Data;

namespace Clave3_Grupo4.DataBase
{
    public class UsuarioDB
    {
        private ConexionDB conexionDB = new ConexionDB();

        // Método para insertar un nuevo usuario
        public bool InsertarUsuario(Usuario usuario)
        {
            try
            {
                string query = "INSERT INTO Usuarios (NombreUsuario, Contrasena, Rol) VALUES (@NombreUsuario, @Contrasena, @Rol)";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                {
                    cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                    cmd.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
                    cmd.Parameters.AddWithValue("@Rol", usuario.Rol);

                    int resultado = cmd.ExecuteNonQuery();
                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conexionDB.CerrarConexion();
            }
        }

        // Método para obtener todos los usuarios
        public DataTable ObtenerTodosUsuarios()
        {
            DataTable dataTable = new DataTable();

            try
            {
                string query = "SELECT * FROM Usuarios";
                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexionDB.CerrarConexion();
            }

            return dataTable;
        }

        // Método para obtener un usuario por su nombre de usuario
        public Usuario ObtenerUsuarioPorNombreUsuario(string nombreUsuario)
        {
            Usuario usuario = null;
            try
            {
                string query = "SELECT * FROM Usuarios WHERE NombreUsuario = @NombreUsuario";
                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                {
                    cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario
                            {
                                IdUsuario = reader.GetInt32("IdUsuario"),
                                NombreUsuario = reader.GetString("NombreUsuario"),
                                Contrasena = reader.GetString("Contrasena"),
                                Rol = reader.GetString("Rol")
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexionDB.CerrarConexion();
            }
            return usuario;
        }


        // Método para modificar un usuario existente
        public bool ModificarUsuario(Usuario usuario)
        {
            try
            {
                string query = "UPDATE Usuarios SET Contrasena = @Contrasena, Rol = @Rol WHERE IdUsuario = @IdUsuario";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
                    cmd.Parameters.AddWithValue("@Rol", usuario.Rol);

                    int resultado = cmd.ExecuteNonQuery();
                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                //Cierra la conexion
                conexionDB.CerrarConexion();
            }
        }

        // Método para eliminar un usuario por su ID
        public bool EliminarUsuario(int idUsuario)
        {
            try
            {
                string query = "DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    int resultado = cmd.ExecuteNonQuery();
                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conexionDB.CerrarConexion();
            }
        }
    }
}
