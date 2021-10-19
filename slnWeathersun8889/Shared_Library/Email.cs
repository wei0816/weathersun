using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;


namespace Shared_Library
{
    public class Email_Cs
    {
        public enum SendType_En
        {
            LocalServer,
            Gmail,
            Both,
            Backup
        }
        private string LocalServer_UserName_F = String.Empty;
        private string LocalServer_Password_F = String.Empty;
        private string LocalServer_SmtpClient_F = String.Empty;
        private string LocalServer_SmtpClientPort_F = String.Empty;
        private string GmailServer_UserName_F = String.Empty;
        private string GmailServer_Password_F = String.Empty;
        private string GmailServer_SmtpClient_F = String.Empty;
        private string GmailServer_SmtpClientPort_F = String.Empty;
        private string ToEmail_F = String.Empty;
        private string ToEmailCC_F = String.Empty;
        private string ToEmailBCC_F = String.Empty;
        private string FormEmail_F = String.Empty;
        private string FormName_F = String.Empty;
        private string Subject_F = String.Empty;
        private string Body_F = String.Empty;
        private string Attachments_F = String.Empty;
        private SendType_En SendType_F;
        private int ReturnCode_F = 0;

        public string LocalServer_UserName_P
        {
            get { return LocalServer_UserName_F; }
            set { LocalServer_UserName_F = value; }
        }
        public string LocalServer_Password_P
        {
            get { return LocalServer_Password_F; }
            set { LocalServer_Password_F = value; }
        }
        public string LocalServer_SmtpClient_P
        {
            get { return LocalServer_SmtpClient_F; }
            set { LocalServer_SmtpClient_F = value; }
        }
        public string LocalServer_SmtpClientPort_P
        {
            get { return LocalServer_SmtpClientPort_F; }
            set { LocalServer_SmtpClientPort_F = value; }
        }
        public string GmailServer_UserName_P
        {
            get { return GmailServer_UserName_F; }
            set { GmailServer_UserName_F = value; }
        }
        public string GmailServer_Password_P
        {
            get { return GmailServer_Password_F; }
            set { GmailServer_Password_F = value; }
        }
        public string GmailServer_SmtpClient_P
        {
            get { return GmailServer_SmtpClient_F; }
            set { GmailServer_SmtpClient_F = value; }
        }
        public string GmailServer_SmtpClientPort_P
        {
            get { return GmailServer_SmtpClientPort_F; }
            set { GmailServer_SmtpClientPort_F = value; }
        }
        public string ToEmail_P
        {
            get { return ToEmail_F; }
            set { ToEmail_F = value; }
        }
        public string ToEmailCC_P
        {
            get { return ToEmailCC_F; }
            set { ToEmailCC_F = value; }
        }
        public string ToEmailBCC_P
        {
            get { return ToEmailBCC_F; }
            set { ToEmailBCC_F = value; }
        }
        public string FormEmail_P
        {
            get { return FormEmail_F; }
            set { FormEmail_F = value; }
        }
        public string FormName_P
        {
            get { return FormName_F; }
            set { FormName_F = value; }
        }
        public string Subject_P
        {
            get { return Subject_F; }
            set { Subject_F = value; }
        }
        public string Body_P
        {
            get { return Body_F; }
            set { Body_F = value; }
        }
        public string Attachments_P
        {
            get { return Attachments_F; }
            set { Attachments_F = value; }
        }
        public SendType_En SendType_P
        {
            get { return SendType_F; }
            set { SendType_F = value; }
        }
        public int ReturnCode_P
        {
            get { return ReturnCode_F; }
            set { ReturnCode_F = value; }
        }

        public void SendMail_Md()
        {
            bool boolResult = false;
            if (SendType_F.ToString() == "LocalServer")
            {
                boolResult = this.SmtpSendMail2_Md();
            }
            else if (SendType_F.ToString() == "Gmail")
            {
                boolResult = this.GmailSendMail_Md();
            }
            else if (SendType_F.ToString() == "Both")
            {
                boolResult = this.SmtpSendMail2_Md();
                boolResult = this.GmailSendMail_Md();
            }
            else if (SendType_F.ToString() == "Backup")
            {
                boolResult = this.GmailSendMail_Md();
            }
            else if (SendType_F.ToString() == "Gmail")
            {
                boolResult = this.SmtpSendMail2_Md();
                if (!boolResult)
                {
                    boolResult = this.GmailSendMail_Md();
                }
            }
            if (!boolResult)
                ReturnCode_F = 1;
            else
                ReturnCode_F = 0;
        }
            private bool SmtpSendMail_Md()
            {
            bool boolResult = false;

            try
            {
                MailMessage objMailMessage = new MailMessage();
                SmtpClient objSmtpClient = new SmtpClient(LocalSever_SmtpClient_F);

            }
            }
        }
    }
}
