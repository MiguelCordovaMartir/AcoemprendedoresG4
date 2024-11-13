using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clave3_Grupo4.Clases;
using Clave3_Grupo4.DataBase;
using Excel = Microsoft.Office.Interop.Excel;

namespace Clave3_Grupo4.Interfaces
{
    public partial class TransaccionesForm : Form
    {
        private TransaccionDB transaccionDB = new TransaccionDB();
        private ClienteDB clienteDB = new ClienteDB();
        private EmpleadoDB empleadoDB = new EmpleadoDB();
        public TransaccionesForm()
        {
            InitializeComponent();
            CargarTodasTransacciones();
            ConfigurarComboBoxes(); // Configura los ComboBoxes para que no permitan entrada de texto libre
            CargarClientes(); // Carga la lista de clientes en el ComboBox correspondiente
            CargarEmpleados(); // Carga la lista de empleados en el ComboBox correspondiente
            CargarTipoTransaccion(); // Carga los tipos de transacción en el ComboBox
            LimpiarCamposTransaccion(); // Limpia los campos del formulario

        }

        private void ConfigurarComboBoxes()
        {
            cmbClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmpleados.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoTransaccion.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CargarClientes()
        {
            try
            {
                DataTable clientes = clienteDB.ObtenerTodosClientes();
                cmbClientes.DataSource = clientes; // Asigna los datos de clientes al ComboBox
                cmbClientes.DisplayMember = "Nombre";
                cmbClientes.ValueMember = "IdCliente";
                cmbClientes.SelectedIndex = -1; // Deselecciona cualquier opción
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarEmpleados()
        {
            try
            {
                DataTable empleados = empleadoDB.ObtenerTodosEmpleados();
                cmbEmpleados.DataSource = empleados; // Asigna los datos de empleados al ComboBox
                cmbEmpleados.DisplayMember = "Nombre";
                cmbEmpleados.ValueMember = "IdEmpleado";
                cmbEmpleados.SelectedIndex = -1; // Deselecciona cualquier opción
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTipoTransaccion()
        {
            cmbTipoTransaccion.Items.AddRange(new string[] { "Abono", "Cargo" }); // Agrega tipos de transacción al ComboBox
            cmbTipoTransaccion.SelectedIndex = -1; // Deselecciona cualquier opción
        }
        private void CargarTodasTransacciones()
        {
            try
            {
                dataGridViewTransacciones.DataSource = transaccionDB.ObtenerTodasTransacciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar todas las transacciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAgregarTransaccion_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposTransaccion()) return;

            Transaccion transaccion = new Transaccion
            {
                IdCliente = Convert.ToInt32(cmbClientes.SelectedValue),
                IdEmpleado = cmbEmpleados.SelectedValue != null ? (int?)Convert.ToInt32(cmbEmpleados.SelectedValue) : null,
                TipoTransaccion = cmbTipoTransaccion.SelectedItem.ToString(),
                Monto = Convert.ToDecimal(txtMonto.Text),
                Descripcion = txtDescripcion.Text
            };

            if (transaccionDB.InsertarTransaccion(transaccion))
            {
                MessageBox.Show("Transacción agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTodasTransacciones(); // Recarga todas las transacciones después de agregar una nueva
                LimpiarCamposTransaccion();
            }
            else
            {
                MessageBox.Show("Error al agregar la transacción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool ValidarCamposTransaccion()
        {
            if (cmbClientes.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un cliente.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbEmpleados.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un empleado.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbTipoTransaccion.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione el tipo de transacción.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMonto.Text) || !decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Por favor, ingrese un monto válido (mayor que cero) usando solo números.", "Monto Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Por favor, ingrese una descripción para la transacción.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarCamposTransaccion()
        {
            // Limpia todos los campos del formulario
            cmbClientes.SelectedIndex = -1;
            cmbEmpleados.SelectedIndex = -1;
            cmbTipoTransaccion.SelectedIndex = -1;
            txtMonto.Clear();
            txtDescripcion.Clear();
        }

        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            CargarHistorialTransacciones(); // Carga el historial de transacciones del cliente seleccionado
        }

        private void CargarHistorialTransacciones()
        {
            try
            {
                if (cmbClientes.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un cliente para ver su historial de transacciones.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idCliente = Convert.ToInt32(cmbClientes.SelectedValue);
                dataGridViewTransacciones.DataSource = transaccionDB.ObtenerTransaccionesPorCliente(idCliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el historial de transacciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos, el punto decimal y la tecla de retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Bloquear cualquier otro carácter
            }

            // Solo permitir un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void dataGridViewTransacciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewTransacciones.Rows[e.RowIndex];
                cmbClientes.SelectedValue = Convert.ToInt32(row.Cells["IdCliente"].Value);
                cmbEmpleados.SelectedValue = row.Cells["IdEmpleado"].Value != DBNull.Value ? Convert.ToInt32(row.Cells["IdEmpleado"].Value) : (int?)null;
                cmbTipoTransaccion.SelectedItem = row.Cells["TipoTransaccion"].Value.ToString();
                txtMonto.Text = row.Cells["Monto"].Value.ToString();
                txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
            }
        }

        private void btnCargarTransacciones_Click(object sender, EventArgs e)
        {
            CargarTodasTransacciones();//carga todas las transacciones 
            LimpiarCamposTransaccion(); // Limpia los campos del formulario
        }

        private void btnEditarTransaccion_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposTransaccion()) return;

            int idTransaccion = Convert.ToInt32(dataGridViewTransacciones.CurrentRow.Cells["IdTransaccion"].Value);
            Transaccion transaccion = new Transaccion
            {
                IdTransaccion = idTransaccion,
                IdCliente = Convert.ToInt32(cmbClientes.SelectedValue),
                IdEmpleado = cmbEmpleados.SelectedValue != null ? (int?)Convert.ToInt32(cmbEmpleados.SelectedValue) : null,
                TipoTransaccion = cmbTipoTransaccion.SelectedItem.ToString(),
                Monto = Convert.ToDecimal(txtMonto.Text),
                Descripcion = txtDescripcion.Text
            };

            if (transaccionDB.EditarTransaccion(transaccion))
            {
                MessageBox.Show("Transacción actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarHistorialTransacciones();
                LimpiarCamposTransaccion();
            }
            else
            {
                MessageBox.Show("Error al actualizar la transacción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarTransaccion_Click(object sender, EventArgs e)
        {
            int idTransaccion = Convert.ToInt32(dataGridViewTransacciones.CurrentRow.Cells["IdTransaccion"].Value);
            var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar esta transacción?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                if (transaccionDB.EliminarTransaccion(idTransaccion))
                {
                    MessageBox.Show("Transacción eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarHistorialTransacciones();
                    LimpiarCamposTransaccion();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la transacción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExportarTransaccionesAExcel()
        {
            if (dataGridViewTransacciones.Rows.Count > 0)
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Workbooks.Add();
                Excel._Worksheet worksheet = excelApp.ActiveSheet;

                // Exportar encabezados
                for (int i = 0; i < dataGridViewTransacciones.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dataGridViewTransacciones.Columns[i].HeaderText;
                }

                // Exportar datos
                for (int i = 0; i < dataGridViewTransacciones.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewTransacciones.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridViewTransacciones.Rows[i].Cells[j].Value.ToString();
                    }
                }

                excelApp.Visible = true;
            }
            else
            {
                MessageBox.Show("No hay datos para exportar.", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            ExportarTransaccionesAExcel();
        }
    }
}

