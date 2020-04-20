using System;

namespace BIOMETRIA_1
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.load_btn = new System.Windows.Forms.Button();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.RGBvalue_lb = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.save_btn = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btn_Histograms = new System.Windows.Forms.Button();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.cartesianChart1 = new LiveCharts.Wpf.CartesianChart();
            this.elementHost3 = new System.Windows.Forms.Integration.ElementHost();
            this.cartesianChart3 = new LiveCharts.Wpf.CartesianChart();
            this.elementHost4 = new System.Windows.Forms.Integration.ElementHost();
            this.cartesianChart4 = new LiveCharts.Wpf.CartesianChart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.eq_button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AText = new System.Windows.Forms.TextBox();
            this.Btext = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLocal = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.btnManual = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnManualRun = new System.Windows.Forms.Button();
            this.thresholdText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.sizeText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.kText = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(32, 60);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(765, 540);
            this.imageBox.TabIndex = 0;
            this.imageBox.TabStop = false;
            this.imageBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imageBox_MouseClick);
            this.imageBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageBox_MouseMove);
            // 
            // load_btn
            // 
            this.load_btn.Location = new System.Drawing.Point(32, 621);
            this.load_btn.Name = "load_btn";
            this.load_btn.Size = new System.Drawing.Size(75, 23);
            this.load_btn.TabIndex = 1;
            this.load_btn.Text = "LOAD";
            this.load_btn.UseVisualStyleBackColor = true;
            this.load_btn.Click += new System.EventHandler(this.load_btn_Click);
            // 
            // trackBar
            // 
            this.trackBar.LargeChange = 8;
            this.trackBar.Location = new System.Drawing.Point(168, 630);
            this.trackBar.Maximum = 8;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(255, 56);
            this.trackBar.TabIndex = 2;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // RGBvalue_lb
            // 
            this.RGBvalue_lb.AutoSize = true;
            this.RGBvalue_lb.Location = new System.Drawing.Point(133, 706);
            this.RGBvalue_lb.Name = "RGBvalue_lb";
            this.RGBvalue_lb.Size = new System.Drawing.Size(0, 17);
            this.RGBvalue_lb.TabIndex = 3;
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(32, 663);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(75, 23);
            this.save_btn.TabIndex = 4;
            this.save_btn.Text = "SAVE";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Jpeg |*jpeg | Png |*png";
            // 
            // btn_Histograms
            // 
            this.btn_Histograms.Location = new System.Drawing.Point(655, 621);
            this.btn_Histograms.Name = "btn_Histograms";
            this.btn_Histograms.Size = new System.Drawing.Size(142, 32);
            this.btn_Histograms.TabIndex = 9;
            this.btn_Histograms.Text = "Show Histograms";
            this.btn_Histograms.UseVisualStyleBackColor = true;
            this.btn_Histograms.Click += new System.EventHandler(this.btn_Histograms_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(834, 60);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(360, 242);
            this.elementHost1.TabIndex = 10;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.cartesianChart1;
            // 
            // elementHost3
            // 
            this.elementHost3.Location = new System.Drawing.Point(834, 358);
            this.elementHost3.Name = "elementHost3";
            this.elementHost3.Size = new System.Drawing.Size(360, 242);
            this.elementHost3.TabIndex = 12;
            this.elementHost3.Text = "elementHost3";
            this.elementHost3.Child = this.cartesianChart3;
            // 
            // elementHost4
            // 
            this.elementHost4.Location = new System.Drawing.Point(1258, 60);
            this.elementHost4.Name = "elementHost4";
            this.elementHost4.Size = new System.Drawing.Size(360, 242);
            this.elementHost4.TabIndex = 13;
            this.elementHost4.Text = "elementHost4";
            this.elementHost4.Child = this.cartesianChart4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 706);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "RGB Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(834, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Color Image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(834, 325);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Grey Image";
            // 
            // eq_button
            // 
            this.eq_button.Location = new System.Drawing.Point(834, 621);
            this.eq_button.Name = "eq_button";
            this.eq_button.Size = new System.Drawing.Size(101, 32);
            this.eq_button.TabIndex = 17;
            this.eq_button.Text = "Equalization";
            this.eq_button.UseVisualStyleBackColor = true;
            this.eq_button.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1018, 706);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 32);
            this.button2.TabIndex = 18;
            this.button2.Text = "Extension";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(978, 630);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(978, 669);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "B";
            // 
            // AText
            // 
            this.AText.Location = new System.Drawing.Point(1018, 630);
            this.AText.Name = "AText";
            this.AText.Size = new System.Drawing.Size(100, 22);
            this.AText.TabIndex = 21;
            // 
            // Btext
            // 
            this.Btext.Location = new System.Drawing.Point(1018, 663);
            this.Btext.Name = "Btext";
            this.Btext.Size = new System.Drawing.Size(100, 22);
            this.Btext.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 743);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "Brightness";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(168, 743);
            this.trackBar1.Maximum = 50;
            this.trackBar1.Minimum = -50;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(614, 56);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(430, 742);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 17);
            this.label7.TabIndex = 25;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1139, 620);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 32);
            this.button3.TabIndex = 26;
            this.button3.Text = "Binarization";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLocal);
            this.panel1.Controls.Add(this.btnAuto);
            this.panel1.Controls.Add(this.btnManual);
            this.panel1.Location = new System.Drawing.Point(1139, 669);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 54);
            this.panel1.TabIndex = 27;
            // 
            // btnLocal
            // 
            this.btnLocal.Location = new System.Drawing.Point(294, 14);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(75, 23);
            this.btnLocal.TabIndex = 2;
            this.btnLocal.Text = "Local";
            this.btnLocal.UseVisualStyleBackColor = true;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(155, 14);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(83, 23);
            this.btnAuto.TabIndex = 1;
            this.btnAuto.Text = "Automatic";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // btnManual
            // 
            this.btnManual.Location = new System.Drawing.Point(15, 14);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(75, 23);
            this.btnManual.TabIndex = 0;
            this.btnManual.Text = "Manual";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnManualRun);
            this.panel2.Controls.Add(this.thresholdText);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(1139, 729);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(127, 118);
            this.panel2.TabIndex = 28;
            // 
            // btnManualRun
            // 
            this.btnManualRun.Location = new System.Drawing.Point(18, 76);
            this.btnManualRun.Name = "btnManualRun";
            this.btnManualRun.Size = new System.Drawing.Size(96, 23);
            this.btnManualRun.TabIndex = 2;
            this.btnManualRun.Text = "Run";
            this.btnManualRun.UseVisualStyleBackColor = true;
            this.btnManualRun.Click += new System.EventHandler(this.btnManualRun_Click);
            // 
            // thresholdText
            // 
            this.thresholdText.Location = new System.Drawing.Point(15, 48);
            this.thresholdText.Name = "thresholdText";
            this.thresholdText.Size = new System.Drawing.Size(101, 22);
            this.thresholdText.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Threshold";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.kText);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.sizeText);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(1395, 729);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(191, 152);
            this.panel3.TabIndex = 29;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(56, 86);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Run";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // sizeText
            // 
            this.sizeText.Location = new System.Drawing.Point(56, 11);
            this.sizeText.Name = "sizeText";
            this.sizeText.Size = new System.Drawing.Size(101, 22);
            this.sizeText.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 17);
            this.label9.TabIndex = 3;
            this.label9.Text = "Size";
            // 
            // kText
            // 
            this.kText.Location = new System.Drawing.Point(56, 48);
            this.kText.Name = "kText";
            this.kText.Size = new System.Drawing.Size(101, 22);
            this.kText.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 17);
            this.label10.TabIndex = 6;
            this.label10.Text = "K";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1728, 992);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Btext);
            this.Controls.Add(this.AText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.eq_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.elementHost4);
            this.Controls.Add(this.elementHost3);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.btn_Histograms);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.RGBvalue_lb);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.load_btn);
            this.Controls.Add(this.imageBox);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.Button load_btn;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label RGBvalue_lb;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button btn_Histograms;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private LiveCharts.Wpf.CartesianChart cartesianChart1;
        private System.Windows.Forms.Integration.ElementHost elementHost3;
        private LiveCharts.Wpf.CartesianChart cartesianChart3;
        private System.Windows.Forms.Integration.ElementHost elementHost4;
        private LiveCharts.Wpf.CartesianChart cartesianChart4;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button eq_button;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox AText;
        private System.Windows.Forms.TextBox Btext;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLocal;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox thresholdText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnManualRun;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox kText;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox sizeText;
        private System.Windows.Forms.Label label9;
    }
}

