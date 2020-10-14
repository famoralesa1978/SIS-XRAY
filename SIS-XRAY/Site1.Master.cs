using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Conexion;
using System.Configuration;

namespace SIS_XRAY
{
	public partial class Site1 : System.Web.UI.MasterPage
	{
		Clases.ClsUsuario clsUsu = new Clases.ClsUsuario();
		clsConexion cn = new Conexion.clsConexion();
		String strMensaje = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			lbl_Perfil.Text = clsUsu.Perfil;
			lbl_Nombre.Text = clsUsu.Nombre;

			ltListaPersonal.Text = "";

			SqlCommand cmd = new SqlCommand();
			DataSet ds;
			cmd.CommandText = "pa_ListarPersonal '" + clsUsu.Rut + "'";
			cmd.CommandType = CommandType.Text;
			ds = cn.Listar(ConfigurationManager.AppSettings["ConnectionBD"], cmd, ref strMensaje);

			if (strMensaje == "OK")
			{
				for (int intFila = 0; intFila < ds.Tables[0].Rows.Count; intFila++)
				{
					ltListaPersonal.Text = ltListaPersonal.Text + "<li class='tile'> " + 
							"	<a class='tile-content ink-reaction' href='#offcanvas-chat' data-toggle='offcanvas' data-backdrop='false'> " + 
							"		<div class='tile-icon'> " + 
								"	</div><div class='tile-text'>	" +  ds.Tables[0].Rows[intFila]["Nombre"].ToString() + "	<small>"+ ds.Tables[0].Rows[intFila]["Rut"].ToString() + "</small></div></a></li>";
				}
				
			}
		}
	}
}