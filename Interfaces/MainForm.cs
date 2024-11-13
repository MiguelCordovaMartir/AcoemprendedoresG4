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
            }
            else if (usuarioActual.Rol == "AtencionCliente")
            {
                btnGestionUsuarios.Enabled = false;
                btnGestionTransacciones.Enabled = false;
            }
            // Gerente tiene acceso completo
        }

        private void btnGestionClientes_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de gestión de clientes
            ClientesForm clientesForm = new ClientesForm();
            clientesForm.ShowDialog();


        }

        private void btnGestionEmpleados_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de gestión de Empleados
            EmpleadosForm empleadosForm = new EmpleadosForm();
            empleadosForm.ShowDialog();
        }

        private void btnGestionTransacciones_Click(object sender, EventArgs e)
        {
            // Abrir el formulario de gestión de clientes
            TransaccionesForm transaccionesForm = new TransaccionesForm();
            transaccionesForm.ShowDialog();
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            UsuariosForm usuariosForm = new UsuariosForm();
            usuariosForm.ShowDialog();
        }
    }
}
