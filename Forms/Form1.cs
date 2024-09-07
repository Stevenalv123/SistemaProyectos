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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblPestaña.Text == "Empleados")
            {
                lblPestaña.Text = "Departamentos";
            }
            else
            {
                lblPestaña.Text = "Empleados";
            }

        }

        private void btnNuevoEmpleado_Click(object sender, EventArgs e)
        {
            tblCuerpo.Visible = true;
            lblIDempleado.Visible = true;
            txtIDempleado.Visible=true;
            txtNombre.Focus();
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
    }
}
