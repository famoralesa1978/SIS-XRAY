using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Drawing;
using System.Net.Mime;
using System.Text.RegularExpressions;
using Clases;


namespace Util
{
	public class clsUtiles
	{
		const string sKey = "compass";
		Clases.ClsEmail Email = new Clases.ClsEmail();

		#region "Contraseñas"

		//public string GenerarBase58(string input)
		//{
		//	byte[] cadena = Encoding.UTF8.GetBytes(input);
			
		//	string Codificado = Base58Check.Base58CheckEncoding.EncodePlain(cadena);

		//	return Codificado;
		//}
		//public string DecodifcarBase58(string input)
		//{
			
		//	byte[] cadena = Base58Check.Base58CheckEncoding.DecodePlain(input);
		//	string Codificado = Encoding.UTF8.GetString(cadena);

		//	return Codificado;
		//}

		public string GenerateHashMD5(string input)
		{
			TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
			MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
			//  Compute the MD5 hash.
			DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(sKey));
			//  Set the cipher mode.
			DES.Mode = CipherMode.ECB;
			//  Create the encryptor.
			ICryptoTransform DESEncrypt = DES.CreateEncryptor();
			//  Get a byte array of the string.
			byte[] Buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(input);
			//  Transform and return the string.
			return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
		}

		public string DecryptTripleDES(string sOut)
		{
			TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
			MD5CryptoServiceProvider hashMD5 = new MD5CryptoServiceProvider();
			//  Compute the MD5 hash.
			DES.Key = hashMD5.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(sKey));
			//  Set the cipher mode.
			DES.Mode = CipherMode.ECB;
			//  Create the decryptor.
			ICryptoTransform DESDecrypt = DES.CreateDecryptor();
			byte[] Buffer = Convert.FromBase64String(sOut);
			//  Transform and return the string.
			return System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
		}

		public Byte[] insertarPDF(string pdfnombre)
		{
			FileStream fs = new FileStream(pdfnombre, FileMode.Open, FileAccess.Read);
			BinaryReader br = new BinaryReader(fs);
			Byte[] bytes = br.ReadBytes((Int32)fs.Length);
			br.Close();
			fs.Close();
			return bytes;
		}

		public  byte[] Convertir_Binario(String Ruta_Archivo)
		{

			byte[] Convert = File.ReadAllBytes(Ruta_Archivo);

			return Convert;
		}

		#endregion

		#region Validador de Rut

		/// <summary>
		/// Metodo de validación de rut con digito verificador
		/// dentro de la cadena
		/// </summary>
		/// <param name="rut">string</param>
		/// <returns>booleano</returns>
		public bool ValidaRut(string rut)
		{
			rut = rut.Replace(".", "").ToUpper();
			Regex expresion = new Regex("^([0-9]+-[0-9K])$");
			string dv = rut.Substring(rut.Length - 1, 1);
			if (!expresion.IsMatch(rut))
			{
				return false;
			}
			char[] charCorte = { '-' };
			string[] rutTemp = rut.Split(charCorte);
			if (dv != Digito(int.Parse(rutTemp[0])))
			{
				return false;
			}
			return true;
		}


		/// <summary>
		/// Método que valida el rut con el digito verificador
		/// por separado
		/// </summary>
		/// <param name="rut">integer</param>
		/// <param name="dv">char</param>
		/// <returns>booleano</returns>
		public bool ValidaRut(string rut, string dv)
		{
			return ValidaRut(rut + "-" + dv);
		}

		/// <summary>
		/// método que calcula el digito verificador a partir
		/// de la mantisa del rut
		/// </summary>
		/// <param name="rut"></param>
		/// <returns></returns>
		public string Digito(int rut)
		{
			int suma = 0;
			int multiplicador = 1;
			while (rut != 0)
			{
				multiplicador++;
				if (multiplicador == 8)
					multiplicador = 2;
				suma += (rut % 10) * multiplicador;
				rut = rut / 10;
			}
			suma = 11 - (suma % 11);
			if (suma == 11)
			{
				return "0";
			}
			else if (suma == 10)
			{
				return "K";
			}
			else
			{
				return suma.ToString();
			}
		}

		#endregion

		#region "Enviar correo"
		public Boolean SendMailGmailRecuperarContrasena(string Run, string NombrePersona, string Asunto, string Correo, string Clave)
		{
			try
			{
				Email.CargarConfiguracion();
				MailMessage correos = new MailMessage();
				SmtpClient envios = new SmtpClient();
				correos.To.Clear();
				correos.Body = "";
				correos.Subject = Asunto;
				correos.IsBodyHtml = true;
				correos.To.Add(Correo);
				string strMensaje = String.Format("<div>" +
								"<div><span style = 'color: #000000;'><span style='font-family:tahoma,sans-serif;'>Estimado(a).&nbsp;</span><strong><span style='font-family: tahoma, sans-serif;'>&nbsp;</span></strong></span></div>" +
								" <div> &nbsp;</div> " +
								"<div><span style='color:#000000;'><span style='color:#000000;font-family: tahoma, sans-serif;'>Le reenviamos su usuario &nbsp; y su contrase&ntilde;a &nbsp; para ingresar al sistema al Link 'https://www.imagineandgive.cl/'.</span></span></div>" +
								"<div> &nbsp;</div>" +
								"<div><span style = 'color: #000000;' ><span style = 'font-family: tahoma, sans-serif;' > Usuario: {0}</span></span></div>" +
								"<div><span style = 'color: #000000;' ><span style = 'font-family: tahoma, sans-serif;' >contrase&ntilde;a: {1}</span></span></div> ", Run, DecryptTripleDES(Clave));
				string htmlBody = "<html><body>" + strMensaje +
						"<div>&nbsp;</div><div><div><div><strong><span style = 'color: #0b5394;'><span style = 'font-family: tahoma, sans-serif;'> &nbsp; &nbsp;</span></span></strong></div>" +
						"<div><span style = 'font-family: tahoma, sans-serif;'><span style = 'color: #0b5394;'><strong> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Administrador</strong> &nbsp;</span></span> &nbsp;</div>" +
						"</div></div><div><div> &nbsp; &nbsp;<span style = 'font-family: tahoma, sans-serif;'> &nbsp; &nbsp; &nbsp; https://www.imagineandgive.cl/.</span></div>" +
										"</body></html>";
				correos.Body = htmlBody;
				correos.From = new MailAddress(Email.Desde);
				envios.Credentials = new NetworkCredential(Email.Credencial, DecryptTripleDES(Email.Clave));

				//Datos importantes no modificables para tene¿¿r acceso a las cuentas

				envios.Host = Email.Host;
				envios.Port = Email.Port;
				envios.EnableSsl = true;

				envios.Send(correos);
				//MessageBox.Show("El mensaje fue enviado correctamente");
				return true;
			}
			catch (Exception ex)
			{
				//MessageBox.Show(ex.Message, "No se envio el correo correctamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}
		public Boolean SendMailContacto(string NombrePersona, string Asunto, string Correo, string htmlBody)
		{
			try
			{
				Email.CargarConfiguracion();
				MailMessage correos = new MailMessage();
				SmtpClient envios = new SmtpClient();
				correos.To.Clear();
				correos.Subject = Asunto;
				correos.IsBodyHtml = true;
				correos.To.Add(Email.Desde);
				correos.Body = htmlBody;
				correos.From = new MailAddress(Email.Desde);
				correos.CC.Add(Correo);
				envios.Credentials = new NetworkCredential(Email.Credencial, DecryptTripleDES(Email.Clave));

				//Datos importantes no modificables para tene¿¿r acceso a las cuentas

				envios.Host = Email.Host;
				envios.Port = Email.Port;
				envios.EnableSsl = true;

				envios.Send(correos);
				//MessageBox.Show("El mensaje fue enviado correctamente");
				return true;
			}
			catch (Exception ex)
			{
				//MessageBox.Show(ex.Message, "No se envio el correo correctamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}
		public Boolean SendMailPago(string NombrePersona, string Asunto, string Correo, string htmlBody)
		{
			try
			{
				Email.CargarConfiguracion();
				MailMessage correos = new MailMessage();
				SmtpClient envios = new SmtpClient();
				correos.To.Clear();
				correos.Subject = Asunto;
				correos.IsBodyHtml = true;
				correos.To.Add(Correo);
				correos.Body = htmlBody;
				correos.From = new MailAddress(Email.Desde);
				correos.CC.Add(Correo);
				envios.Credentials = new NetworkCredential(Email.Credencial, DecryptTripleDES(Email.Clave));

				//Datos importantes no modificables para tene¿¿r acceso a las cuentas

				envios.Host = Email.Host;
				envios.Port = Email.Port;
				envios.EnableSsl = true;

				envios.Send(correos);
				//MessageBox.Show("El mensaje fue enviado correctamente");
				return true;
			}
			catch (Exception ex)
			{
				//MessageBox.Show(ex.Message, "No se envio el correo correctamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}
		#endregion

		#region "ConvertToHTML"
		//public string ConvertToHTML1(RichTextBox Box)
		//{
		//    // Takes a RichTextBox control and returns a
		//    // simple HTML-formatted version of its contents
		//    string strHTML;
		//    string strColour;
		//    bool blnBold;
		//    bool blnItalic;
		//    string strFont;
		//    strFont = "";
		//    short shtSize;
		//    int lngOriginalStart;
		//    int lngOriginalLength;
		//    int intCount;
		//    strColour = "";
		//    blnBold = false;
		//    shtSize = 1;
		//    strHTML = "";
		//    // If nothing in the box, exit
		//    if (Box.Text.Length == 0) return strHTML;
		//    // Store original selections, then select first character
		//    lngOriginalStart = 0;
		//    lngOriginalLength = Box.TextLength;
		//    Box.Select(0, 1);
		//    // Add HTML header
		//    strHTML = "<html>";
		//    // Set up initial parameters
		//    //strColour = Box.SelectionColor.ToKnownColor.ToString();
		//    //blnBold = Box.SelectionFont.Bold;
		//    //blnItalic = Box.SelectionFont.Italic;
		//    //strFont = Box.SelectionFont.FontFamily.Name;
		//    //shtSize = Box.SelectionFont.Size;
		//    // Include first 'style' parameters in the HTML
		//    strHTML += "<span style=\"font-family: " + strFont + "; font-size: " + shtSize + "pt; color: " + strColour + "\">";
		//    // Include bold tag, if required
		//    if (blnBold == true)
		//    {
		//        strHTML += "<b>";
		//    }
		//    // Include italic tag, if required
		//    if (blnItalic == true)
		//    {
		//        strHTML += "<i>";
		//    }
		//    // Finally, add our first character
		//    strHTML += Box.Text.Substring(0, 1);
		//    // Loop around all remaining characters
		//    for (intCount = 2; intCount <= Box.Text.Length; intCount++)
		//    {
		//        // Select current character
		//        Box.Select(intCount - 1, 1);
		//        // If this is a line break, add HTML tag
		//        if (Convert.ToChar(Box.Text.Substring(intCount - 1, 1)) == Convert.ToChar(10))
		//        {
		//            strHTML += "<br>";
		//        }
		//        // Check/implement any changes in style
		//        if (Box.SelectionColor.ToKnownColor.ToString() != strColour | Box.SelectionFont.FontFamily.Name != strFont | Box.SelectionFont.Size != shtSize)
		//        {
		//            strHTML += "</span><span style=\"font-family: " + Box.SelectionFont.FontFamily.Name + "; font-size: " + Box.SelectionFont.Size + "pt; color: " + Box.SelectionColor.ToKnownColor.ToString() + "\">";
		//        }
		//        // Check for bold changes
		//        if (Box.SelectionFont.Bold != blnBold)
		//        {
		//            if (Box.SelectionFont.Bold == false)
		//            {
		//                strHTML += "</b>";
		//            }
		//            else
		//            {
		//                strHTML += "<b>";
		//            }
		//        }
		//        // Check for italic changes
		//        if (Box.SelectionFont.Italic != blnItalic)
		//        {
		//            if (Box.SelectionFont.Italic == false)
		//            {
		//                strHTML += "</i>";
		//            }
		//            else
		//            {
		//                strHTML += "<i>";
		//            }
		//        }
		//        // Add the actual character
		//        strHTML += Box.Text.Substring(intCount, 1);
		//       // strHTML += Mid(Box.Text, intCount, 1);
		//        // Update variables with current style
		//       // strColour = Box.SelectionColor.tostring();
		//        blnBold = false;// Box.SelectionFont;
		//        //blnItalic = Box.SelectionFont.Italic;
		//       // strFont = Box.SelectionFont.FontFamily.Name;
		//        //shtSize = Box.SelectionFont.Size;
		//    }
		//    // Close off any open bold/italic tags
		//    if (blnBold == true) strHTML += "";
		//    if (blnItalic == true) strHTML += "";
		//    // Terminate outstanding HTML tags
		//    strHTML += "</span></html>";
		//    // Restore original RichTextBox selection
		//    Box.Select(lngOriginalStart, lngOriginalLength);
		//    // Return HTML
		//    return strHTML;
		//}
		#endregion


	}
}
