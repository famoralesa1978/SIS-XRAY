﻿using System;
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
                switch (ds.Tables[0].Rows.Count)
                {
                    case 0://el usuario  o contraseña no existe
                        // System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "Mensaje", "alert('usuario y contraseña incorrecta');", true);
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
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