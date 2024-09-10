using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProyectos.Datos
{
    public class Empleado
    {
        public string nombreCompleto {  get; set; }
        public string ID {  get; set; }
        public DateTime fechaNacimiento {  get; set; }
        public int Edad {  get; set; }
        public string CedulaID { get; set; }
        public DateTime fechaContratacion {  get; set; }
        public string departamento { get; set; }
        public double salario { get; set; }
        public string cargo {  get; set; }
        public string correoElectronico { get; set; }
        public string numeroTelefono { get; set; }
        public string lugarResidencia { get; set; }

        public Empleado(string nombreCompleto, string ID, DateTime fechaNacimiento, int edad, string cedulaID, DateTime fechaContratacion, string departamento, double salario, string cargo, string correoElectronico, string numeroTelefono, string lugarResidencia)
        {
            this.salario = salario;
            this.cargo = cargo;
            this.ID = ID;
            this.CedulaID = cedulaID;
            this.fechaContratacion = fechaContratacion;
            this.Edad=edad;
            this.fechaNacimiento = fechaNacimiento;
            this.correoElectronico = correoElectronico;
            this.lugarResidencia = lugarResidencia;
            this.numeroTelefono = numeroTelefono;
            this.nombreCompleto = nombreCompleto;
            this.departamento = departamento;
        }
    }
}
