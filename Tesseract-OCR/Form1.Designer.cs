namespace Tesseract_OCR
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btOCR = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Setting = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtSendSMSCheck = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtScoreCheck = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCharCount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tisoY = new System.Windows.Forms.Label();
            this.tisoX = new System.Windows.Forms.Label();
            this.chuX = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chuY = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtText = new System.Windows.Forms.TextBox();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtSum = new System.Windows.Forms.TextBox();
            this.txtCount = new System.Windows.Forms.Label();
            this.Setting.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOCR
            // 
            resources.ApplyResources(this.btOCR, "btOCR");
            this.btOCR.Name = "btOCR";
            this.btOCR.UseVisualStyleBackColor = true;
            this.btOCR.Click += new System.EventHandler(this.btOCR_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Setting
            // 
            this.Setting.Controls.Add(this.textBox1);
            this.Setting.Controls.Add(this.label5);
            this.Setting.Controls.Add(this.btOCR);
            this.Setting.Controls.Add(this.button2);
            this.Setting.Controls.Add(this.txtSendSMSCheck);
            this.Setting.Controls.Add(this.label14);
            this.Setting.Controls.Add(this.txtScoreCheck);
            this.Setting.Controls.Add(this.label13);
            this.Setting.Controls.Add(this.txtCharCount);
            this.Setting.Controls.Add(this.label12);
            resources.ApplyResources(this.Setting, "Setting");
            this.Setting.Name = "Setting";
            this.Setting.TabStop = false;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtSendSMSCheck
            // 
            resources.ApplyResources(this.txtSendSMSCheck, "txtSendSMSCheck");
            this.txtSendSMSCheck.Name = "txtSendSMSCheck";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // txtScoreCheck
            // 
            resources.ApplyResources(this.txtScoreCheck, "txtScoreCheck");
            this.txtScoreCheck.Name = "txtScoreCheck";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // txtCharCount
            // 
            resources.ApplyResources(this.txtCharCount, "txtCharCount");
            this.txtCharCount.Name = "txtCharCount";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // tisoY
            // 
            resources.ApplyResources(this.tisoY, "tisoY");
            this.tisoY.Name = "tisoY";
            // 
            // tisoX
            // 
            resources.ApplyResources(this.tisoX, "tisoX");
            this.tisoX.Name = "tisoX";
            // 
            // chuX
            // 
            resources.ApplyResources(this.chuX, "chuX");
            this.chuX.Name = "chuX";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // chuY
            // 
            resources.ApplyResources(this.chuY, "chuY");
            this.chuY.Name = "chuY";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.chuY);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.chuX);
            this.panel2.Controls.Add(this.tisoX);
            this.panel2.Controls.Add(this.tisoY);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // txtText
            // 
            resources.ApplyResources(this.txtText, "txtText");
            this.txtText.Name = "txtText";
            // 
            // txtScore
            // 
            resources.ApplyResources(this.txtScore, "txtScore");
            this.txtScore.Name = "txtScore";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtSum
            // 
            resources.ApplyResources(this.txtSum, "txtSum");
            this.txtSum.Name = "txtSum";
            // 
            // txtCount
            // 
            resources.ApplyResources(this.txtCount, "txtCount");
            this.txtCount.Name = "txtCount";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.txtSum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.Setting);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Setting.ResumeLayout(false);
            this.Setting.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOCR;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox Setting;
        private System.Windows.Forms.TextBox txtSendSMSCheck;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtScoreCheck;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCharCount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label tisoY;
        private System.Windows.Forms.Label tisoX;
        private System.Windows.Forms.Label chuX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label chuY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSum;
        private System.Windows.Forms.Label txtCount;
    }
}

