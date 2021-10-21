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
			int intID_perfil = clsUsu.Id_perfil;
			if (String.IsNullOrEmpty(clsUsu.Id_Usuario))
				Response.Redirect("~/index.aspx");

			HabiliarDesabilitarMenu(intID_perfil);
		}
		public static String GetListadoPersonal(HttpContext context)
		{
			clsConexion cn = new Conexion.clsConexion();
			Clases.ClsUsuario clsUsu = new Clases.ClsUsuario();
			String strMensaje = "";
			Literal ltListaPersonal= new Literal();
			SqlCommand cmd = new SqlCommand();
			DataSet ds;
			cmd.CommandText = "pa_ListarPersonalWEB '" + clsUsu.Rut + "'";
			cmd.CommandType = CommandType.Text;
			ds = cn.Listar(ConfigurationManager.AppSettings["ConnectionBD"], cmd, ref strMensaje);

			if (strMensaje == "OK")
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					ltListaPersonal.Text = "<div id='offcanvas-search' class='offcanvas-pane width-8'><div class='offcanvas-head'><header class='text-primary'>Personal (" + ds.Tables[0].Rows.Count.ToString() + ")</header>";
					ltListaPersonal.Text += "<div class='offcanvas-tools'><a class='btn btn-icon-toggle btn-default-light pull-right' data-dismiss='offcanvas'>";
					ltListaPersonal.Text += "<i class='md md-close'></i></a></div></div><div class='offcanvas-body no-padding'><ul class='list '>";
					for (int intFila = 0; intFila < ds.Tables[0].Rows.Count; intFila++)
					{
						if (!ds.Tables[0].Rows[intFila]["Nombre"].ToString().ToUpper().Contains("REFERENCIA"))
							ltListaPersonal.Text = ltListaPersonal.Text + "<li class='tile'> " +
									"<a class='tile-content ink-reaction' href='#offcanvas-chat' data-toggle='offcanvas' data-backdrop='false'> " +
									"<div class='tile-icon'> " +
										"</div><div class='tile-text'>	" + ds.Tables[0].Rows[intFila]["Nombre"].ToString() + "	<small>" + ds.Tables[0].Rows[intFila]["Rut"].ToString() + "</small></div></a></li>";
					}
					ltListaPersonal.Text += "</ul></div><!--end .offcanvas-body -->	</div><!--end .offcanvas-pane -->";
				}
			}
			return ltListaPersonal.Text;
		}
		public static String GetPersonalControlado(HttpContext context)
		{
			clsConexion cn = new Conexion.clsConexion();
			Clases.ClsUsuario clsUsu = new Clases.ClsUsuario();
			String strMensaje = "";
			Literal ltListaPersonal = new Literal();
			SqlCommand cmd = new SqlCommand();
			DataSet ds;
			cmd.CommandText = "pa_PersonalControloadoPorTriWEB '" + clsUsu.Rut + "'," + clsUsu.Id_Usuario.ToString();
			cmd.CommandType = CommandType.Text;
			ds = cn.Listar(ConfigurationManager.AppSettings["ConnectionBD"], cmd, ref strMensaje);

			if (strMensaje == "OK")
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					string[] arrCol = { "progress-bar-danger", "progress-bar-success", "progress-bar-warning", "progress-bar-danger" };
					ltListaPersonal.Text = "<ul class='header-nav header-nav-options'><li class='dropdown hidden-xs'><a href='javascript:void(0);' class='btn btn-icon-toggle btn-default' data-toggle='dropdown'>";
					ltListaPersonal.Text += "<i class='fa fa-area-chart'></i></a><ul class='dropdown-menu animation-expand'><li class='dropdown-header'><FONT SIZE=4>Personal controlado<br>por trimestre</FONT></li>";
					//ltListaPersonal.Text += "<i class='md md-close'></i></a></div></div><div class='offcanvas-body no-padding'><ul class='list '>";
					for (int intFila = 0; intFila < ds.Tables[0].Rows.Count; intFila++)
					{//Anno,Mes
						int intCantidad = (int)ds.Tables[0].Rows[intFila]["Pelicula"];
						int intRefenrecia = (int)ds.Tables[0].Rows[intFila]["Referencia"];
						int intAnno = (int)ds.Tables[0].Rows[intFila]["Anno"];
						int intMes = ((int)ds.Tables[0].Rows[intFila]["Mes"] /3);
						decimal decporcentaje = (intCantidad * 100) / (intCantidad+intRefenrecia);
						ltListaPersonal.Text = ltListaPersonal.Text + String.Format("<li class='dropdown-progress'><a href='javascript:void(0);'><div class='dropdown-label'><span class='text-light'>{0}</span>" +
										"<strong class='pull-right'>{1}%</strong></div><div class='progress'><div class='progress-bar {2}' style='width: 100%'></div></div></a></li><!--end .dropdown-progress -->",
										intAnno.ToString() + " " + intMes.ToString() + " semestre pel: " + intCantidad.ToString() + ", ref: " + intRefenrecia.ToString(), decporcentaje, arrCol[intFila]);
					}
					ltListaPersonal.Text += "</ul><!--end .dropdown-menu --></li><!--end .dropdown --></ul><!--end .header-nav-options -->";
				}
			}
			

			return ltListaPersonal.Text;
		}
		private void HabiliarDesabilitarMenu(int intPerfil)
		{
			//SqlCommand cmd = new SqlCommand();
			//DataSet ds;
			//cmd.CommandText = "pa_WEBMenuPrivilegio_sel " + intPerfil.ToString();
			//cmd.CommandType = CommandType.Text;
			//ds = cn.Listar(ConfigurationManager.AppSettings["ConnectionBD"], cmd, ref strMensaje);


			//if (strMensaje == "OK")
			//{
				ltMenu.Text = String.Format("<div id='menubar' class='menubar-inverse '>" +
				"<div class='menubar-fixed-panel'>" +
					"<div>" +
						"<a class='btn btn-icon-toggle btn-default menubar-toggle' data-toggle='menubar' href='javascript:void(0);'>" +
							"<i class='fa fa-bars'></i>" +
						"</a>" +
					"</div>" +
					"<div class='expanded'>" +
						"<a href = '{0}Principal.aspx' > " +
							"<span class='text-lg text-bold text-primary '>Xray</span>" +
						"</a>" +
					"</div>" +
				"</div>" +
				"<div class='menubar-scroll-panel'>" +
				"<!--BEGIN MAIN MENU -->" +
					"<ul id = 'main-menu' class='gui-controls'>" +
					"<!--BEGIN DASHBOARD-->" +
						"<li>" +
							"<a href = '{0}Principal.aspx' >" +
								 "<div class='gui-icon'><i class='md md-home'></i></div>" +
								"<span class='title'>Menu</span>" +
							"</a>" +
						"</li><!--end /menu-li -->" +
						"<!-- END DASHBOARD -->" +
						"<!--BEGIN EMAIL-->" +
						"<li class='gui-folder'>" +
							"<a>" +
								"<div class='gui-icon'><i class='md md-email'></i></div>" +
								"<span class='title'>Email</span>" +
							"</a>" +
							"<!--start submenu -->" +
							"<ul>" +
								"<li><a href = '{0}Contacto/Contacto.aspx' class='active'><span class='title'>Contacto</span></a></li>" +
								"<li><a href = '{0}Contacto/EnviarConsulta.aspx' ><span class='title'>consulta</span></a></li>" +
							"</ul><!--end /submenu -->" +
						"</li><!--end /menu-li --> " +
						"<!-- END EMAIL -->" +
					"</ul ><!--end.main - menu-->" +
					"<!--END MAIN MENU -->" +
				"</div ><!--end.menubar - scroll - panel-->" +
			"</div ><!--end #menubar-->" +
			"<!--END MENUBAR-->", Page.ResolveUrl("~/"));



			//	ltMenu.Text = "<ul id = 'main-menu' class='gui-controls'>" +
			//"	<!--BEGIN DASHBOARD-->";
			////"	<li> <a href = 'Principal.aspx'>" +
			////"<div class='gui-icon'><i class='md md-home'></i></div>" +
			////"<span class='title'>Home</span>" +
			////"</a></li><!--end /menu-li -->"; 

		//	if (ds.Tables[0].Rows.Count > 0)
		//	{
		//		for (int intFila = 0; intFila <= ds.Tables[0].Rows.Count - 1; intFila++)
		//		{
		//			ltMenu.Text += "<li " + ds.Tables[0].Rows[intFila]["Li"].ToString() + ">";
		//			string strPagina= Page.ResolveUrl("~/" + ds.Tables[0].Rows[intFila]["Pagina"].ToString());
		//			ltMenu.Text += ds.Tables[0].Rows[intFila]["Xml"].ToString().Replace("Pagina", strPagina);

		//			Cargar_Submenu(ds.Tables[1], Convert.ToInt16(ds.Tables[0].Rows[intFila]["Id_menuWeb"].ToString()));

		//			ltMenu.Text += "</li>";
		//		}

		//	}


		//	ltMenu.Text += "</ul><!--end.main - menu-->" +
		//"	<!--END MAIN MENU -->";
	//}
	//		else
	//		{
	//			System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "Mensaje", "alert('" + strMensaje.Replace("'", "") + "');", true);
	//		}
		}
		private void Cargar_Submenu(DataTable dt, int intTag)
		{
			DataView dv = new DataView(dt);
			dv.RowFilter = "Id_menu_Padre=" + intTag.ToString();
			dv.Sort = "Orden";

			if (dv.Count > 0)
			{
				ltMenu.Text += "<ul>";
				foreach (DataRowView drv in dv)
				{
					ltMenu.Text += "<li " + drv["Li"].ToString() + ">";
					string strPagina = Page.ResolveUrl("~/" + drv["Pagina"].ToString());
					ltMenu.Text += drv["Xml"].ToString().Replace("Pagina", strPagina);

					//		Cargar_Submenu(ds.Tables[1], Convert.ToInt16(ds.Tables[0].Rows[intFila]["Id_menuWeb"].ToString()));

					ltMenu.Text += "</li>";


				}
				ltMenu.Text += "</ul>";
			}
		}


	}
}