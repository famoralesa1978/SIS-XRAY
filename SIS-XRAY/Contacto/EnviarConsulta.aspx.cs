using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIS_XRAY.Contacto
{
	public partial class EnviarConsulta : System.Web.UI.Page
	{
		Clases.clsUtilidades clsutil = new Clases.clsUtilidades();
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void btnEnviar_Click(object sender, EventArgs e)
		{
			Clases.ClsUsuario clsUsu = new Clases.ClsUsuario();
			clsutil.SendMailDudasOConsulta(Subject1.Value, clsUsu.Email, message.Value);
		}
	}
}