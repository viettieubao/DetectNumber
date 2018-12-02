using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace Tesseract_OCR.Schedule
{
    public class Detection
    {
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

            }

        }

        public void Train()
        {
            try
            {
                this.ocr = new TesseractEngine(this.testData, "eng", EngineMode.TesseractAndCube);
            }catch(Exception e)
            {

            }

        }
        public string Detect( Bitmap bitmap)
        {
            try
            {
                var page = ocr.Process(bitmap);
                Console.WriteLine(">>>>>>>>>>>>>>>>> Result: " + page.GetText());
                return page.GetText();
            }catch (Exception e)
            {
                return "";
            }

            
        }
    }
}
