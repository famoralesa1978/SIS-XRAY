using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Conexion;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SIS_XRAY
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        Clases.ClsUsuario clsUsu = new Clases.ClsUsuario();
        clsConexion cn = new Conexion.clsConexion();

        protected void Page_Load(object sender, EventArgs e)
        {
     
    }
  }
}