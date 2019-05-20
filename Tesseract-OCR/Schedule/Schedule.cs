using System;
using System.Drawing;
using Tesseract;
using log4net;
using System.Net;
using System.Net.Mail;

namespace Tesseract_OCR.Schedule
{
    public class Schedules
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Schedules).Name);
        public Detection TextDetection { get; set; }
        public SMS sMS { get; set; }
        public CapView capView { get; set; }

        public string nowText { get; set; }
        public string nowScore { get; set; }
        public int preResult { get; set; }
        public int charCount { get; set; }
        public int scoreCondition { get; set; }
        public int smsCondition { get; set; }
        public int callCondition { get; set; }
        public int sumScores { get; set; }
        public int count { get; set; }
        public int notify { get; set; }

        public string sendMail { get; set; }
        public string mailPass { get; set; }
        public string receiveMail { get; set; }
        public string apiKey { get; set; }
        public string secretKey { get; set; }
        public string phone { get; set; }

        public int isrunning =0;
        public Schedules()
        {
            capView = new CapView();
            sMS = new SMS();
            TextDetection = new Detection("./tessdata");
            this.preResult = 0;
            this.count = 0;
        }
        public int Run()
        {
            try
            {
                isrunning++;
                if(isrunning >= notify)
                {
                    sMS.SendSMS("Hiện không có trận đấu nào diễn ra ",
                                                                        new MailAddress(sendMail),
                                                                        mailPass,
                                                                        new MailAddress(receiveMail));
                    _logger.Info("Hiện không có trận đấu nào diễn ra" + DateTime.Now.ToString()); 
                    isrunning = 0;
                }
                Bitmap textBitmap = capView.GetRectangleTextBitmap();
                convertToBlackAndWhite(textBitmap);
                string result = TextDetection.Detect(textBitmap);
                result = result.Replace("\n", String.Empty);
                result = System.Text.RegularExpressions.Regex.Replace(result, " ", "");
                this.nowText = result;
                if (preResult == 0 && this.charCount == result.Length)
                {
                    Bitmap scoreBitmap = capView.GetRectangleMatchBitmap();
                    convertToBlackAndWhite(scoreBitmap);
                    using (var scoreDetection = new TesseractEngine(@"./tessdata", "eng", EngineMode.TesseractAndCube))
                    {

                        preResult = 1;

                        string score = scoreDetection.Process(scoreBitmap).GetText();

                        //replace kí tự hay bị lỗi 
                        score = score.Replace("\n", String.Empty);
                        score = System.Text.RegularExpressions.Regex.Replace(score, " ", "");
                        score = System.Text.RegularExpressions.Regex.Replace(score, "o", "0");
                        score = System.Text.RegularExpressions.Regex.Replace(score, "l", "1");

                        this.nowScore = score;
                        string[] array = score.Split('-');
                        if (array.Length == 2)
                        {
                            isrunning = 0;
                            int sumScore = int.Parse(array[0]) + int.Parse(array[1]);
                            this.sumScores = sumScore;

                            if (sumScore > scoreCondition)
                            {
                                count++;
                                if (count >= smsCondition)
                                {
                                    sMS.SendSMS("Thông báo đủ số lượng: "+count.ToString(),
                                                    new MailAddress(sendMail), 
                                                    mailPass,
                                                    new MailAddress(receiveMail));
                                }
                                if (count == callCondition)
                                {
                                    bool checkBalance =sMS.MakeCall(phone);
                                    if (checkBalance ==false)
                                    {
                                        return 1;
                                    }
                                }
                            }
                            else
                            {
                                count = 0;
                            }
                        }
                    }
                }
                else if (preResult == 1 && result.Length == 0)
                {
                    preResult = 0;
                }
                Retrain();
            }
            catch (Exception e)
            {
                _logger.Error(e.Message);
            }

            return 0;
        }
        public void Retrain()
        {
            TextDetection.Train();
        }

        public void convertToBlackAndWhite(Bitmap input)
        {
            using (Graphics gr = Graphics.FromImage(input)) // SourceImage is a Bitmap object
            {
                var gray_matrix = new float[][] {
                new float[] { 0.299f, 0.299f, 0.299f, 0, 0 },
                new float[] { 0.587f, 0.587f, 0.587f, 0, 0 },
                new float[] { 0.114f, 0.114f, 0.114f, 0, 0 },
                new float[] { 0,      0,      0,      1, 0 },
                new float[] { 0,      0,      0,      0, 1 }
            };

                var ia = new System.Drawing.Imaging.ImageAttributes();
                ia.SetColorMatrix(new System.Drawing.Imaging.ColorMatrix(gray_matrix));
                ia.SetThreshold(0.8f); // Change this threshold as needed
                var rc = new Rectangle(0, 0, input.Width, input.Height);
                gr.DrawImage(input, rc, 0, 0, input.Width, input.Height, GraphicsUnit.Pixel, ia);
            }
        }
    }
}
