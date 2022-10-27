namespace OpenVMS.Plugins.AirMail;

public class AirMail
{
    public string Sender;
    public string[] Receiver;
    public string Date;
    public string Subject;
    public string Content;

    public AirMail(string sender, string[] receiver, string subject, string content)
    {
        Sender = sender;
        Receiver = receiver;
        Subject = subject;
        Content = content;
        Date = DateTime.UtcNow.ToString();
    }
}