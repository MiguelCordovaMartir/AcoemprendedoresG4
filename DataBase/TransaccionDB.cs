﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Clave3_Grupo4.Clases;

namespace Clave3_Grupo4.DataBase
{
    public class TransaccionDB
    {
        private ConexionDB conexionDB = new ConexionDB();

        // Método para registrar una nueva transacción (abono o cargo) para un cliente
        public bool InsertarTransaccion(Transaccion transaccion)
        {
            try
            {
                // Consulta SQL para insertar una transacción
                string query = "INSERT INTO Transacciones (IdCliente, IdEmpleado, TipoTransaccion, Monto, Descripcion) " +
                               "VALUES (@IdCliente, @IdEmpleado, @TipoTransaccion, @Monto, @Descripcion)";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                {
                    // Asignación de parámetros
                    cmd.Parameters.AddWithValue("@IdCliente", transaccion.IdCliente);
                    cmd.Parameters.AddWithValue("@IdEmpleado", transaccion.IdEmpleado);
                    cmd.Parameters.AddWithValue("@TipoTransaccion", transaccion.TipoTransaccion);
                    cmd.Parameters.AddWithValue("@Monto", transaccion.Monto);
                    cmd.Parameters.AddWithValue("@Descripcion", transaccion.Descripcion);

                    // Ejecución del comando y verificación del resultado
                    int resultado = cmd.ExecuteNonQuery();

                    // Si se insertó correctamente, se retorna true
                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre una excepción
                MessageBox.Show("Error al insertar transacción " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                // Cierra la conexión a la base de datos
                conexionDB.CerrarConexion();
            }
        }

        // Método para obtener el historial de transacciones de un cliente
        public List<Transaccion> ObtenerTransaccionesPorCliente(int idCliente)
        {
            List<Transaccion> listaTransacciones = new List<Transaccion>();

            try
            {
                // Consulta SQL para seleccionar todas las transacciones de un cliente
                string query = "SELECT * FROM Transacciones WHERE IdCliente = @IdCliente";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Lee los resultados de la consulta
                        while (reader.Read())
                        {
                            Transaccion transaccion = new Transaccion
                            {
                                IdTransaccion = reader.GetInt32("IdTransaccion"),
                                IdCliente = reader.GetInt32("IdCliente"),
                                IdEmpleado = reader.IsDBNull(reader.GetOrdinal("IdEmpleado")) ? (int?)null : reader.GetInt32("IdEmpleado"),
                                FechaTransaccion = reader.GetDateTime("FechaTransaccion"),
                                TipoTransaccion = reader.GetString("TipoTransaccion"),
                                Monto = reader.GetDecimal("Monto"),
                                Descripcion = reader.GetString("Descripcion")
                            };
                            listaTransacciones.Add(transaccion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre una excepción
                MessageBox.Show("Error al obtener transacciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cierra la conexión a la base de datos
                conexionDB.CerrarConexion();
            }

            return listaTransacciones;
        }

        public List<Transaccion> ObtenerTodasTransacciones()
        {
            List<Transaccion> listaTransacciones = new List<Transaccion>();

            try
            {
                // Consulta SQL para seleccionar todas las transacciones sin filtrar por cliente
                string query = "SELECT * FROM Transacciones";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Transaccion transaccion = new Transaccion
                            {
                                IdTransaccion = reader.GetInt32("IdTransaccion"),
                                IdCliente = reader.GetInt32("IdCliente"),
                                IdEmpleado = reader.IsDBNull(reader.GetOrdinal("IdEmpleado")) ? (int?)null : reader.GetInt32("IdEmpleado"),
                                FechaTransaccion = reader.GetDateTime("FechaTransaccion"),
                                TipoTransaccion = reader.GetString("TipoTransaccion"),
                                Monto = reader.GetDecimal("Monto"),
                                Descripcion = reader.GetString("Descripcion")
                            };
                            listaTransacciones.Add(transaccion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener transacciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                
                conexionDB.CerrarConexion();
            }

            return listaTransacciones;
        }

        public bool EditarTransaccion(Transaccion transaccion)
        {
            try
            {
                string query = "UPDATE Transacciones SET IdCliente = @IdCliente, IdEmpleado = @IdEmpleado, TipoTransaccion = @TipoTransaccion, Monto = @Monto, Descripcion = @Descripcion WHERE IdTransaccion = @IdTransaccion";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                {
                    cmd.Parameters.AddWithValue("@IdCliente", transaccion.IdCliente);
                    cmd.Parameters.AddWithValue("@IdEmpleado", transaccion.IdEmpleado);
                    cmd.Parameters.AddWithValue("@TipoTransaccion", transaccion.TipoTransaccion);
                    cmd.Parameters.AddWithValue("@Monto", transaccion.Monto);
                    cmd.Parameters.AddWithValue("@Descripcion", transaccion.Descripcion);
                    cmd.Parameters.AddWithValue("@IdTransaccion", transaccion.IdTransaccion);

                    int resultado = cmd.ExecuteNonQuery();
                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar transacción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                //cierra la conexion
                conexionDB.CerrarConexion();
            }
        }

        public bool EliminarTransaccion(int idTransaccion)
        {
            try
            {
                string query = "DELETE FROM Transacciones WHERE IdTransaccion = @IdTransaccion";

                using (MySqlCommand cmd = new MySqlCommand(query, conexionDB.ObtenerConexion()))
                {
                    cmd.Parameters.AddWithValue("@IdTransaccion", idTransaccion);
                    int resultado = cmd.ExecuteNonQuery();
                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                //mensaje de error
                MessageBox.Show("Error al eliminar transacción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                //cierra la conexion
                conexionDB.CerrarConexion();
            }
        }


    }
}
