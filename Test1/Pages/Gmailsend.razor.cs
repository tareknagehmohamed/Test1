using System.Net.Mail;
using System.Net;
namespace Test1.Pages
{
    public partial class Gmailsend
    {
        public string msgnew = "";
        public void send()
        {
          
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("wmam158@gmail.com", "tar01273444382");
            smtp.EnableSsl = true;
            MailMessage msg = new MailMessage();
            msg.Subject = "Hello Tarek  Thanks for Register at Hariti Study Hub";
            msg.Body = "Hi, Thanks For Your Registration at Hariti Study Hub, We will Provide You The Latest Update. Thanks";
            string toaddress = "wmam158@gmail.com";
            msg.To.Add(toaddress);
            string fromaddress = "Hariti Study Hub <wmam158@gmail.com>";
            msg.From = new MailAddress(fromaddress);
            try
            {
                smtp.Send(msg);
                msgnew = "Your Email Has Been Registered with Us";
           

            }
            catch
            {
              
                throw;
            }
        }
    }
}
