﻿using Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIS_XRAY
{
	public partial class Formulario_web11 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			
		}
		public static String GetListadoAnno(HttpContext context)
		{
			clsConexion cn = new Conexion.clsConexion();
			Clases.ClsUsuario clsUsu = new Clases.ClsUsuario();
			String strMensaje = "";
			Literal ltAnno = new Literal();
			SqlCommand cmd = new SqlCommand();
			DataSet ds;
			cmd.CommandText =String.Format("pa_AnnoWEB '{0}',{1}", clsUsu.Rut,clsUsu.Id_Usuario);
			cmd.CommandType = CommandType.Text;
			ds = cn.Listar(System.Configuration.ConfigurationManager.AppSettings["ConnectionBD"], cmd, ref strMensaje);

			if (strMensaje == "OK")
			{
				if (ds.Tables[0].Rows.Count > 0)
				{

					ltAnno.Text += "<optgroup label='Año'> ";
					for (int intFila = 0; intFila < ds.Tables[0].Rows.Count; intFila++)
					{
						ltAnno.Text += String.Format("<option value = '{0}'>{0}</option>",ds.Tables[0].Rows[intFila]["Anno"].ToString());
					}
					ltAnno.Text += "</optgroup> ";
				}
			}
			return ltAnno.Text;
		}
	}
}