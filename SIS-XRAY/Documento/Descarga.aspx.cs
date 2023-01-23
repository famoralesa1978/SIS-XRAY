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
	public partial class Formulario_web12 : System.Web.UI.Page
	{
		ClsDescriptarEncriptar encDesc = new ClsDescriptarEncriptar();
		protected void Page_Load(object sender, EventArgs e)
		{
			string parametro = encDesc.DecryptTripleDES(Request.QueryString["P"]);
			RealAumentada.clsConectorSqlServer cn = new RealAumentada.clsConectorSqlServer();
		Clases.ClsUsuario clsUsu = new Clases.ClsUsuario();
			String strMensaje = "";
			Literal ltAnno = new Literal();
			SqlCommand cmd = new SqlCommand();
			DataSet ds;
			cmd.CommandText = String.Format("pa_CargarDocumentoWEB {0}", parametro);
			cmd.CommandType = CommandType.Text;
			ds = cn.Listar(System.Configuration.ConfigurationManager.AppSettings["ConnectionBD"], cmd);

			if (strMensaje == "OK")
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					String strExtension = ds.Tables[0].Rows[0]["Extension"].ToString();
					string strNombre = ds.Tables[0].Rows[0]["Nombre"].ToString()+ strExtension;
					byte[] varArchivo = (byte[])ds.Tables[0].Rows[0]["Archivo"];

					HttpContext.Current.Response.Clear();
					//HttpContext.Current.Response.ContentType = "application/vnd.ms-Excel";
					HttpContext.Current.Response.ContentType = "application/pdf";
					HttpContext.Current.Response.AddHeader("content-disposition", string.Concat("attachment; filename=", strNombre));
					HttpContext.Current.Response.AddHeader("Content-Length", varArchivo.Length.ToString());
					//Write the pdf file as a byte array to the page
					HttpContext.Current.Response.BinaryWrite(varArchivo);
					HttpContext.Current.Response.End();
				}
				//		Archivo,
				//Extension
			}
		}
	}
}