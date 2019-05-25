using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Email_Application
{
    class Provider
    {
        //The name of the provider (e.g. Google)
        private string m_Provider;
        //the SMTP server being used to try and send an email
        private string m_SMTP;
        //the predicted SMTP. This will be used if there isn't predetermined smtp information.
        private string m_PredictedSMTP;
        //the port the email will send on
        private int m_Port;
        //the extension to the email address (e.g. gmail.com)
        private string m_Extension;

        #region Properties
        /// <summary>
        /// The properties to obtain the provider information
        /// </summary>
        public string getProvider { get { return m_Provider; } }
        public string getSMTP { get { return m_SMTP; } }
        public int getPort { get { return m_Port; } }
        public string getExtension { get { return m_Extension; } }
        #endregion

        /// <summary>
        /// Creates a provider instance
        /// </summary>
        /// <param name="email">the email address of the user</param>
        public Provider(string email)
        {
            Identify(email);
        }

        /// <summary>
        /// Calls fuctions that will find out the provider inforamtion
        /// 
        /// This is its own method to allow for the sake of clarity
        /// </summary>
        /// <param name="email">the email address of the user</param>
        private void Identify(string email)
        {
            FindExtension(email);
            FindProvider();
        }

        /// <summary>
        /// Finds the extension information from the email address.
        /// 
        /// Calculates the predicted SMTP server.
        /// </summary>
        /// <param name="email">the users email address</param>
        private void FindExtension(string email)
        {
            string final = "";
            int charNum = 0;
            //an array of characters created from the email provided
            char[] characters = email.ToCharArray();

            //While the final string is empty.
            while (final == "")
            {
                //if the character at the charNum position is an @ symbol.
                if (characters[charNum] == '@')
                {
                    //remove everything before the @ symbol.
                    final = email.Remove(0, charNum);
                    //remove everything before the @ symbol and the @ symbol itself.
                    m_PredictedSMTP = email.Remove(0, charNum + 1);
                    //adds 'smtp.' in front of the predicted SMTP.
                    m_PredictedSMTP = "smtp." + m_PredictedSMTP;
                }
                //increments the charNum
                charNum++;
            }
            //sets the final string to be all lower case.
            final.ToLower();
            //sets the extension from the final string
            m_Extension = final;
        }
        /// <summary>
        /// Searches for the correct SMTP. if it cannot be found will use the predictedSMTP settings
        /// </summary>
        private void FindProvider()
        {
            //if the extension is empty, exit.
            if (m_Extension == null || m_Extension == "")
                return;

            //if the extension contains gmail
            if(m_Extension.Contains("gmail"))
            {
                m_Provider = "Google";
                m_SMTP = "smtp.gmail.com";
                m_Port = 587;
            }
            //if the extension contains outlook
            else if(m_Extension.Contains("outlook"))
            {
                m_Provider = "Microsoft";
                m_SMTP = "smtp.office365.com";
                m_Port = 587;
            }
            //if the extension isn't one of the previous results
            else
            {
                //sets the SMTP server being used to the predicted SMTP server.
                m_SMTP = m_PredictedSMTP;
                //warn the user it may not work properly.
                MessageBox.Show("Your email address is not recognised.\nThe program will attempt to use the following address: " + m_SMTP, "Unrecognised Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //sets the provider name to unrecognised
                m_Provider = "Unrecognised";
                //sets the port number being used.
                m_Port = 587;
            }
        }
    }
}
