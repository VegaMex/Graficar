using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class Datos
    {
        public string ObtenerExtensiones(string valor1, string valor2)
        {
            Conector conexion = new Conector();
            var dataTable = conexion.ObtenDatosSQL("SELECT name, surfacearea from country ORDER BY surfacearea DESC LIMIT 10;");
            string datos = string.Format("[['{0}', '{1}'],", valor1, valor2);
            foreach (DataRow row in dataTable.Rows)
            {
                datos += string.Format("['{0}', {1}],", row[0], row[1]);    
            }
            return datos + "]";
        }

        // No se usa
        private string color()
        {
            return string.Format("#{0:X6}", new Random().Next(0x1000000));
        }
    }
}
