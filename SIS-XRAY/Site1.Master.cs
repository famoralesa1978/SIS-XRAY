using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIS_XRAY
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        Clases.ClsUsuario clsUsu = new Clases.ClsUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_Perfil.Text = clsUsu.Perfil;
            lbl_Nombre.Text = clsUsu.Nombre;
        }
    }
}