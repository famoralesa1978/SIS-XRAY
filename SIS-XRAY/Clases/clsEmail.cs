using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexion;
using Utilidades;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Clases
{
    class ClsEmail//prueba
    {
		private RealAumentada.clsConectorSqlServer cn = new RealAumentada.clsConectorSqlServer();
		ClsDescriptarEncriptar encDesc = new ClsDescriptarEncriptar();
        private static string strDesde;
        private static string strCredencial;
        private static string strClave;
        private static string strHost;
        private static int strPort;

        public int Port
        {
            get
            {
                return strPort;
            }
            set
            {
                strPort = value;  // value is an implicit parameter
            }

        }
        public string Host
        {
            get
            {
                return strHost;
            }
            set
            {
                strHost = value;  // value is an implicit parameter
            }

        }
        public string Clave
        {
            get
            {
                return strClave;
            }
            set
            {
                strClave = value;  // value is an implicit parameter
            }

        }
        public string Desde
        {
            get
            {
                return strDesde;
            }
            set
            {
                strDesde = value;  // value is an implicit parameter
            }

        }

        public string Credencial
        {
            get
            {
                return strCredencial;
            }
            set
            {
                strCredencial = value;  // value is an implicit parameter
            }

        }

        public void CargarConfiguracion()
        {
            string strMensaje="";
            SqlCommand cmd = new SqlCommand();
            DataSet ds;
            cmd.CommandText = "pa_ConfCorreo_sel";
            cmd.CommandType = CommandType.Text;
            ds = cn.Listar(ConfigurationManager.AppSettings["ConnectionBD"], cmd);

            if(ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    strDesde = ds.Tables[0].Rows[0]["Desde"].ToString();
                    strCredencial = ds.Tables[0].Rows[0]["Credencial"].ToString();
                    strClave = ds.Tables[0].Rows[0]["Clave"].ToString();
                    strHost = ds.Tables[0].Rows[0]["Host"].ToString();
                    strPort = Convert.ToInt16( ds.Tables[0].Rows[0]["Port"]);
                }
            }
        }

    }
}
