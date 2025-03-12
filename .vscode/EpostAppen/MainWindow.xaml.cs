using System;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows;
using MailKit.Net.Smtp;
using MimeKit;

namespace MeddelandeApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Hantera klick på knappen Skicka
        private async void KlickSkicka(object sender, RoutedEventArgs e)
        {
            // Läs av inmatningen
            string epost = tbxEpost.Text;
            string password = tbxPassword.Password; // Läs lösenord från PasswordBox
            string text = tbxText.Text;

            // Kontrollera att användaren har skrivit in en epostadress
            string regexEpost = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            if (!Regex.IsMatch(epost, regexEpost))
            {
                // Visa felmeddelande
                lblStatus.Content = "Du måste ange en giltig epostadress!";
            }
            else
            {
                try
                {
                    // Skapa ett MimeMessage-objekt
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress(epost));  // Avsändare
                    message.To.Add(new MailboxAddress(epost));    // Mottagare
                    message.Subject = "Meddelande från WPF";
                    message.Body = new TextPart("plain") { Text = text };

                    // Anslut till SMTP-servern och skicka meddelandet
                    using (var smtp = new SmtpClient())
                    {
                        await smtp.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                        await smtp.AuthenticateAsync(epost, password);  // Logga in
                        await smtp.SendAsync(message);  // Skicka meddelandet
                        await smtp.DisconnectAsync(true);  // Koppla från
                    }

                    // Visa att meddelandet skickades
                    lblStatus.Content = "Meddelandet skickades!";
                }
                catch (Exception ex)
                {
                    // Visa felmeddelande om det uppstår ett fel
                    lblStatus.Content = "Fel: " + ex.Message;
                }
            }
        }
    }
}
