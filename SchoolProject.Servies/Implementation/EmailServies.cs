﻿using MailKit.Net.Smtp;
using MimeKit;
using SchoolProject.Data.Helpers;
using SchoolProject.Servies.Abstructs;

namespace SchoolProject.Servies.Implementation
{
    public class EmailServies : IEmailServies
    {
        #region Fields
        private readonly EmailSettings _emailSettings;
        #endregion

        #region Constructors
        public EmailServies(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }

        #endregion

        #region Handle Functions
        public async Task<string> SendEmailAsync(string email, string massage, string? reason)
        {
            try
            {
                //sending the Message of passwordResetLink
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, true);
                    client.Authenticate(_emailSettings.FromEmail, _emailSettings.Password);
                    var bodybuilder = new BodyBuilder
                    {
                        HtmlBody = $"{massage}",
                        TextBody = "welcome",
                    };
                    var message = new MimeMessage
                    {
                        Body = bodybuilder.ToMessageBody()
                    };
                    message.From.Add(new MailboxAddress("School Support", _emailSettings.FromEmail));
                    message.To.Add(new MailboxAddress("testing", email));
                    message.Subject = reason == null ? "No reason summited" : reason;
                    await client.SendAsync(message);

                    await client.DisconnectAsync(true);
                }
                //end of sending email
                return "Success";
            }
            catch (Exception ex)
            {
                return "Failed";
            }
        }
        #endregion
    }
}
