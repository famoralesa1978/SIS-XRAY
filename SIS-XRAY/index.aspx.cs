using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Conexion;
using Utilidades;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SIS_XRAY
{
    public partial class index : System.Web.UI.Page
    {
        clsConexion cn = new Conexion.clsConexion();
        ClsDescriptarEncriptar encDesc = new ClsDescriptarEncriptar();
        Clases.ClsUsuario clsUsu = new Clases.ClsUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {

            string usr;
            string psw;
            String strMensaje = "";
            bool valido;
            valido = true;

            usr = txtUsuario.Text.ToString();
            psw = txtPassword.Text.ToString();

            SqlCommand cmd = new SqlCommand();
            DataSet ds;
            cmd.CommandText = "pa_loginWeb_sel '" + usr + "','" + encDesc.GenerateHashMD5(psw) + "'";
            cmd.CommandType = CommandType.Text;
            ds = cn.Listar(ConfigurationManager.AppSettings["ConnectionBD"], cmd,ref strMensaje);

            if (strMensaje == "OK")
            {
                switch (ds.Tables[0].Rows.Count)
                {
                    case 0://el usuario  o contraseña no existe                         

                        string javaScript = "Mensaje();";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);

                        break;
                    case 1://cuando tiene un solo perfil asociado
                        //rut,Contraseña as clave,Id_perfil
                        clsUsu.Usuario = usr;
                        clsUsu.Id_perfil = Convert.ToInt16(ds.Tables[0].Rows[0]["Id_perfil"].ToString());
                        clsUsu.Perfil = ds.Tables[0].Rows[0]["Descripcion"].ToString();
                        clsUsu.Nombre = ds.Tables[0].Rows[0]["Razon_Social"].ToString();
                        // TransferirSegunPerfil(usr);
                        Response.Redirect("Principal.aspx");
                        break;
                    default://cuando tiene mas perfiles asociado.

                        break;
                }
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "Mensaje", "alert('" + strMensaje.Replace("'", "") + "');", true);
            }

        }

    }
}