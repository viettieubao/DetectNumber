using System;
using System.Drawing;
using Tesseract;
using log4net;

namespace Tesseract_OCR.Schedule
{
    public class Detection
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Detection).Name);
        TesseractEngine ocr;
        String testData { get; set; }

        public Detection()
        {}

        public Detection(String testDataParam)
        {
            try
            {
                this.ocr = new TesseractEngine(testDataParam, "eng", EngineMode.TesseractAndCube);
                this.testData = testDataParam;
            }catch (Exception e)
            {
                _logger.Debug(e.Message);
            }

        }

        public void Train()
        {
            try
            {
                this.ocr = new TesseractEngine(this.testData, "eng", EngineMode.TesseractAndCube);
            }catch(Exception e)
            {
                _logger.Debug(e.Message);
            }

        }
        public string Detect( Bitmap bitmap)
        {
            try
            {
                var page = ocr.Process(bitmap);
                return page.GetText();
            }catch (Exception e)
            {
                _logger.Debug(e.Message);
                return "";
            }

            
        }
    }
}
