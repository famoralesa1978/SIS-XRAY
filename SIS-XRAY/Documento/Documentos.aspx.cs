using System;
using System.Collections.Generic;
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
			//clsConexion cn = new Conexion.clsConexion();
			//Clases.ClsUsuario clsUsu = new Clases.ClsUsuario();
			String strMensaje = "";
			Literal ltListaPersonal = new Literal();
			//SqlCommand cmd = new SqlCommand();
			//DataSet ds;
			//cmd.CommandText = "pa_ListarPersonalWEB '" + clsUsu.Rut + "'";
			//cmd.CommandType = CommandType.Text;
			//ds = cn.Listar(ConfigurationManager.AppSettings["ConnectionBD"], cmd, ref strMensaje);

			//if (strMensaje == "OK")
			//{
				//if (ds.Tables[0].Rows.Count > 0)
				//{
			
					ltListaPersonal.Text += "<optgroup label='Alaskan / Hawaiian Time Zone'><option value = 'AK'> Alaska </option><option value = 'HI' > Hawaii </option></optgroup> ";
					//ltListaPersonal.Text += "<i class='md md-close'></i></a></div></div><div class='offcanvas-body no-padding'><ul class='list '>";
					//for (int intFila = 0; intFila < ds.Tables[0].Rows.Count; intFila++)
					//{
					//	if (!ds.Tables[0].Rows[intFila]["Nombre"].ToString().ToUpper().Contains("REFERENCIA"))
					//		ltListaPersonal.Text = ltListaPersonal.Text + "<li class='tile'> " +
					//				"<a class='tile-content ink-reaction' href='#offcanvas-chat' data-toggle='offcanvas' data-backdrop='false'> " +
					//				"<div class='tile-icon'> " +
					//					"</div><div class='tile-text'>	" + ds.Tables[0].Rows[intFila]["Nombre"].ToString() + "	<small>" + ds.Tables[0].Rows[intFila]["Rut"].ToString() + "</small></div></a></li>";
					//}
					//ltListaPersonal.Text += "</ul></div><!--end .offcanvas-body -->	</div><!--end .offcanvas-pane -->";
				//}
		//	}
			return ltListaPersonal.Text;
		}
	}
}