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
        //public Detection ScoreDetection { get; set; }
        public SMS sMS { get; set; }
        public CapView capView { get; set; }

        public string nowText { get; set; }
        public string nowScore { get; set; }
        public int preResult { get; set; }
        public int charCount { get; set; }
        public int scoreCondition { get; set; }
        public int smsCondition { get; set; }
        public int sumScores { get; set; }
        public int count { get; set; }

        public string sendMail { get; set; }
        public string mailPass { get; set; }
        public string receiveMail { get; set; }
        public string apiKey { get; set; }
        public string secretKey { get; set; }
        public string phone { get; set; }
        public Schedules()
        {
            capView = new CapView();
            sMS = new SMS();
            TextDetection = new Detection("./tessdata");
            //ScoreDetection = new Detection("./tessdata2");
            this.preResult = 0;
            this.count = 0;
        }
        public void Run()
        {
            try
            {
                Bitmap textBitmap = capView.GetRectangleTextBitmap();
                convertToBlackAndWhite(textBitmap);
                //Retrain();
                string result = TextDetection.Detect(textBitmap);
                //formart string
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
                        score = score.Replace("\n", String.Empty);
                        score = System.Text.RegularExpressions.Regex.Replace(score, " ", "");


                        Console.Write(">?>>>>>> Score: " + score);
                        score = System.Text.RegularExpressions.Regex.Replace(score, "o", "0");
                        score = System.Text.RegularExpressions.Regex.Replace(score, "l", "1");
                        this.nowScore = score;
                        string[] array = score.Split('-');
                        if (array.Length == 2)
                        {
                            int sumScore = int.Parse(array[0]) + int.Parse(array[1]);
                            this.sumScores = sumScore;

                            if (sumScore > scoreCondition)
                            {
                                count++;
                                if (count >= smsCondition-1)
                                {
                                    sMS.SendSMS("Thông báo đủ số lượng: "+count.ToString(),
                                                    new MailAddress(sendMail), 
                                                    mailPass,
                                                    new MailAddress(receiveMail));
                                    Console.Write(count);
                                    if (count == smsCondition)
                                    {
                                        sMS.MakeCall(phone);
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
