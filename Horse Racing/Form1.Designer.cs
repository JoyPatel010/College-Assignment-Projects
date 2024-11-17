namespace HorseRacingGame
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Lion = new PictureBox();
            Buffelo = new PictureBox();
            Chimpanzi = new PictureBox();
            btnStart = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            label1 = new Label();
            resetBtn = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)Lion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Buffelo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Chimpanzi).BeginInit();
            SuspendLayout();
            // 
            // Lion
            // 
            Lion.ErrorImage = Properties.Resources.Lion;
            Lion.Image = Properties.Resources.Lion;
            Lion.InitialImage = Properties.Resources.Lion;
            Lion.Location = new Point(14, 82);
            Lion.Name = "Lion";
            Lion.Size = new Size(217, 141);
            Lion.SizeMode = PictureBoxSizeMode.StretchImage;
            Lion.TabIndex = 0;
            Lion.TabStop = false;
            // 
            // Buffelo
            // 
            Buffelo.Image = Properties.Resources.Buffelo;
            Buffelo.Location = new Point(15, 277);
            Buffelo.Name = "Buffelo";
            Buffelo.Size = new Size(216, 130);
            Buffelo.SizeMode = PictureBoxSizeMode.StretchImage;
            Buffelo.TabIndex = 1;
            Buffelo.TabStop = false;
            // 
            // Chimpanzi
            // 
            Chimpanzi.Image = Properties.Resources.Chimmpanzi;
            Chimpanzi.Location = new Point(12, 463);
            Chimpanzi.Name = "Chimpanzi";
            Chimpanzi.Size = new Size(217, 127);
            Chimpanzi.SizeMode = PictureBoxSizeMode.StretchImage;
            Chimpanzi.TabIndex = 2;
            Chimpanzi.TabStop = false;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.MediumBlue;
            btnStart.Font = new Font("Rockwell Extra Bold", 15F);
            btnStart.ForeColor = SystemColors.ButtonHighlight;
            btnStart.Location = new Point(261, 643);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(182, 69);
            btnStart.TabIndex = 3;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Location = new Point(14, 212);
            panel2.Name = "panel2";
            panel2.Size = new Size(1127, 26);
            panel2.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Black;
            panel3.Location = new Point(13, 398);
            panel3.Name = "panel3";
            panel3.Size = new Size(1127, 26);
            panel3.TabIndex = 7;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Black;
            panel4.Location = new Point(12, 584);
            panel4.Name = "panel4";
            panel4.Size = new Size(1127, 26);
            panel4.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Navy;
            label1.Font = new Font("Rockwell Condensed", 35F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(188, 9);
            label1.Name = "label1";
            label1.Size = new Size(388, 70);
            label1.TabIndex = 9;
            label1.Text = "Animal Racing";
            // 
            // resetBtn
            // 
            resetBtn.BackColor = Color.MediumBlue;
            resetBtn.Font = new Font("Rockwell Extra Bold", 15F);
            resetBtn.ForeColor = SystemColors.ButtonHighlight;
            resetBtn.Location = new Point(837, 643);
            resetBtn.Name = "resetBtn";
            resetBtn.Size = new Size(182, 69);
            resetBtn.TabIndex = 10;
            resetBtn.Text = "Reset";
            resetBtn.UseVisualStyleBackColor = false;
            resetBtn.Click += resetBtn_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.Red;
            label2.Font = new Font("Segoe UI", 20F);
            label2.ForeColor = SystemColors.Control;
            label2.Location = new Point(1131, 99);
            label2.Name = "label2";
            label2.Size = new Size(62, 511);
            label2.TabIndex = 11;
            label2.Text = "F  I N I  S H L  I N E";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DodgerBlue;
            ClientSize = new Size(1337, 724);
            Controls.Add(label2);
            Controls.Add(resetBtn);
            Controls.Add(label1);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(btnStart);
            Controls.Add(Chimpanzi);
            Controls.Add(Buffelo);
            Controls.Add(Lion);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)Lion).EndInit();
            ((System.ComponentModel.ISupportInitialize)Buffelo).EndInit();
            ((System.ComponentModel.ISupportInitialize)Chimpanzi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Lion;
        private PictureBox Buffelo;
        private PictureBox Chimpanzi;
        private Button btnStart;
        private System.Windows.Forms.Timer timer1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Label label1;
        private Button resetBtn;
        private Label label2;
    }
}
