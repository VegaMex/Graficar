using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend;

namespace Graficador
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string DameDatos()
        {
            return new Datos().ObtenerExtensiones("País", "Extensión");
        }
    }
}