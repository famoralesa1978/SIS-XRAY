﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilidades;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace SIS_XRAY
{
    public partial class RecupararClave : System.Web.UI.Page
    {
		private RealAumentada.clsConectorSqlServer cn = new RealAumentada.clsConectorSqlServer();
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
                ds = cn.Listar(ConfigurationManager.AppSettings["ConnectionBD"], cmd);
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
        }

		protected void btnRefrescar_Click(object sender, EventArgs e)
		{
			UpdatePanel1.Update();
		}
	}
}