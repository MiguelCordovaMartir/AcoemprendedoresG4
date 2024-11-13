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
    public partial class MainForm : Form
    {
        private Usuario usuarioActual; // Variable para almacenar el usuario actual
        public MainForm()
        {
            InitializeComponent();
        }
        // Constructor que recibe un objeto Empleado
        public MainForm(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            ConfigurarAccesoPorRol();
        }

        private void ConfigurarAccesoPorRol()
        {
            // Configura acceso según el rol
            if (usuarioActual.Rol == "Cajero")
            {
                btnGestionClientes.Enabled = false;
                btnGestionUsuarios.Enabled = false;
                btnGestionEmpleados.Enabled = false;
            }
            else if (usuarioActual.Rol == "Asesor")
            {
                btnGestionUsuarios.Enabled = false;
                btnGestionTransacciones.Enabled = false;
                btnGestionEmpleados.Enabled = false;
            }
            else if (usuarioActual.Rol == "AtencionCliente")
            {
                btnGestionUsuarios.Enabled = false;
                btnGestionTransacciones.Enabled = false;
                btnGestionEmpleados.Enabled = false;
            }
            // Gerente tiene acceso completo
        }

        private void btnGestionClientes_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de gestión de clientes
            ClientesForm clientesForm = new ClientesForm();
            this.Hide();
            clientesForm.ShowDialog();
            this.Close();



        }

        private void btnGestionEmpleados_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de gestión de Empleados
            EmpleadosForm empleadosForm = new EmpleadosForm();
            this.Hide();
            empleadosForm.ShowDialog();
            this.Close();
        }

        private void btnGestionTransacciones_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de gestión de clientes
            TransaccionesForm transaccionesForm = new TransaccionesForm();
            this.Hide();
            transaccionesForm.ShowDialog();
            this.Close();
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            //abre el formulario Usuarios y cierra el actual
            UsuariosForm usuariosForm = new UsuariosForm();
            this.Hide();
            usuariosForm.ShowDialog();
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
