using System;
using System.Collections.Generic;
using System.Text;

namespace PostMocking.Model
{
    public class EmailSender : IEmailSender
    {
        public bool Enviar(string Destinatario, string Mensaje)
        {
            return true;
        }
    }
}