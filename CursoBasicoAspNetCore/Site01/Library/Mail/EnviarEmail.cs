using Site01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Site01.Library.Mail
{
    public class EnviarEmail
    {

        public static void EnviarMensagemContato(Contato contato)
        {
            string conteudo = $"Nome:{contato.Nome}<br />E-mail:{contato.Email}<br />Assunto:{contato.Assunto}<br />Mensagem:{contato.Mensagem}";
            //Configuração SMTP
            SmtpClient smtp = new SmtpClient(Constants.ServidorSMTP, Constants.PortaSMTP);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(Constants.Usuario,Constants.Senha);
            //Mensagem Email
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("italo@primeempreendimentos.net.br");
            mensagem.To.Add("italo@primeempreendimentos.net.br");
            mensagem.Subject = "Formulário de contato";
            mensagem.IsBodyHtml = true;
            mensagem.Body = $"<h1>Contato</h1> {conteudo}";

            smtp.Send(mensagem);
        }

    }
}
