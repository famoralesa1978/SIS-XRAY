using Conexion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilidades;

namespace SIS_XRAY
{
	public partial class Formulario_web11 : System.Web.UI.Page
	{
		ClsDescriptarEncriptar encDesc = new ClsDescriptarEncriptar();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				GetListadoTipoDocumento();
				GetListadoAnno();
				GetListaDocumento();
			}
				
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

		public void GetListadoAnno()
		{
			clsConexion cn = new Conexion.clsConexion();
			Clases.ClsUsuario clsUsu = new Clases.ClsUsuario();
			String strMensaje = "";
			Literal ltAnno = new Literal();
			SqlCommand cmd = new SqlCommand();
			DataSet ds;
			cmd.CommandText = String.Format("pa_AnnoWEB '{0}',{1}", clsUsu.Rut, clsUsu.Id_Usuario);
			cmd.CommandType = CommandType.Text;
			ds = cn.Listar(System.Configuration.ConfigurationManager.AppSettings["ConnectionBD"], cmd, ref strMensaje);

			if (strMensaje == "OK")
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					ListItem lt;
					for (int intFila = 0; intFila < ds.Tables[0].Rows.Count; intFila++)
					{
						lt = new ListItem();

						lt.Value = ds.Tables[0].Rows[intFila]["Anno"].ToString();
						lt.Text = ds.Tables[0].Rows[intFila]["Anno"].ToString();
						ListAnnio.Items.Add(lt);
					}
				}
			}
		}
		public void GetListadoTipoDocumento()
		{
			clsConexion cn = new Conexion.clsConexion();
			Clases.ClsUsuario clsUsu = new Clases.ClsUsuario();
			String strMensaje = "";
			Literal ltAnno = new Literal();
			SqlCommand cmd = new SqlCommand();
			DataSet ds;
			cmd.CommandText = String.Format("pa_TipoDocumentoWEB");
			cmd.CommandType = CommandType.Text;
			ds = cn.Listar(System.Configuration.ConfigurationManager.AppSettings["ConnectionBD"], cmd, ref strMensaje);

			if (strMensaje == "OK")
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					ListItem lt;
					for (int intFila = 0; intFila < ds.Tables[0].Rows.Count; intFila++)
					{
						lt = new ListItem();
					
						lt.Value = ds.Tables[0].Rows[intFila]["id_tipo_doc"].ToString();
						lt.Text = ds.Tables[0].Rows[intFila]["detalle_tipo_documento"].ToString();
						ListTipoDocumento.Items.Add(lt);	}
				}
			}
		}

		private void GetListaDocumento()
		{
			clsConexion cn = new Conexion.clsConexion();
			Clases.ClsUsuario clsUsu = new Clases.ClsUsuario();
			String strMensaje = "";
			Literal ltAnno = new Literal();
			SqlCommand cmd = new SqlCommand();
			DataSet ds;
			cmd.CommandText = String.Format("pa_ListarDocumentoWEB '{0}',{1},{2},{3}", clsUsu.Rut, clsUsu.Id_Usuario, ListAnnio.Value, ListTipoDocumento.Value);
			cmd.CommandType = CommandType.Text;
			ds = cn.Listar(System.Configuration.ConfigurationManager.AppSettings["ConnectionBD"], cmd, ref strMensaje);

			if (strMensaje == "OK")
			{
				ltTabla.Text = "<table class='table table-striped no-margin'>";
				ltTabla.Text += "<thead><tr><th>#</th><th>Trimestre</th><th>Nombre</th><th>Descripción</th><th>Tipo documento</th><th>Descargar</th></tr></thead>";
				ltTabla.Text += "<tbody>";
				if (ds.Tables[0].Rows.Count > 0)
				{
					for (int intFila = 0; intFila < ds.Tables[0].Rows.Count; intFila++)
					{
						ltTabla.Text += String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td></tr>", 
																		(intFila+1),ds.Tables[0].Rows[intFila]["Mes"], ds.Tables[0].Rows[intFila]["Nombre"], ds.Tables[0].Rows[intFila]["Descripcion"], ds.Tables[0].Rows[intFila]["Tipo_Documento"],
																		"<a href='"+ Page.ResolveUrl("~/") + "Documento/Descarga.aspx?P=" + encDesc.GenerateHashMD5(ds.Tables[0].Rows[intFila]["Id_Doc"].ToString()) + "' target='_blank'><img src='"
																		+ Page.ResolveUrl("~/") + "Recursos/img/download24.png'/></a>");
					}
				}
				ltTabla.Text += "</tbody>";
				ltTabla.Text += "</table>";
			}
			
			
		}
		protected void btnBuscar_Click(object sender, EventArgs e)
		{
			GetListaDocumento();
		}
	}
}