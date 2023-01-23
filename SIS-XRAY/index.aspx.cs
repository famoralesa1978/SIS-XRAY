using System;
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
	public partial class index : System.Web.UI.Page
	{
		private RealAumentada.clsConectorSqlServer cn = new RealAumentada.clsConectorSqlServer();
		ClsDescriptarEncriptar encDesc = new ClsDescriptarEncriptar();
		Clases.ClsUsuario clsUsu = new Clases.ClsUsuario();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				clsUsu.Id_perfil = 0;
				clsUsu.Id_Usuario = "";
				clsUsu.Nombre = "";
				clsUsu.Rut = "";
			}
		
		}

		protected void btnIngresar_Click(object sender, EventArgs e)
		{

			string usr;
			string psw;
			String strMensaje = "";
			bool valido;
			valido = true;

			usr = txtUsuario.Text.ToString();
			psw = txtPassword.Text.ToString();

			SqlCommand cmd = new SqlCommand();
			DataSet ds;
			cmd.CommandText = "pa_loginWeb_sel '" + usr + "','" + encDesc.GenerateHashMD5(psw) + "'";
			cmd.CommandType = CommandType.Text;
			ds = cn.Listar(ConfigurationManager.AppSettings["ConnectionBD"], cmd);

			if (ds !=null)
			{
				if (ds.Tables[0].Rows.Count > 0)
				{
					clsUsu.Usuario = usr;
					clsUsu.Id_perfil = Convert.ToInt16(ds.Tables[0].Rows[0]["Id_perfil"].ToString());
					clsUsu.Perfil = ds.Tables[0].Rows[0]["Descripcion"].ToString();
					clsUsu.Nombre = ds.Tables[0].Rows[0]["Razon_Social"].ToString();
					clsUsu.Rut = ds.Tables[0].Rows[0]["rut"].ToString();
					clsUsu.Id_Usuario = ds.Tables[0].Rows[0]["Id_cliente"].ToString(); //
					clsUsu.Email = ds.Tables[0].Rows[0]["Email"].ToString();                                                                // TransferirSegunPerfil(usr);
					Response.Redirect("Principal.aspx");
				}
				else
				{
					string javaScript = "Mensaje('El usuario no existe o contraseña incorrecta');";
					ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
				}
			}
			else
			{
				System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "Mensaje", "alert('Error en la conexion');", true);
			}

		}

	}
}