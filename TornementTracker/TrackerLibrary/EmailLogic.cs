﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Configuration;

namespace TrackerLibrary
{
    public class EmailLogic
    {
        public static void SendEmail(List<string> to, List<string> bcc, string subject, string body)
        {
            MailAddress fromMailAdress = new MailAddress(ConfigurationManager.AppSettings["SenderEmail"]);
            MailMessage mail = new MailMessage();
            foreach (string email in to)
            {
                mail.To.Add(email);
            }
            foreach (string email in bcc)
            {
                mail.Bcc.Add(email);
            }
            mail.From = fromMailAdress;
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true; 
            
            SmtpClient client = new SmtpClient();
            client.Send(mail);
        }
        public static void SendEmail(string to, string subject,string body)
        {
            SendEmail(new List<string> { to }, new List<string> { }, subject, body);
                
        }
        
    }
}
