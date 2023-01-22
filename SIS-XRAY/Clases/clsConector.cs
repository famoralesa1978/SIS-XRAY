using System;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using System.Data.Sql;
namespace RealAumentada
{

	public class clsConectorSqlServer
	{
		private SqlConnection conexion;

		//private SqlConnection conexion;

		private void Conectar(String strPublicacion)
		{
			Util.clsUtiles clsUtiles1 = new Util.clsUtiles();
			//    string bdProduccion = "Pn6QdbLxN6zYhNuC0AGO9QzP8WL2RI9VHfd/l56YcLkZ1UdzuJNuXq3s7y9ZY3eq6QrxfamnP0GH0FDdEHA6bAWJdHonailm8a5b3eyUw5vuWLyX+mBmFPxKLHFVjRtYm0sjwb1KdqM=";//original 
			//   string bdDesarrollo = "qbz4h7qjqnp0/OO4YgugGwzP8WL2RI9VHfd/l56YcLkZ1UdzuJNuXhBXIBpMWzG0Ksz6XiJssjyyoaDnAW6D6nLUIj/AB5EjQC5owho+mOlJ/DherMPWxLE4XBiaFShK";//original 

			string bd = strPublicacion; //strPublicacion == "Desarrollo" ? bdDesarrollo : strPublicacion == "Prod1" ? bdProduccion : "";

			//**********************
			conexion = new SqlConnection(clsUtiles1.DecryptTripleDES(bd));

			conexion.Open();

		}

		private void Cerrar()
		{

			conexion.Close();
		}

		public DataSet Listar(String strPublicacion, SqlCommand cmd)
		{
			Conectar(strPublicacion);
			DataSet dt = new DataSet();
			cmd.Connection = conexion;
			SqlDataAdapter reader = new SqlDataAdapter(cmd);
			reader.Fill(dt);
			Cerrar();
			return dt;
		}

    public string Agregar(String strPublicacion, SqlCommand cmd,string campo, ref string strMensajeError)
    {
      string strId = "";
      try
      {
        Conectar(strPublicacion);

        cmd.Connection = conexion;
        cmd.ExecuteNonQuery();
        return cmd.Parameters["@"+campo].Value.ToString();
      }
      catch (SqlException ex)
      {
        strMensajeError = ex.Message;
      
      }
      finally
      {

        Cerrar();
      }
      return strId;
    }

    public void Modificar(String strPublicacion, SqlCommand cmd, ref string strMensajeError)
    {
      try
      {
        Conectar(strPublicacion);

        cmd.Connection = conexion;
        cmd.ExecuteNonQuery();
      }
      catch (SqlException ex)
      {
        strMensajeError = ex.Message;

      }
      finally
      {

        Cerrar();
      }
    }

    public void AgregarModificarEliminar(String strPublicacion, SqlCommand cmd, ref string strMensajeError)
		{
			try
			{
				Conectar(strPublicacion);

				cmd.Connection = conexion;
				cmd.ExecuteNonQuery();
			}
			catch (SqlException ex)
			{
				strMensajeError = ex.Message;
			}
			finally
			{

				Cerrar();
			}

		}



	}
}
