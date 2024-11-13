
namespace Clave3_Grupo4.Interfaces
{
    partial class MainForm
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
            this.btnGestionTransacciones = new System.Windows.Forms.Button();
            this.btnGestionEmpleados = new System.Windows.Forms.Button();
            this.btnGestionClientes = new System.Windows.Forms.Button();
            this.btnGestionUsuarios = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGestionTransacciones
            // 
            this.btnGestionTransacciones.Location = new System.Drawing.Point(253, 184);
            this.btnGestionTransacciones.Name = "btnGestionTransacciones";
            this.btnGestionTransacciones.Size = new System.Drawing.Size(150, 23);
            this.btnGestionTransacciones.TabIndex = 5;
            this.btnGestionTransacciones.Text = "Gestion Transacciones";
            this.btnGestionTransacciones.UseVisualStyleBackColor = true;
            this.btnGestionTransacciones.Click += new System.EventHandler(this.btnGestionTransacciones_Click);
            // 
            // btnGestionEmpleados
            // 
            this.btnGestionEmpleados.Location = new System.Drawing.Point(253, 138);
            this.btnGestionEmpleados.Name = "btnGestionEmpleados";
            this.btnGestionEmpleados.Size = new System.Drawing.Size(122, 23);
            this.btnGestionEmpleados.TabIndex = 4;
            this.btnGestionEmpleados.Text = "Gestion empleados";
            this.btnGestionEmpleados.UseVisualStyleBackColor = true;
            this.btnGestionEmpleados.Click += new System.EventHandler(this.btnGestionEmpleados_Click);
            // 
            // btnGestionClientes
            // 
            this.btnGestionClientes.Location = new System.Drawing.Point(268, 77);
            this.btnGestionClientes.Name = "btnGestionClientes";
            this.btnGestionClientes.Size = new System.Drawing.Size(107, 23);
            this.btnGestionClientes.TabIndex = 3;
            this.btnGestionClientes.Text = "Gestion de clientes";
            this.btnGestionClientes.UseVisualStyleBackColor = true;
            this.btnGestionClientes.Click += new System.EventHandler(this.btnGestionClientes_Click);
            // 
            // btnGestionUsuarios
            // 
            this.btnGestionUsuarios.Location = new System.Drawing.Point(268, 234);
            this.btnGestionUsuarios.Name = "btnGestionUsuarios";
            this.btnGestionUsuarios.Size = new System.Drawing.Size(135, 23);
            this.btnGestionUsuarios.TabIndex = 6;
            this.btnGestionUsuarios.Text = "Gestion Usuarios";
            this.btnGestionUsuarios.UseVisualStyleBackColor = true;
            this.btnGestionUsuarios.Click += new System.EventHandler(this.btnGestionUsuarios_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGestionUsuarios);
            this.Controls.Add(this.btnGestionTransacciones);
            this.Controls.Add(this.btnGestionEmpleados);
            this.Controls.Add(this.btnGestionClientes);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGestionTransacciones;
        private System.Windows.Forms.Button btnGestionEmpleados;
        private System.Windows.Forms.Button btnGestionClientes;
        private System.Windows.Forms.Button btnGestionUsuarios;
    }
}