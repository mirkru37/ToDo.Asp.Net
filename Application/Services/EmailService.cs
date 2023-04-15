using MailKit.Net.Smtp;
using MimeKit;

namespace Application.Services;

public class EmailService
{
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        var emailMessage = new MimeMessage();
 
        emailMessage.From.Add(new MailboxAddress("ToDo", "todo.lnu1@gmail.com"));
        emailMessage.To.Add(new MailboxAddress("", email));
        emailMessage.Subject = subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
        {
            Text = message
        };
             
        using (var client = new SmtpClient())
        {
            await client.ConnectAsync("smtp-relay.sendinblue.com", 587, false);
            await client.AuthenticateAsync("todo.lnu1@gmail.com", "5gVS7AcbjpQIYv4r");
            await client.SendAsync(emailMessage);
 
            await client.DisconnectAsync(true);
        }
    }
}