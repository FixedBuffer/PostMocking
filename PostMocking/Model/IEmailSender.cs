namespace PostMocking.Model
{
    public interface IEmailSender
    {
        bool Enviar(string Destinatario, string Mensaje);
    }
}