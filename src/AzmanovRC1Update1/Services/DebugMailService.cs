using Azmanov.Services.Interfaces;
using System;
using System.Diagnostics;

namespace Azmanov.Services
{
    public class MailService : IMailService
    {
        public bool SendMail(string to, string from, string subject, string body)
        {
            //todo implement the service
            Debug.WriteLine($"Sending mail: To: {to}, Subject: {subject}");
            return true;
        }
    }
}
