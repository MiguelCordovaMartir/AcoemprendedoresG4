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
    public partial class LoginForm : Form
    {
        private UsuarioDB usuarioDB = new UsuarioDB();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            // Verificar si los campos están vacíos
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre de usuario.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Por favor, ingrese la contraseña.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContrasena.Focus();
                return;
            }
            // Obtener los datos ingresados
            string nombreUsuario = txtNombreUsuario.Text;
            string contrasena = txtContrasena.Text;

            // Verificar si el usuario existe y la contraseña es correcta
            Usuario usuario = usuarioDB.ObtenerUsuarioPorNombreUsuario(nombreUsuario);

            if (usuario != null && usuario.Contrasena == contrasena)
            {
                // La autenticación fue exitosa
                MessageBox.Show("Inicio de sesión exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir el MainForm y cerrar el LoginForm
                MainForm mainForm = new MainForm(usuario); // Pasar el usuario al MainForm
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Limpia los Texbox si no se ingresa el usuario o contraseña correcta
                txtNombreUsuario.Text="";
                txtContrasena.Text = "";
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
