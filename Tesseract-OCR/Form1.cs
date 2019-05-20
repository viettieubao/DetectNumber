using System;
using System.Drawing;
using System.Windows.Forms;
using Tesseract_OCR.Schedule;

namespace Tesseract_OCR
{
    public partial class Form1 : Form
    {

        Boolean isRun;
        Schedules schedule;
        int a = 0;

        public Form1()
        {
            InitializeComponent();
            schedule = new Schedules();

            this.isRun = true;
            schedule.charCount = int.Parse(txtCharCount.Text);
            schedule.scoreCondition = int.Parse(txtScoreCheck.Text);
            schedule.smsCondition = int.Parse(txtSendSMSCheck.Text);
            this.timer1.Interval = int.Parse(textBox1.Text)*1000;
            schedule.sendMail = txtSendMail.Text;
            schedule.mailPass = txtPassMaill.Text;
            schedule.receiveMail = txtReceiveMail.Text;
            schedule.phone = txtPhone.Text;
            schedule.notify = 1800 / (timer1.Interval/1000);
            schedule.callCondition = int.Parse(txtCallCheck.Text);
        }

        private void btOCR_Click(object sender, EventArgs e)
        {
            if (isRun == true)
            {
                timer1.Enabled = true;
                btOCR.Text = "Stop";
                isRun = false;
            }
            else
            {
                timer1.Enabled = false;
                btOCR.Text = "Start";
                isRun = true;
            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            int checkRun = this.schedule.Run();
            if (checkRun==1)
            {
                timer1.Stop();
                MessageBox.Show("Nạp tiền vào tài khoản để có thể tiếp tục thực hiện cuộc gọi");
            }
            this.txtText.Text = this.schedule.nowText;
            this.txtScore.Text = this.schedule.nowScore;
            this.txtSum.Text = this.schedule.sumScores.ToString();
            this.txtCount.Text = this.schedule.count.ToString() ;
            a++;
            if (a>=34000)
                this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Rectangle canvasBoundMatch = Screen.GetBounds(Point.Empty);
            Rectangle canvasBoundText = Screen.GetBounds(Point.Empty);
            this.Hide();
            if (schedule.capView.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                canvasBoundMatch = schedule. capView.GetRectangleMatch();
                canvasBoundText = schedule.capView.GetRectangleText();
                this.tisoX.Text = "(x,y)=(" + canvasBoundMatch.X + "," + canvasBoundMatch.Y + ")";
                this.tisoY.Text = "(W,H)=(" + canvasBoundMatch.Width + "," + canvasBoundMatch.Height + ")";
                this.chuX.Text = "(x,y)=(" + canvasBoundText.X + "," + canvasBoundText.Y + ")";
                this.chuY.Text = "(W,H)=(" + canvasBoundText.Width + "," + canvasBoundText.Height + ")";
            }
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            schedule.charCount = int.Parse( txtCharCount.Text);
            schedule.scoreCondition = int.Parse(txtScoreCheck.Text);
            schedule.smsCondition = int.Parse(txtSendSMSCheck.Text);
            schedule.callCondition = int.Parse(txtCallCheck.Text);
            timer1.Interval = int.Parse(textBox1.Text) * 1000;
            schedule.sendMail = txtSendMail.Text;
            schedule.mailPass = txtPassMaill.Text;
            schedule.receiveMail = txtReceiveMail.Text;
            schedule.phone = txtPhone.Text;
            schedule.notify = int.Parse(txtNotify.Text)*60/(timer1.Interval/1000);
        }

    }
}
