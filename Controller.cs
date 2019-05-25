using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Email_Application
{
    //guineapigemail1@gmail.com, sdfasdfasfsdfs@outlook.com (Requires validation and will not work until phone number is assigned.)
    //loikoloiko1
    class Controller
    {
        //Instance of the Controller used to follow the Singleton design methodology
        private static Controller Instance;
        //email address the user typed in
        private string m_Email;
        //password the user typed in
        private string m_Password;
        //The provider information
        private Provider m_Provider;

        private Controller()
        {

        }
        /// <summary>
        /// Returns an instance of the Controller
        /// </summary>
        /// <returns>Returns the instance of the Controller</returns>
        public static Controller getInstance()
        {
            if(Instance == null)
            {
                Instance = new Controller();
            }
            return Instance;
        }
        /// <summary>
        /// Retrieves the provider information from the provided email address and displays the send email form
        /// 
        /// NOTE: this does not validate login information.
        /// </summary>
        /// <param name="loginform">The Login form instance</param>
        /// <param name="Email">The users email address</param>
        /// <param name="password">The users password</param>
        public void Initalise(Form loginform, string Email, string password)
        {
            m_Email = Email;
            m_Password = password;

            m_Provider = new Provider(m_Email);
            MessageBox.Show("Email: " + m_Email + 
                "\nProvider: " + m_Provider.getProvider + 
                "\nExtension: " + m_Provider.getExtension + 
                "\nPort: " + m_Provider.getPort);
            SendEmail se = new SendEmail();
            loginform.Hide();
            se.ShowDialog();
        }
        /// <summary>
        /// Sends an email
        /// </summary>
        /// <param name="Destination">The destination email</param>
        /// <param name="Subject">The subject of the message</param>
        /// <param name="Body">The body of the message</param>
        public void SendEmail(string Destination, string Subject, string Body)
        {
            SMTP.getInstance().SendMessage(m_Provider.getSMTP, m_Provider.getPort, m_Email, m_Password, Destination, Subject, Body);
            MessageBox.Show("Your Email has successfully been sent", "Email Sent");
        }
    }
}
