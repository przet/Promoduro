﻿namespace promoduro_winforms
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
            this.starttimer_btn = new System.Windows.Forms.Button();
            this.resettimer_btn = new System.Windows.Forms.Button();
            this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pause_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // starttimer_btn
            // 
            this.starttimer_btn.Location = new System.Drawing.Point(317, 425);
            this.starttimer_btn.Name = "starttimer_btn";
            this.starttimer_btn.Size = new System.Drawing.Size(159, 69);
            this.starttimer_btn.TabIndex = 0;
            this.starttimer_btn.Text = "Start Timer!";
            this.starttimer_btn.UseVisualStyleBackColor = true;
            this.starttimer_btn.Click += new System.EventHandler(this.Starttimer_btn_Click);
            // 
            // resettimer_btn
            // 
            this.resettimer_btn.Location = new System.Drawing.Point(317, 621);
            this.resettimer_btn.Name = "resettimer_btn";
            this.resettimer_btn.Size = new System.Drawing.Size(159, 69);
            this.resettimer_btn.TabIndex = 1;
            this.resettimer_btn.Text = "Reset Timer";
            this.resettimer_btn.UseVisualStyleBackColor = true;
            this.resettimer_btn.Click += new System.EventHandler(this.resettime_btn_Click);
            // 
            // maskedTextBox
            // 
            this.maskedTextBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.maskedTextBox.Location = new System.Drawing.Point(341, 292);
            this.maskedTextBox.Name = "maskedTextBox";
            this.maskedTextBox.Size = new System.Drawing.Size(100, 29);
            this.maskedTextBox.TabIndex = 2;
            this.maskedTextBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.MaskedTextBox1_MaskInputRejected);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // pause_btn
            // 
            this.pause_btn.Location = new System.Drawing.Point(317, 521);
            this.pause_btn.Name = "pause_btn";
            this.pause_btn.Size = new System.Drawing.Size(159, 69);
            this.pause_btn.TabIndex = 3;
            this.pause_btn.Text = "Pause Timer";
            this.pause_btn.UseVisualStyleBackColor = true;
            this.pause_btn.Click += new System.EventHandler(this.pause_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = global::promoduro_winforms.Properties.Resources.istockphoto_466175630_612x612;
            this.ClientSize = new System.Drawing.Size(840, 837);
            this.Controls.Add(this.pause_btn);
            this.Controls.Add(this.maskedTextBox);
            this.Controls.Add(this.resettimer_btn);
            this.Controls.Add(this.starttimer_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button starttimer_btn;
        private System.Windows.Forms.Button resettimer_btn;
        private System.Windows.Forms.MaskedTextBox maskedTextBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button pause_btn;
    }
}
