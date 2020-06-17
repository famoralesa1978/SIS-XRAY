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
            int intID_perfil = clsUsu.Id_perfil;
            String strMensaje = "";

            SqlCommand cmd = new SqlCommand();
            DataSet ds;
            cmd.CommandText = "pa_CargaMenuWeb_sel " + intID_perfil.ToString();
            cmd.CommandType = CommandType.Text;
            ds = cn.Listar(ConfigurationManager.AppSettings["ConnectionBD"], cmd, ref strMensaje);

            if (strMensaje == "OK")
            {
               
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "Mensaje", "alert('" + strMensaje.Replace("'", "") + "');", true);
            }
        }
    }
}