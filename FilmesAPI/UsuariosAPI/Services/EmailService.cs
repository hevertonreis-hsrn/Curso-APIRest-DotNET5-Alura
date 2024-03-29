﻿using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class EmailService
    {
        private IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void EnviarEmail(
            string[] destinatario, 
            string assunto, 
            int usuarioId, 
            string code)
        {
            Mensagem mensagem = new Mensagem(
                destinatario,
                assunto,
                usuarioId, 
                code);
            var mensagemDeEmail = CriaCorpoDoEmail(mensagem);
            Enviar(mensagemDeEmail);
        }

        private void Enviar(MimeMessage mensagemDeEmail)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                 
                    client.Connect(
                        _configuration.GetValue<string>("EmailSettings:SmtpServer"),
                        _configuration.GetValue<int>("EmailSettings:Port"), SecureSocketOptions.StartTls
                        );
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(
                        _configuration.GetValue<string>("EmailSettings:Username"),
                        _configuration.GetValue<string>("EmailSettings:Password")
                        );
                    
                    client.Send(mensagemDeEmail);
                }
                catch (System.Exception)
                {

                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
            
        }
        private MimeMessage CriaCorpoDoEmail(Mensagem mensagem)
        {
            var mensagemDeEmail = new MimeMessage();
            mensagemDeEmail.From.Add(new MailboxAddress("Heverton",
                _configuration.GetValue<string>("EmailSettings:From")
                ));
            mensagemDeEmail.To.AddRange(mensagem.Destinatario);
            mensagemDeEmail.Subject = mensagem.Assunto;
            mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = mensagem.Conteudo
            };

            return mensagemDeEmail;
        }

    }
}
