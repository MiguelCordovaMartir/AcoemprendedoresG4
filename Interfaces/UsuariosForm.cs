using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clave3_Grupo4.DataBase;
using Clave3_Grupo4.Clases;

namespace Clave3_Grupo4.Interfaces
{
    public partial class UsuariosForm : Form
    {
        private UsuarioDB usuarioDB = new UsuarioDB();

        public UsuariosForm()
        {
            InitializeComponent();
            ConfigurarComboBoxRoles();
            CargarUsuarios();
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposUsuario()) return;

            Usuario nuevoUsuario = new Usuario
            {
                NombreUsuario = txtNombreUsuario.Text,
                Contrasena = txtContrasena.Text,
                Rol = cmbRol.SelectedItem.ToString()
            };

            if (usuarioDB.InsertarUsuario(nuevoUsuario))
            {
                MessageBox.Show("Usuario agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al agregar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Configura el ComboBox de roles
        private void ConfigurarComboBoxRoles()
        {
            cmbRol.Items.AddRange(new string[] { "Cajero", "Asesor", "AtencionCliente", "Gerente" });
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Carga los usuarios en el DataGridView
        private void CargarUsuarios()
        {
            DataTable usuarios = usuarioDB.ObtenerTodosUsuarios();
            dataGridViewUsuarios.DataSource = usuarios;
        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCamposUsuario()) return;

            int idUsuario = Convert.ToInt32(dataGridViewUsuarios.SelectedRows[0].Cells["IdUsuario"].Value);
            Usuario usuarioModificado = new Usuario
            {
                IdUsuario = idUsuario,
                NombreUsuario = txtNombreUsuario.Text,
                Contrasena = txtContrasena.Text,
                Rol = cmbRol.SelectedItem.ToString()
            };

            if (usuarioDB.ModificarUsuario(usuarioModificado))
            {
                MessageBox.Show("Usuario modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al modificar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idUsuario = Convert.ToInt32(dataGridViewUsuarios.SelectedRows[0].Cells["IdUsuario"].Value);

            DialogResult confirmacion = MessageBox.Show("¿Está seguro que desea eliminar este usuario?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmacion == DialogResult.Yes)
            {
                if (usuarioDB.EliminarUsuario(idUsuario))
                {
                    MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // Validación de campos vacíos
        private bool ValidarCamposUsuario()
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text) ||
                cmbRol.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Limpiar campos del formulario
        private void LimpiarCampos()
        {
            txtNombreUsuario.Clear();
            txtContrasena.Clear();
            cmbRol.SelectedIndex = -1;
        }

        private void btnConsultarUsuarios_Click(object sender, EventArgs e)
        {

        }

        private void iNICIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abre el inicio y cierra el formulario actual
            InicioForm InicioForm = new InicioForm();
            this.Hide();
            InicioForm.ShowDialog();
            this.Close();
        }

        private void sALIEDELAAPPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
