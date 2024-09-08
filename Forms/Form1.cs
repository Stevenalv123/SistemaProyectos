using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaProyectos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int selectedIndex;
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = tbDepartamentos.SelectedIndex;
            switch (selectedIndex)
            {
                case 0:
                    lblID.Visible = false;
                    txtID.Visible = false;
                    lblPestaña.Text = "Empleados";
                    lblID.Text= "ID del Empleado:"; lblID.Font = new Font(btnNuevoEmpleado.Font.FontFamily, 16, FontStyle.Bold);
                    btnNuevoEmpleado.Text = "Nuevo Empleado"; btnNuevoEmpleado.Font = new Font(btnNuevoEmpleado.Font.FontFamily, 16,FontStyle.Bold);
                    break; 
                case 1:
                    lblID.Visible = false;
                    txtID.Visible = false;
                    lblPestaña.Text = "Departamentos";
                    lblID.Text = "ID del Departamento:"; lblID.Font = new Font(btnNuevoEmpleado.Font.FontFamily, 13, FontStyle.Bold);
                    tblDepart.Visible = false;
                    btnNuevoEmpleado.Text = "Nuevo Departamento"; btnNuevoEmpleado.Font = new Font(btnNuevoEmpleado.Font.FontFamily, 12,FontStyle.Bold);
                    break;
            }

        }

        private void btnNuevoEmpleado_Click(object sender, EventArgs e)
        {
            switch (selectedIndex)
            {
                case 0:
                    tblCuerpo.Visible = true;
                    lblID.Visible = true;
                    txtID.Visible = true;
                    txtNombreEmpleado.Focus();
                    tblDepart.Visible=false;
                    break;
                case 1:
                    tblDepart.Visible = true;
                    lblID.Visible = true;
                    txtID.Visible=true;
                    txtNombreDepartamento.Focus();
                    tblCuerpo.Visible=false;
                    break;
            }
        }

        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateseleccionada=dtpFechaNacimiento.Value;

            txtEdad.Text = $"{CalcularEdad(dateseleccionada)} años";
            
        }

        private int CalcularEdad(DateTime fechaNacimiento)
        {
            DateTime d=DateTime.Now;

            int edad=d.Year-fechaNacimiento.Year;

            if (d.Month < fechaNacimiento.Month || (d.Month == fechaNacimiento.Month && d.Day < fechaNacimiento.Day))
            {
                edad--;
            }

            return edad;
        }

        ErrorProvider errorProvider = new ErrorProvider();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {   
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtSalario.Text, @"^\d+(,\d+)?$"
))
            {
                errorProvider.SetError(txtSalario, "Solo se permiten números.");
            }
            else
            {
                errorProvider.SetError(txtSalario, "");
            }
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tblCuerpo.Visible= false;
            tblDepart.Visible= false;
            
        }

        private void ValidarSalario()
        {
            if (!(errFormato.GetError(txtSalario) == ""))
            {
                MessageBox.Show("El formato del salario no es valido","Error de formato",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtSalario.Focus();
            }
        }

        private void txtCorreo_Click(object sender, EventArgs e)
        {
            ValidarSalario();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtDNI.Text, @"^\d{13}[A-Z]$"))
            {
                errorProvider.SetError(txtDNI, "Formato incorrecto");
            }
            else
            {
                errorProvider.SetError(txtDNI, "");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();   
        }

        private void LimpiarControles()
        {
            txtNombreEmpleado.Clear();
            txtDNI.Clear();
            txtSalario.Clear();
            txtCorreo.Clear();
            cmbCargo.Items.Clear();
            cmbDepartamento.Items.Clear();
            txtResidencia.Clear();
            txtnumeroTelefono.Clear();
            txtEdad.Clear();
            txtNombreDepartamento.Clear();
            txtJefeDepartamento.Clear();
            cmbNumeroEmpleados.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }
    }
}
