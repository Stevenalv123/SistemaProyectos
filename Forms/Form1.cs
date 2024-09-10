using SistemaProyectos.Datos;
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
        List<Empleado> listaEmpleados=new List<Empleado>();
        List<Departamento> listaDepartamentos=new List<Departamento>();
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
                    txtID.Text = GenerarCodigo();
                    MostrarDepartamentos();
                    break;
                case 1:
                    tblDepart.Visible = true;
                    lblID.Visible = true;
                    txtID.Visible=true;
                    txtNombreDepartamento.Focus();
                    tblCuerpo.Visible=false;
                    txtID.Text= GenerarCodigo();
                    break;
            }
        }

        public void MostrarDepartamentos()
        {
            foreach(var departamentos in listaDepartamentos)
            {
                cmbDepartamento.Items.Add(departamentos.nombre);
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
            cmbCargo.Text="";
            cmbDepartamento.Text = "";
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string idEmpleado = txtID.Text;
                string nombreEmpleado = txtNombreEmpleado.Text;
                DateTime fechaNacimiento = dtpFechaNacimiento.Value;
                int edadEmpleado = Convert.ToInt32(txtEdad.Text[1]);
                string CedulaEmpleado = txtDNI.Text;
                DateTime fechaContratacion= DateTime.Now;
                string Departamento = cmbDepartamento.Text;
                double salario = Convert.ToDouble(txtSalario.Text);
                string cargo=cmbCargo.Text;
                string correoElectronico=txtCorreo.Text;
                string numeroTelefono = txtnumeroTelefono.Text;
                string lugarResidencia = txtResidencia.Text;

                Empleado empleado = new Empleado(nombreEmpleado, idEmpleado, fechaNacimiento, edadEmpleado, CedulaEmpleado, fechaContratacion, Departamento, salario, cargo, correoElectronico, numeroTelefono, lugarResidencia);
                listaEmpleados.Add(empleado);


                MessageBox.Show("El empleado se guardo correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarControles();
                MostrarDatos();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al Guardar el empleado {ex}","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string idDepartamento=txtID.Text;
                string nombreDepartamento = txtNombreDepartamento.Text;
                string jefeDepartamento = txtJefeDepartamento.Text;
                int cantEmpleados=Convert.ToInt32(cmbNumeroEmpleados.SelectedIndex.ToString());

                Departamento departamento=new Departamento(idDepartamento,nombreDepartamento,jefeDepartamento,cantEmpleados);
                
                listaDepartamentos.Add(departamento);

                MessageBox.Show("El departamento se guardo correctamente","Exito",MessageBoxButtons.OK,MessageBoxIcon.Information);
                LimpiarControles();
                MostrarDatos();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al Guardar el departamento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerarCodigo()
        {
            Random random = new Random();
            int numRandom = random.Next(100000, 999999);
            switch (selectedIndex)
            {
                case 0:
                    return $"E{numRandom}";
                case 1:
                    return $"D{numRandom}";
                default:
                    return null;
            }
                
        }

        public void MostrarDatos()
        {
            DataTable dt = new DataTable();
            switch (selectedIndex)
            {
                case 0:
                    dt.Columns.Add("ID",typeof(string));
                    dt.Columns.Add("Nombre",typeof(string));
                    dt.Columns.Add("Fecha de Nacimiento",typeof (DateTime));
                    dt.Columns.Add("Edad",typeof(int));
                    dt.Columns.Add("Cedula", typeof(string));
                    dt.Columns.Add("Departamento", typeof(string));
                    dt.Columns.Add("Salario", typeof(double));
                    dt.Columns.Add("Cargo",typeof(string));
                    dt.Columns.Add("Correo electronico", typeof(string));
                    dt.Columns.Add("Numero de telefono", typeof (string));
                    dt.Columns.Add("Lugar de residencia", typeof(string));
                    dt.Columns.Add("Fecha de contratacion",typeof(DateTime));

                    foreach(var empleados in listaEmpleados)
                    {
                        DataRow row = dt.NewRow();
                        row["ID"]=empleados.ID;
                        row["Nombre"] = empleados.nombreCompleto;
                        row["Fecha de Nacimiento"]=empleados.fechaNacimiento;
                        row["Edad"] = empleados.Edad;
                        row["Cedula"]=empleados.CedulaID;
                        row["Departamento"] = empleados.departamento;
                        row["Salario"] = empleados.salario;
                        row["Cargo"] = empleados.cargo;
                        row["Correo electronico"] = empleados.correoElectronico;
                        row["Numero de telefono"] = empleados.numeroTelefono;
                        row["Lugar de residencia"] = empleados.lugarResidencia;
                        row["Fecha de contratacion"] = empleados.fechaContratacion;

                        dt.Rows.Add(row);
                    }

                    dataEmpleados.DataSource = dt;
                    break;
                case 1:
                    dt.Columns.Add("ID",typeof(string));
                    dt.Columns.Add("Nombre",typeof(string));
                    dt.Columns.Add("Jefe",typeof (string));
                    dt.Columns.Add("Numero de empleados", typeof(int));

                    foreach(var departamentos in listaDepartamentos)
                    {
                        DataRow row= dt.NewRow();
                        row["ID"] = departamentos.id;
                        row["Nombre"] = departamentos.nombre;
                        row["Jefe"] = departamentos.jefe;
                        row["Numero de empleados"] = departamentos.numEmpleados;

                        dt.Rows.Add(row);
                    }
                    dataDepartamentos.DataSource = dt;
                    break;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
