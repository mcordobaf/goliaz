using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Security;
using Goliaz.Dto;
using Goliaz.Dao;

namespace Goliaz.Framework
{
    public class Correo
    {
        private string serverAddress = "";
        private string infoEmail = "";
        private string passEmail = "";
        private int portSendmail = 0;

        public Correo()
        {
            this.serverAddress = Properties.Settings.Default.serverAddress;
            this.infoEmail = Properties.Settings.Default.infoEmail;
            this.passEmail = Properties.Settings.Default.passEmail;
            this.portSendmail = Properties.Settings.Default.portSendmail;
        }

        
        public string GetRandomHexNumber(int digits)
        {
            Random random = new Random();
            byte[] buffer = new byte[digits / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            if (digits % 2 == 0)
                return result;
            return result + random.Next(16).ToString("X");
        }

        /// <summary>
        /// Method that allow send a message to confirm email
        /// </summary>
        /// <returns>true or false if was sent</returns>
        public bool SendConfirmEmailMessage(USERS userNew, out string mensajeError)
        {
            //Mensaje de correo
            bool sentMessage = false;
            mensajeError = "";
            try
            {
                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress(infoEmail);
                MailAddress para = new MailAddress(userNew.email);

                mensaje.To.Add(para);
                mensaje.Subject = "Goliaz Challenge, Please Confirm your Email.";
                string codigo = GetRandomHexNumber(10);

                userNew = UserDao.updateUser(userNew, codigo);
                if (!string.IsNullOrEmpty(userNew.codeConfirm))
                {
                    mensaje.IsBodyHtml = true;

                    string urlConfirm = "http://goliaz.com/confirmEmail.aspx?code=" + HttpUtility.UrlEncode(codigo) + "&em=" + userNew.email;


                    //mensaje.Body = "<html><head><title>Please Confirm Email</title></head><body style='font-size: 15px !important;font-family: Arial,sans-serif;'>Dear " + userNew.name + ", <br/><br/> Congratulations and welcome to Goliaz Challenge. Please click <a href='http://goliaz.com/confirmEmail.aspx?code=" + codigo + "&em=" + userNew.email + "' >here</a> to confirm your email address to finish the register process.<br/><br/>Regards,<br/>Goliaz Challenge Team. <br/><br/><img alt='goliaz.com' src='http://goliaz.com/images/image.jpg' /></body></html>";
                    mensaje.Body = "<html><head><title>Please Confirm Email</title></head><body style='font-size: 15px !important;font-family: Arial,sans-serif;'>Dear " + userNew.name + ", <br/><br/> Congratulations and welcome to the Goliaz Challenge!<br/><br/>Please click <a href='" + urlConfirm + "' >here</a> to confirm your email address and to finish the registration process.<br/><br/>Regards,<br/>Goliaz Challenge Team. <br/><br/><img alt='goliaz.com' src='http://goliaz.com/images/logomask2.png'  style='width:200px;' /></body></html>";
                    //mensaje.Body = "<html><head><title>Please Confirm Email</title></head><body>Dear " + userNew.name + ", <br/> Please go to http://goliaz.com/confirmEmail.aspx?code=" + codigo + "&em=" + userNew.email + " to confirm your email.<br/><br/>Regards,<br/>Goliaz Challenge Team.</body></html>";

                    //Configuracion cliente SMTP
                    SmtpClient cliente = new SmtpClient(serverAddress, portSendmail);
                    //cliente.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                    cliente.UseDefaultCredentials = false;
                    cliente.Credentials = new System.Net.NetworkCredential(infoEmail, passEmail);
                    //Send message
                    cliente.Send(mensaje);

                    sentMessage = true;
                }
            }
            catch (SmtpException ex)
            {
                //throw new Exception(ex.Message);

                mensajeError = ex.InnerException.Message;
            }
            return sentMessage;
        }
    }
}
