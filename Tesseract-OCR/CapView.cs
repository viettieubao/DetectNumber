using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tesseract_OCR
{
    public struct Rect
    {
        public Point startPos;
        public Point endPos;
    };
    public partial class CapView : Form
    {


        Rect rectangleMatch ;      // mouse-down position
        Rect rectangleText;
        Point currentPos;
        int currentRect = 1;// current mouse position
        bool drawing;
        public CapView()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = Color.White;
            this.Opacity = 0.75;
            this.Cursor = Cursors.Cross;
            this.MouseDown += Canvas_MouseDown;
            this.MouseMove += Canvas_MouseMove;
            this.MouseUp += Canvas_MouseUp;
            this.Paint += Canvas_Paint;
            this.KeyDown += Canvas_KeyDown;
            this.DoubleBuffered = true;
        }

        private void CapView_Load(object sender, EventArgs e)
        {

        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
        }
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (currentRect == 1)
            {
                currentPos = rectangleMatch.startPos = e.Location;
            }
            else
            {
                currentPos = rectangleText.startPos = e.Location;
            }
            drawing = true;
           // this.label1.Text = e.Location.X + "," + e.Location.Y;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            currentPos = e.Location;
            if (drawing) this.Invalidate();
            this.label1.Text = e.Location.X + "," + e.Location.Y;
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (currentRect == 1)
            {
                currentPos = rectangleMatch.endPos = e.Location;
                drawing = false;
                currentRect++;
            }
            else
            {
                currentPos = rectangleText.endPos = e.Location;
                currentRect = 1;
                this.drawing = false;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
                
            }
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            if (currentRect == 1)
            {
                if (drawing) e.Graphics.DrawRectangle(Pens.Red, GetRectangle(this.rectangleMatch));
            }
            else
            {
                if (drawing) e.Graphics.DrawRectangle(Pens.Green, GetRectangle(this.rectangleText));
            }
        }
        public Rectangle GetRectangle(Rect curRect)
        {
            return new Rectangle(
                Math.Min(curRect.startPos.X, currentPos.X),
                Math.Min(curRect.startPos.Y, currentPos.Y),
                Math.Abs(curRect.startPos.X - currentPos.X),
                Math.Abs(curRect.startPos.Y - currentPos.Y));
        }
        public Rectangle GetRectangleMatch()
        {
            return new Rectangle(
                Math.Min(rectangleMatch.startPos.X, rectangleMatch.endPos.X),
                Math.Min(rectangleMatch.startPos.Y, rectangleMatch.endPos.Y),
                Math.Abs(rectangleMatch.startPos.X - rectangleMatch.endPos.X),
                Math.Abs(rectangleMatch.startPos.Y - rectangleMatch.endPos.Y));
        }

        public Rectangle GetRectangleText()
        {
            return new Rectangle(
                Math.Min(rectangleText.startPos.X, rectangleText.endPos.X),
                Math.Min(rectangleText.startPos.Y, rectangleText.endPos.Y),
                Math.Abs(rectangleText.startPos.X - rectangleText.endPos.X),
                Math.Abs(rectangleText.startPos.Y - rectangleText.endPos.Y));
        }

        public Bitmap GetRectangleTextBitmap()
        {
            Rectangle rectangle = GetRectangleText();
            using (Image image = new Bitmap(rectangle.Width, rectangle.Height))
            {
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    graphics.CopyFromScreen(new Point(rectangle.Left, rectangle.Top), Point.Empty, rectangle.Size);
                }
                return new Bitmap(image);
            }
        }

        public Bitmap GetRectangleMatchBitmap()
        {
            Rectangle rectangle = GetRectangleMatch();
            using (Image image = new Bitmap(rectangle.Width, rectangle.Height))
            {
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    graphics.CopyFromScreen(new Point(rectangle.Left, rectangle.Top), Point.Empty, rectangle.Size);
                }
                return new Bitmap(image);
            }
        }
        private Image SetBorder(Image srcImg, Color color, int width)
        {
            // Create a copy of the image and graphics context
            Image dstImg = srcImg.Clone() as Image;
            Graphics g = Graphics.FromImage(dstImg);

            // Create the pen
            Pen pBorder = new Pen(color, width)
            {
                Alignment = PenAlignment.Center
            };

            // Draw
            g.DrawRectangle(pBorder, 0, 0, dstImg.Width - 1, dstImg.Height - 1);

            // Clean up
            pBorder.Dispose();
            g.Save();
            g.Dispose();

            // Return
            return dstImg;
        }
    }
}
