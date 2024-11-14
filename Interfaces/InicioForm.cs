using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//autores: Miguel Angel Cordova 
//Susana Valeria Palacios Menjivar
//Kevin Alexander Chavarría Turcios

//fecha de inicio 30/10/2024
//fecha de finalizacion 13/11/2024

/*
Resumen de la Aplicación:

La aplicación de "ACOEMPRENDEDORES" es un sistema de gestión desarrollado para cooperativas financieras que permite la administración de clientes, empleados, y transacciones. 
Sus principales funcionalidades incluyen:

- **Gestión de Clientes**: Registro de clientes con datos como nombre, apellido, DUI, tipo de producto financiero (cuenta de ahorro, cuenta corriente, tarjeta, préstamo), y saldo en una billetera virtual.
- **Gestión de Empleados y Roles**: Registro de empleados con roles específicos (Cajero, Asesor, Atención al Cliente, Gerente) que determinan los permisos para operaciones específicas. Los roles definen tareas como agregar transacciones, modificar información de clientes o dar de baja a clientes.
- **Transacciones y Historial**: Registro y visualización de transacciones de clientes, con control de abonos y cargos. Permite la consulta de transacciones y su historial completo.
- **Módulo de Usuarios y Login Seguro**: Autenticación de usuarios para acceder a la aplicación, con opciones de crear, modificar, y eliminar usuarios.
- **Exportación de Datos a Excel**: Función para exportar datos de clientes, empleados y transacciones a archivos Excel para un mejor manejo de reportes y análisis.

Este sistema de escritorio centraliza la información, mejora el control de datos, y facilita la operación segura de la cooperativa.
*/


namespace Clave3_Grupo4.Interfaces
{
    public partial class InicioForm : Form
    {
        public InicioForm()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // Abre el LoginForm y cierra el InicioForm
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
