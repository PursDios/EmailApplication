using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Email_Application
{
    class SMTP
    {
        private static SMTP Instance;
        SmtpClient SmtpServer;

        private SMTP()
        {

        }

        public static SMTP getInstance()
        {
            if(Instance == null)
            {
                Instance = new SMTP();
            }
            return Instance;
        }

        public void SendMessage(string smtp, int port, string email, string password, string TargetEmail, string Subject, string Message)
        {
            SmtpServer = new SmtpClient(smtp);
            SmtpServer.Port = port;
            SmtpServer.Credentials = new NetworkCredential(email, password);

            try
            {
                MailMessage msg = new MailMessage();
                msg.To.Add(TargetEmail);
                msg.From = new MailAddress(email);
                msg.Subject = Subject;
                msg.Body = Message;

                SmtpServer.EnableSsl = true;

                SmtpServer.Send(msg);

            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "An Error has Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
