using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIS_XRAY
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        Clases.ClsUsuario clsUsu = new Clases.ClsUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            int intID_perfil = clsUsu.Id_perfil;
        }
    }
}