using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Tesseract_OCR.Schedule
{

    public class SMS
    {
        MailAddress fromAddress = new MailAddress("anhhungtieubao@gmail.com");
        MailAddress toAddresss = new MailAddress("dangminhtuanhtt@gmail.com");

        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        public SMS()
        {

        }
        public void SendSMS(string content)
        {
            MailMessage mailMessage = new MailMessage(fromAddress, toAddresss);
            mailMessage.Subject = "Thông báo";
            mailMessage.Body = content;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(fromAddress.Address, "01656849355");
            smtp.Timeout = 30000;
            smtp.Send(mailMessage);
        }
    }
}
