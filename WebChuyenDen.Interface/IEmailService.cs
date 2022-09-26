namespace WebChuyenDen.Interface
{
    public interface IEmailService
    {
        bool Send(string toEmail, string subject, string body);
    }
}