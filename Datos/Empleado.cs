using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProyectos.Datos
{
    public class Empleado
    {
        private string nombreCompleto;
        public string ID {  get; set; }
        private DateTime fechaNacimiento;
        private int Edad;
        private string CedulaID;
        private DateTime fechaContratacion;
        public string departamento { get; set; }
        private double salario;
        public string cargo {  get; set; }
        private string correoElectronico;
        private string numeroTelefono;
        private string lugarResidencia;

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
