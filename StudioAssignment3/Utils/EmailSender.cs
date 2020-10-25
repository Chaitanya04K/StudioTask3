using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net.Mail;
using System.Text;
using System.IO;

namespace StudioAssignment3.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("chaitanya.kanakia04@gmail.com", "FIT5032 Example Email User");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var bytes = File.ReadAllBytes("C:\\Users\\chait\\trial.txt");
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment("trial.txt", file);

            var response = client.SendEmailAsync(msg);
        }
    }
}