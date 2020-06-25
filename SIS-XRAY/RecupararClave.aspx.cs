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
    public partial class RecupararClave : System.Web.UI.Page
    {
        clsConexion cn = new Conexion.clsConexion();        
        Clases.ClsUsuario clsUsu = new Clases.ClsUsuario();
        Clases.clsUtilidades clsutil = new Clases.clsUtilidades();
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            SqlCommand cmd;
            DataSet ds;
            String strMensaje = "";
            if (txtVerificationCode.Text.ToLower() == Session["CaptchaVerify"].ToString())
            {
                cmd = new SqlCommand
                {
                    CommandText = "SELECT run,Razon_Social,Email,Clave " +
                       " FROM tbl_cliente WHERE run= '" + txtRut.Text + "'" +
                       " union " +
                       " SELECT run,Razon_Social,Email,Clave " +
                       " FROM tbl_cliente_Historial WHERE run= '" + txtRut.Text + "'"
                };
                ds = cn.Listar(ConfigurationManager.AppSettings["ConnectionBD"], cmd, ref strMensaje);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        clsutil.SendMailGmailRecuperarContrasena(ds.Tables[0].Rows[0]["run"].ToString(), ds.Tables[0].Rows[0]["Razon_Social"].ToString(),
                                       "Recuperación de contraseña", ds.Tables[0].Rows[0]["Email"].ToString(), ds.Tables[0].Rows[0]["Clave"].ToString());
                    }
                    else
                    {
                      //  btn_Grabar.Enabled = false;
                       // btn_RestablecerContrasena.Enabled = false;
                    }
                }
            }
            else
            {
                lblCaptchaMessage.Text = "Ingrese captcha Correcta!";
                lblCaptchaMessage.ForeColor = System.Drawing.Color.Red;
            }

         /*   string usr;
            string psw;
            String strMensaje="";
            bool valido;
            valido = true;

            usr = txtUsuario.Text.ToString();
       
            SqlCommand cmd = new SqlCommand();
            DataSet ds;
          //  cmd.CommandText = "pa_loginWeb_sel '" + usr + "','" + encDesc.GenerateHashMD5( psw) + "'";
            cmd.CommandType = CommandType.Text;
            string name = ConfigurationManager.AppSettings["ConnectionBD"];
            ds = cn.Listar(name, cmd,ref strMensaje);

            if (strMensaje == "OK")
            {
                switch (ds.Tables[0].Rows.Count)
                {
                    case 0://el usuario  o contraseña no existe
                        // System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "Mensaje", "alert('usuario y contraseña incorrecta');", true);
                      //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                        break;
                    case 1://cuando tiene un solo perfil asociado
                        //rut,Contraseña as clave,Id_perfil
                        clsUsu.Usuario = usr;
                        clsUsu.Id_perfil = Convert.ToInt16( ds.Tables[0].Rows[0]["Id_perfil"].ToString());
                        // TransferirSegunPerfil(usr);
                        Response.Redirect("Principal.aspx");
                        break;
                    default://cuando tiene mas perfiles asociado.
                        // code block
                        break;
                }
            }
            else
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "Mensaje", "alert('" + strMensaje.Replace("'","") + "');", true);
            }
           */
        }

    }
}