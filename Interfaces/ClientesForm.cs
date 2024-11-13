using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Clave3_Grupo4.Clases;
using Clave3_Grupo4.DataBase;

namespace Clave3_Grupo4.Interfaces
{
    public partial class ClientesForm : Form
    {
        private ClienteDB clienteDB;
        public ClientesForm()
        {
            InitializeComponent();
            clienteDB = new ClienteDB();
            CargarTipoProductoComboBox();
            CargarClientesEnGrid();
            dataGridViewClientes.CellClick += dataGridViewClientes_CellClick;
        }
        private void CargarTipoProductoComboBox()
        {
            cmbTipoProducto.Items.AddRange(new string[]
            {
                "CuentaAhorro",
                "CuentaCorriente",
                "TarjetaDebito",
                "TarjetaCredito",
                "PrestamoPersonal",
                "PrestamoAgropecuario",
                "PrestamoHipotecario"
            });
        }
        // Método para cargar los datos de clientes en el DataGridView
        private void CargarClientesEnGrid()
        {
            DataTable dataTable = clienteDB.ObtenerTodosClientes();
            dataGridViewClientes.DataSource = dataTable;
        }

        private void LimpiarCampos()
        {
            // Limpiar los campos de entrada
            txtNombre.Clear();
            txtApellido.Clear();
            txtDUI.Clear();
            cmbTipoProducto.SelectedIndex = -1;
            txtBilleteraVirtual.Clear();
            txtBuscarCliente.Clear();
        }
        // Validación de campos vacíos
        private bool ValidarCampos()
        {
            // Validación del campo de nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validación del campo de apellido
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Por favor, ingrese el apellido.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validación del campo de DUI
            if (string.IsNullOrWhiteSpace(txtDUI.Text))
            {
                MessageBox.Show("Por favor, ingrese el DUI.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validación del formato del DUI
            string duiPattern = @"^\d{8}-\d$"; // Formato 12345678-8
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtDUI.Text, duiPattern))
            {
                MessageBox.Show("El DUI debe tener el formato 12345678-8.", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validación de selección de TipoProducto en ComboBox
            if (cmbTipoProducto.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un tipo de producto.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validación de BilleteraVirtual: debe ser un número mayor a 0
            if (!decimal.TryParse(txtBilleteraVirtual.Text, out decimal billetera) || billetera <= 0)
            {
                MessageBox.Show("Por favor, ingrese un valor válido en Billetera Virtual.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true; // Si todas las validaciones pasan, retorna true
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            Cliente cliente = new Cliente
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                DUI = txtDUI.Text,
                TipoProducto = cmbTipoProducto.SelectedItem.ToString(),
                BilleteraVirtual = decimal.TryParse(txtBilleteraVirtual.Text, out decimal billetera) ? billetera : 0
            };

            if (clienteDB.InsertarCliente(cliente))
            {
                MessageBox.Show("Cliente agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarClientesEnGrid();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al agregar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos()) return;

            int idCliente = Convert.ToInt32(dataGridViewClientes.SelectedRows[0].Cells["IdCliente"].Value);
            Cliente cliente = new Cliente
            {
                IdCliente = idCliente,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                DUI = txtDUI.Text,
                TipoProducto = cmbTipoProducto.SelectedItem.ToString(),
                BilleteraVirtual = decimal.TryParse(txtBilleteraVirtual.Text, out decimal billetera) ? billetera : 0
            };

            if (clienteDB.ModificarCliente(cliente))
            {
                MessageBox.Show("Cliente modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarClientesEnGrid();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al modificar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCliente = Convert.ToInt32(dataGridViewClientes.SelectedRows[0].Cells["IdCliente"].Value);

            DialogResult confirmacion = MessageBox.Show("¿Está seguro que desea eliminar este cliente?", "Confirmación de eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                if (clienteDB.EliminarCliente(idCliente))
                {
                    MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientesEnGrid();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // Evento para seleccionar un cliente del DataGridView y cargar los datos en los campos
        private void dataGridViewClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // se debe asegurar seleccionar una fila válida
            {
                DataGridViewRow filaSeleccionada = dataGridViewClientes.Rows[e.RowIndex];

                // Cargar los datos del cliente seleccionado en los controles de entrada
                txtNombre.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                txtApellido.Text = filaSeleccionada.Cells["Apellido"].Value.ToString();
                txtDUI.Text = filaSeleccionada.Cells["DUI"].Value.ToString();
                cmbTipoProducto.SelectedItem = filaSeleccionada.Cells["TipoProducto"].Value.ToString();
                txtBilleteraVirtual.Text = filaSeleccionada.Cells["BilleteraVirtual"].Value.ToString();
            }
        }

        private void btnObtenerClientes_Click(object sender, EventArgs e)
        {
            CargarClientesEnGrid();
            LimpiarCampos();

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

        private void ClientesForm_Load(object sender, EventArgs e)
        {

        }


        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dataGridViewClientes.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Inicializar Excel
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            var workbook = excelApp.Workbooks.Add();
            var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];

            // Exportar encabezados de columna
            for (int i = 0; i < dataGridViewClientes.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = dataGridViewClientes.Columns[i].HeaderText;
            }

            // Exportar datos de las filas
            for (int i = 0; i < dataGridViewClientes.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridViewClientes.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridViewClientes.Rows[i].Cells[j].Value?.ToString() ?? "";
                }
            }

            // Mostrar Excel
            excelApp.Visible = true;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string criterio = txtBuscarCliente.Text.Trim();

            if (string.IsNullOrWhiteSpace(criterio))
            {
                MessageBox.Show("Por favor, ingrese un nombre o apellido para buscar.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable clientesFiltrados = clienteDB.BuscarClientes(criterio);
            dataGridViewClientes.DataSource = clientesFiltrados;
        }
    }
}
