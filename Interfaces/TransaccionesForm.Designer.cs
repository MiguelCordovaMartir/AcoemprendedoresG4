
namespace Clave3_Grupo4.Interfaces
{
    partial class TransaccionesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewTransacciones = new System.Windows.Forms.DataGridView();
            this.btnVerHistorial = new System.Windows.Forms.Button();
            this.btnAgregarTransaccion = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.cmbTipoTransaccion = new System.Windows.Forms.ComboBox();
            this.dtpFechaTransaccion = new System.Windows.Forms.DateTimePicker();
            this.cmbEmpleados = new System.Windows.Forms.ComboBox();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.btnCargarTransacciones = new System.Windows.Forms.Button();
            this.btnEditarTransaccion = new System.Windows.Forms.Button();
            this.btnEliminarTransaccion = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.iNICIOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sALIEDELAAPPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransacciones)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewTransacciones
            // 
            this.dataGridViewTransacciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransacciones.Location = new System.Drawing.Point(181, 430);
            this.dataGridViewTransacciones.Name = "dataGridViewTransacciones";
            this.dataGridViewTransacciones.Size = new System.Drawing.Size(637, 198);
            this.dataGridViewTransacciones.TabIndex = 17;
            this.dataGridViewTransacciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTransacciones_CellClick);
            // 
            // btnVerHistorial
            // 
            this.btnVerHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerHistorial.Location = new System.Drawing.Point(772, 142);
            this.btnVerHistorial.Name = "btnVerHistorial";
            this.btnVerHistorial.Size = new System.Drawing.Size(143, 29);
            this.btnVerHistorial.TabIndex = 16;
            this.btnVerHistorial.Text = "Ver Historial";
            this.btnVerHistorial.UseVisualStyleBackColor = true;
            this.btnVerHistorial.Click += new System.EventHandler(this.btnVerHistorial_Click);
            // 
            // btnAgregarTransaccion
            // 
            this.btnAgregarTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarTransaccion.Location = new System.Drawing.Point(493, 145);
            this.btnAgregarTransaccion.Name = "btnAgregarTransaccion";
            this.btnAgregarTransaccion.Size = new System.Drawing.Size(163, 30);
            this.btnAgregarTransaccion.TabIndex = 15;
            this.btnAgregarTransaccion.Text = "AgregarTransaccion";
            this.btnAgregarTransaccion.UseVisualStyleBackColor = true;
            this.btnAgregarTransaccion.Click += new System.EventHandler(this.btnAgregarTransaccion_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(232, 340);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(176, 22);
            this.txtDescripcion.TabIndex = 14;
            // 
            // txtMonto
            // 
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.Location = new System.Drawing.Point(232, 297);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(176, 22);
            this.txtMonto.TabIndex = 13;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // cmbTipoTransaccion
            // 
            this.cmbTipoTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoTransaccion.FormattingEnabled = true;
            this.cmbTipoTransaccion.Location = new System.Drawing.Point(232, 253);
            this.cmbTipoTransaccion.Name = "cmbTipoTransaccion";
            this.cmbTipoTransaccion.Size = new System.Drawing.Size(176, 24);
            this.cmbTipoTransaccion.TabIndex = 12;
            // 
            // dtpFechaTransaccion
            // 
            this.dtpFechaTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaTransaccion.Location = new System.Drawing.Point(232, 212);
            this.dtpFechaTransaccion.Name = "dtpFechaTransaccion";
            this.dtpFechaTransaccion.Size = new System.Drawing.Size(227, 22);
            this.dtpFechaTransaccion.TabIndex = 11;
            // 
            // cmbEmpleados
            // 
            this.cmbEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpleados.FormattingEnabled = true;
            this.cmbEmpleados.Location = new System.Drawing.Point(232, 184);
            this.cmbEmpleados.Name = "cmbEmpleados";
            this.cmbEmpleados.Size = new System.Drawing.Size(176, 24);
            this.cmbEmpleados.TabIndex = 10;
            // 
            // cmbClientes
            // 
            this.cmbClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(232, 147);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(176, 24);
            this.cmbClientes.TabIndex = 9;
            // 
            // btnCargarTransacciones
            // 
            this.btnCargarTransacciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarTransacciones.Location = new System.Drawing.Point(493, 297);
            this.btnCargarTransacciones.Name = "btnCargarTransacciones";
            this.btnCargarTransacciones.Size = new System.Drawing.Size(163, 54);
            this.btnCargarTransacciones.TabIndex = 18;
            this.btnCargarTransacciones.Text = "Cargar Todas las transacciones";
            this.btnCargarTransacciones.UseVisualStyleBackColor = true;
            this.btnCargarTransacciones.Click += new System.EventHandler(this.btnCargarTransacciones_Click);
            // 
            // btnEditarTransaccion
            // 
            this.btnEditarTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarTransaccion.Location = new System.Drawing.Point(493, 193);
            this.btnEditarTransaccion.Name = "btnEditarTransaccion";
            this.btnEditarTransaccion.Size = new System.Drawing.Size(163, 35);
            this.btnEditarTransaccion.TabIndex = 19;
            this.btnEditarTransaccion.Text = "Editar Transaccion";
            this.btnEditarTransaccion.UseVisualStyleBackColor = true;
            this.btnEditarTransaccion.Click += new System.EventHandler(this.btnEditarTransaccion_Click);
            // 
            // btnEliminarTransaccion
            // 
            this.btnEliminarTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarTransaccion.Location = new System.Drawing.Point(493, 251);
            this.btnEliminarTransaccion.Name = "btnEliminarTransaccion";
            this.btnEliminarTransaccion.Size = new System.Drawing.Size(163, 30);
            this.btnEliminarTransaccion.TabIndex = 20;
            this.btnEliminarTransaccion.Text = "Eliminar Transaccion";
            this.btnEliminarTransaccion.UseVisualStyleBackColor = true;
            this.btnEliminarTransaccion.Click += new System.EventHandler(this.btnEliminarTransaccion_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarExcel.Location = new System.Drawing.Point(772, 251);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(153, 29);
            this.btnExportarExcel.TabIndex = 21;
            this.btnExportarExcel.Text = "Exportar a Excel";
            this.btnExportarExcel.UseVisualStyleBackColor = true;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Wheat;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iNICIOToolStripMenuItem,
            this.sALIEDELAAPPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(978, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // iNICIOToolStripMenuItem
            // 
            this.iNICIOToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.iNICIOToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iNICIOToolStripMenuItem.Name = "iNICIOToolStripMenuItem";
            this.iNICIOToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.iNICIOToolStripMenuItem.Text = "INICIO";
            this.iNICIOToolStripMenuItem.Click += new System.EventHandler(this.iNICIOToolStripMenuItem_Click);
            // 
            // sALIEDELAAPPToolStripMenuItem
            // 
            this.sALIEDELAAPPToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.sALIEDELAAPPToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sALIEDELAAPPToolStripMenuItem.Name = "sALIEDELAAPPToolStripMenuItem";
            this.sALIEDELAAPPToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.sALIEDELAAPPToolStripMenuItem.Text = "SALIR DE LA APP";
            this.sALIEDELAAPPToolStripMenuItem.Click += new System.EventHandler(this.sALIEDELAAPPToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(707, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Selecione el nombre del cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(769, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Generar archivo Excel ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Seleccione el cliente:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(53, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "Selecione el empleado:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(165, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "Fecha:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(74, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "Elija Bono o Cargo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(121, 340);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 16);
            this.label7.TabIndex = 30;
            this.label7.Text = "Descripcion:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(162, 297);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 16);
            this.label8.TabIndex = 31;
            this.label8.Text = "Monto:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(193, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(549, 20);
            this.label9.TabIndex = 32;
            this.label9.Text = "LLENE TODOS LOS CAMPOS PARA AÑADIR UNA TRANSACCION";
            // 
            // TransaccionesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(978, 661);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.btnEliminarTransaccion);
            this.Controls.Add(this.btnEditarTransaccion);
            this.Controls.Add(this.btnCargarTransacciones);
            this.Controls.Add(this.dataGridViewTransacciones);
            this.Controls.Add(this.btnVerHistorial);
            this.Controls.Add(this.btnAgregarTransaccion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.cmbTipoTransaccion);
            this.Controls.Add(this.dtpFechaTransaccion);
            this.Controls.Add(this.cmbEmpleados);
            this.Controls.Add(this.cmbClientes);
            this.Name = "TransaccionesForm";
            this.Text = "TransaccionesForm";
            this.Load += new System.EventHandler(this.TransaccionesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransacciones)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTransacciones;
        private System.Windows.Forms.Button btnVerHistorial;
        private System.Windows.Forms.Button btnAgregarTransaccion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.ComboBox cmbTipoTransaccion;
        private System.Windows.Forms.DateTimePicker dtpFechaTransaccion;
        private System.Windows.Forms.ComboBox cmbEmpleados;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.Button btnCargarTransacciones;
        private System.Windows.Forms.Button btnEditarTransaccion;
        private System.Windows.Forms.Button btnEliminarTransaccion;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iNICIOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sALIEDELAAPPToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}