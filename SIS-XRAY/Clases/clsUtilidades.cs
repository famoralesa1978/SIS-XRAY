using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using Conexion;
using Utilidades;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Clases
{
    public class clsUtilidades
    {
		private RealAumentada.clsConectorSqlServer cn = new RealAumentada.clsConectorSqlServer();
		ClsEmail Email = new ClsEmail();
        ClsDescriptarEncriptar encDesc = new ClsDescriptarEncriptar();

        public Boolean SendMailGmailRecuperarContrasena(string Run, string NombrePersona, string Asunto, string Correo,   string Clave)
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
                string strMensaje = String.Format("<div>"+
                        "<div><span style = 'color: #000000;'><span style='font-family:tahoma,sans-serif;'>Estimado(a).&nbsp;</span><strong><span style='font-family: tahoma, sans-serif;'>&nbsp;</span></strong></span></div>" +
                        " <div> &nbsp;</div> " +
                        "<div><span style='color:#000000;'><span style='color:#000000;font-family: tahoma, sans-serif;'>Le reenviamos su usuario &nbsp; y su contrase&ntilde;a &nbsp; para ingresar al sistema al Link 'WWW.pagina.cl'.</span></span></div>" +
                        "<div> &nbsp;</div>" +
                        "<div><span style = 'color: #000000;' ><span style = 'font-family: tahoma, sans-serif;' > Usuario: {0}</span></span></div>" +
                        "<div><span style = 'color: #000000;' ><span style = 'font-family: tahoma, sans-serif;' >contrase&ntilde;a: {1}</span></span></div> ", Run, encDesc.DecryptTripleDES(Clave));
                string htmlBody = "<html><body>"+ strMensaje +
                    "<div>&nbsp;</div><div><div><div><strong><span style = 'color: #0b5394;'><span style = 'font-family: tahoma, sans-serif;'> &nbsp; &nbsp;</span></span></strong></div>" +
                    "<div><span style = 'font-family: tahoma, sans-serif;'><span style = 'color: #0b5394;'><strong> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Administraci&oacute;n</strong> &nbsp;</span></span> &nbsp;</div>" +
                    "</div></div><div><div> &nbsp; &nbsp;<span style = 'font-family: tahoma, sans-serif;'> &nbsp; &nbsp; &nbsp; X - Ray Protecci&oacute;n Radiol&oacute;gica Ltda.</span></div>" +
                    "<div><span style = 'font-family: tahoma, sans-serif;'> &nbsp; &nbsp; &nbsp;<span style = 'font-size: small;'> &nbsp; San Antonio 50 Of. 403, Santiago, Chile </span></span></div>" +
                    "<div><span style = 'font-family: tahoma, sans-serif; font-size: small;'> &nbsp; &nbsp; &nbsp; (56) - 2 - 26380724 / (56) - 2 - 26323485 &nbsp;</span></div></div> " +
                            "</body></html>";
                correos.Body = htmlBody;                
                correos.From = new MailAddress(Email.Desde);
                envios.Credentials = new NetworkCredential(Email.Credencial, encDesc.DecryptTripleDES(Email.Clave));

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
            ////Configuración del Mensaje
            //MailMessage mail = new MailMessage();
            //mail.IsBodyHtml = true;
            //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            ////Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
            //    mail.From = new MailAddress("pipecato2@gmail.com", "TuNombre", Encoding.UTF8);
            //    //Aquí ponemos el asunto del correo
            //    mail.Subject = "Prueba de Envío de Correo";
            //    //Aquí ponemos el mensaje que incluirá el correo

            //    string htmlBody = "<html><body><h3>" + texto + "</h3><br><img src=\"cid:firma\"></body></html>";
            //    AlternateView avHtml = AlternateView.CreateAlternateViewFromString
            //       (htmlBody, null, MediaTypeNames.Text.Html);
            //    LinkedResource inline = new LinkedResource("firma.jpg", MediaTypeNames.Image.Jpeg);
            //    inline.ContentId = "firma.jpg";
            //    avHtml.LinkedResources.Add(inline);


            //    htmlBody = htmlBody + String.Format(
            //            "<h3>Saluda atte:</h3>" +
            //           @"<img src=""cid:{0}"" />", inline.ContentId);

            //    mail.Body = htmlBody;
            //   // MailMessage mail = new MailMessage();
            //    mail.AlternateViews.Add(avHtml);

            //    Attachment att = new Attachment(@"D:\Sistema_Desarrollo\MARCELO_24032017\FUENTES\ControlDosimetro2_sqlserver_sqlcommand\ControlDosimetro\Imagen\firma.jpg");
            //    att.ContentDisposition.Inline = true;

            //   // mail.Attachments.Add(att);

            //   // mail.Body = texto;


            //    //Especificamos a quien enviaremos el Email, no es necesario que sea Gmail, puede ser cualquier otro proveedor
            //    mail.To.Add("pipecato2@hotmail.com");
            //    //Si queremos enviar archivos adjuntos tenemos que especificar la ruta en donde se encuentran
            //    mail.Attachments.Add(new Attachment(@"d:\\Documento\\compass.docx"));

            //    //Configuracion del SMTP
            //    SmtpServer.Port = 587; //Puerto que utiliza Gmail para sus servicios
            //    //Especificamos las credenciales con las que enviaremos el mail
            //    SmtpServer.Credentials = new System.Net.NetworkCredential("pipecato2@gmail.com", "beto1980");
            //    SmtpServer.EnableSsl = true;
            //    SmtpServer.Send(mail);
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    return false;
            //}
        }
    public Boolean SendMailDudasOConsulta(string Asunto, string Correo, string Mensaje)
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
        correos.To.Add(Email.Desde);
        Correo = "fmorales_arenas@hotmail.com";
        correos.CC.Add(Correo);
        string strMensaje = Mensaje;
        string htmlBody = Mensaje;
        correos.Body = htmlBody;
        correos.From = new MailAddress(Email.Desde);
        envios.Credentials = new NetworkCredential(Email.Credencial, encDesc.DecryptTripleDES(Email.Clave));

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

  }
}