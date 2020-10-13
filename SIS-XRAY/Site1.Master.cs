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
				ltListaPersonal.Text = "<li class='tile'> " +
							"	<a class='tile-content ink-reaction' href='#offcanvas-chat' data-toggle='offcanvas' data-backdrop='false'> " +
							"		<div class='tile-icon'> "+
							"			<img src = '../../assets/img/avatar4.jpg?1404026791' alt='' />"+
								"	</div><div class='tile-text'>	Felipe morales		<small>123-123-3210</small></div></a></li>";
			}
		}
	}
}