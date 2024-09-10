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
        public string nombre { get; set; }
        public string jefe {  get; set; }
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
