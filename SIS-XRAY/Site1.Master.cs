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

			int intID_perfil = clsUsu.Id_perfil;
			//String strMensaje = "";

			//SqlCommand cmd = new SqlCommand();
			//DataSet ds;
			//cmd.CommandText = "pa_WEBMenuPrivilegio_sel " + intID_perfil.ToString();
			//cmd.CommandType = CommandType.Text;
			//ds = cn.Listar(ConfigurationManager.AppSettings["ConnectionBD"], cmd, ref strMensaje);

			//if (strMensaje == "OK")
			//{

			//}
			//else
			//{
			//System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "Mensaje", "alert('" + strMensaje.Replace("'", "") + "');", true);
			//}

			HabiliarDesabilitarMenu(intID_perfil);
		}

		private void HabiliarDesabilitarMenu(int intPerfil)
		{
			SqlCommand cmd = new SqlCommand();
			DataSet ds;
			cmd.CommandText = "pa_WEBMenuPrivilegio_sel " + intPerfil.ToString();
			cmd.CommandType = CommandType.Text;
			ds = cn.Listar(ConfigurationManager.AppSettings["ConnectionBD"], cmd, ref strMensaje);


			if (strMensaje == "OK")
			{
				ltMenu.Text = "<ul id = 'main-menu' class='gui-controls'>" +
			"	<!--BEGIN DASHBOARD-->";
			//"	<li> <a href = 'Principal.aspx'>" +
			//"<div class='gui-icon'><i class='md md-home'></i></div>" +
			//"<span class='title'>Home</span>" +
			//"</a></li><!--end /menu-li -->"; 

				if (ds.Tables[0].Rows.Count > 0)
				{
					for (int intFila = 0; intFila <= ds.Tables[0].Rows.Count - 1; intFila++)
					{
						ltMenu.Text += "<li " + ds.Tables[0].Rows[intFila]["Li"].ToString() + ">";
						ltMenu.Text += ds.Tables[0].Rows[intFila]["Xml"].ToString();

						Cargar_Submenu(ds.Tables[1], Convert.ToInt16(ds.Tables[0].Rows[intFila]["Id_menuWeb"].ToString()));

						ltMenu.Text += "</li>";
					}

				}


				ltMenu.Text += "</ul><!--end.main - menu-->" +
			"	<!--END MAIN MENU -->";
			}
			else
			{
				System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "Mensaje", "alert('" + strMensaje.Replace("'", "") + "');", true);
			}

			//if (ds == null)
			//	menuStrip.Visible = false;
			//else
			//{
			//	//menuStrip.Items.Clear();
			//	menuStrip.Visible = ds.Tables[0].Rows.Count == 0 ? false : true;
			//	if (ds.Tables[0].Rows.Count > 0)
			//	{

			//		for (int intFila = 0; intFila <= ds.Tables[0].Rows.Count - 1; intFila++)
			//		{
			//			tsiMenu = new ToolStripMenuItem();
			//			tsiMenu.Text = ds.Tables[0].Rows[intFila]["Menu"].ToString();
			//			tsiMenu.Name = ds.Tables[0].Rows[intFila]["nameMenu"].ToString();
			//			tsiMenu.Tag = ds.Tables[0].Rows[intFila]["Id_Menu"].ToString();


			//			if ((bool)ds.Tables[0].Rows[intFila]["EventoClick"] == true)
			//				tsiMenu.Click += new EventHandler(this.Cargamenu_Click);
			//		//	else
			//		//		Cargar_Submenu(ref tsiMenu, ds.Tables[1], Convert.ToInt16(ds.Tables[0].Rows[intFila]["Id_Menu"].ToString()));
			//		//	menuStrip.Items.Add(tsiMenu);
			//		}
			//	}
			//}
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
					ltMenu.Text += drv["Xml"].ToString();

					//		Cargar_Submenu(ds.Tables[1], Convert.ToInt16(ds.Tables[0].Rows[intFila]["Id_menuWeb"].ToString()));

					ltMenu.Text += "</li>";



					//	if (drv["Menu"].ToString() == "Separador")
					//	{
					//		tsiSeparador = new ToolStripSeparator();
					//		tsiMenu.DropDownItems.Add(tsiSeparador);
					//	}
					//	else
					//	{
					//		tsiSubMenu = new ToolStripMenuItem();
					//		tsiSubMenu.Text = drv["Menu"].ToString();
					//		tsiSubMenu.Name = drv["nameMenu"].ToString();
					//		tsiSubMenu.Tag = drv["Id_Menu"].ToString();


					//		if ((bool)drv["EventoClick"] == true)
					//			tsiSubMenu.Click += new EventHandler(this.Cargamenu_Click);
					//		Cargar_Submenu(ref tsiSubMenu, dt, Convert.ToInt16(tsiSubMenu.Tag));
					//		tsiMenu.DropDownItems.Add(tsiSubMenu);


					//	}

				}
				ltMenu.Text += "</ul>";
			}
		}


	}
}