using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaProyectos.Datos
{
    public class Departamento
    {
        public string id {  get; set; }
        private string nombre;
        private string jefe;
        public int numEmpleados { get; set; }

        public Departamento(string id,string nombre, string jefe, int numEmpleados)
        {
            this.id = id;
            this.nombre = nombre;
            this.jefe = jefe;
            this.numEmpleados=numEmpleados;
        }
        


        
            
        
    }
}
