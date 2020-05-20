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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string usr;
            string psw;
            String strMensaje="";
            bool valido;
            valido = true;

            usr = txtUsuario.Text.ToString();
            psw = txtPassword.Text.ToString();

          //  string Clave = clsUtiles1.GenerateHashMD5(txt_Contrasena.Text.Trim());
            //pa_login_sel 
            SqlCommand cmd = new SqlCommand();
            DataSet ds;
            cmd.CommandText = "pa_loginWeb_sel '" + usr + "','" + encDesc.GenerateHashMD5( psw) + "'";
            cmd.CommandType = CommandType.Text;
            string name = ConfigurationManager.AppSettings["ConnectionBD"];
            ds = cn.Listar(name, cmd,ref strMensaje);

            if (strMensaje == "OK")
            {
                if (valido == true)
                {
                    TransferirSegunPerfil(usr);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta", "Mensaje();", true);
                }
            }
            else
            {
             /*   System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(strMensaje);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());*/
                System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "Mensaje", "alert('" + strMensaje.Replace("'","") + "');", true);
            }
           
        }

        private void TransferirSegunPerfil(string usuario)
        {
            string Formulario;
            Formulario = "frmPrincipal.aspx";

            Response.Redirect(Formulario);
            Response.End();

            //validar usuario
            //if (dsUsuario.Tables[0].Rows.Count == 0)
            //{
            //    // - Usuario no esta registrado en el Sistema - 
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "alerta", "MensajeUsuarioNoExiste(1);", true);
            //}
            //else
            //{
            //    HttpContext context = HttpContext.Current;

            //    context.Session["Perfil"] = dsUsuario.Tables[0].Rows[0]["Perfil_Id"];
            //    context.Session["Nombre"] = dsUsuario.Tables[0].Rows[0]["Nombre"];
            //    context.Session["Usuario"] = dsUsuario.Tables[0].Rows[0]["Usuario"];
            //    context.Session["PeriodoActivo"] = dsUsuario.Tables[0].Rows[0]["periodoActivo"];

            //    string Formulario;
            //    Formulario = "frmPrincipal.aspx";

            //    Response.Redirect(Formulario);
            //    Response.End();
        }
    }
}