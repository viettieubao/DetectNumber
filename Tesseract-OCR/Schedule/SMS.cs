using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using log4net;
using Newtonsoft.Json;

namespace Tesseract_OCR.Schedule
{

    public class SMS
    {
        //string url = "http://voiceapi.esms.vn/MainService.svc/json/MakeCallTemplate_V2?";
        const string url= "http://voiceapi.esms.vn/MainService.svc/json/MakeCallTemplate_V2?ApiKey=DC37771F31FAE2127E57370F1969B8&SecretKey=67A9117735B8C4FEC78101A13AE0D8&TemplateId=484&Phone=";
        HttpWebRequest webRequest;
        //MailAddress fromAddress = new MailAddress("anhhungtieubao@gmail.com");
        MailAddress toAddresss = new MailAddress("quocvietuit1996@gmail.com"); //quochuy.mr@gmail.comhuyquoc.vn1@gmail.com
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Schedules).Name);

        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        public SMS()
        {
            
        }
        public void SendSMS(string content ,MailAddress sendMail, string pass, MailAddress receiveMail)
        {
            try {
                MailMessage mailMessage = new MailMessage(sendMail, receiveMail);
                mailMessage.Subject = "Thông báo";
                mailMessage.Body = content;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential(sendMail.Address, pass);
                smtp.Timeout = 30000;
                smtp.Send(mailMessage);
                
            } catch(Exception e)
            {
                _logger.Error(e.Message);
            }
            
        }

        public bool MakeCall(string phone)
        {
            if (webRequest != null)
                webRequest = null;
            else
                webRequest = (HttpWebRequest)WebRequest.Create(url + phone);
            HttpWebResponse myRes = (HttpWebResponse)webRequest.GetResponse();
            try
            {
                if (myRes.StatusDescription.ToString().ToUpper() == "OK")
                {
                    // Nhan cac dong tin tu server gui ve
                    Stream myStream = myRes.GetResponseStream();
                    StreamReader Reader = new StreamReader(myStream);
                    // Doc cac dong tin gui ve.
                    string result = Reader.ReadToEnd();
                    var obj = JsonConvert.DeserializeObject(result);
                    dynamic data = obj;
                    if (data.CodeResult == "103")
                    {
                        return false;
                    }
                }
                else
                    _logger.Info("Khong doc duoc");
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }
            return true;
        }
    }
}
