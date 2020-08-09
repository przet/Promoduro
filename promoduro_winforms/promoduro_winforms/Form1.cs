﻿// Thanks to Geoff Stratton:
// https://www.geoffstratton.com/cnet-countdown-timer
//
// Also, 
// https://docs.microsoft.com/en-us/visualstudio/ide/step-3-add-a-countdown-timer?view=vs-2019
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace promoduro_winforms
{
    public partial class Form1 : Form
    {
        private long TimeLeft;
        private int StopCount = 0;
        private string m50;
        private string m17;
        private string m25;
        private string m10;
        private string m30;
        private bool mPomodoroStateIs50;

        public Form1()
        {
            #if DEBUG
            m50 = "00:05";
            m17 = "00:03";
            m25 = "00:02";
            m10 = "00:01";
            m30 = "00:04";
            #else
            m50 = "50:00";
            m17 = "17:00";
            m25 = "25:00";
            m10 = "10:00";
            m30 = "30:00";
            #endif

            InitializeComponent();
            timetextbox.Text = m50;
            mPomodoroStateIs50 = true;
            toolStripMenuItem3.CheckState = CheckState.Checked;
            toolStripMenuItem2.CheckState = CheckState.Unchecked;

            timer1 = new Timer { Interval = 1000 };
            contextMenuStrip1 = new ContextMenuStrip();
            contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(cms_opening);
            this.ContextMenuStrip = contextMenuStrip1;
            contextMenuStrip1.Items.Add(toolStripMenuItem2);
            contextMenuStrip1.Items.Add(toolStripMenuItem3);
            contextMenuStrip1.Items.Add(aboutToolStripMenuItem);
        }

        private void cms_opening(object sender, CancelEventArgs e)
        {
        }

        private void Starttimer_btn_Click(object sender, EventArgs e)
        {
            string[] TotalSeconds = timetextbox.Text.Split(':');
            long Minutes = Convert.ToInt64(TotalSeconds[0]);
            long Seconds = Convert.ToInt64(TotalSeconds[1]);
            //TimeLeft = (Minutes * 60) + Seconds;
            long Sixty = Convert.ToInt64(60);
            TimeLeft = Minutes * Sixty + Seconds;
            // Lock buttons and input
            starttimer_btn.Enabled = false;
            timetextbox.Enabled = false;
            resettimer_btn.Enabled = false;
            if (!pause_btn.Enabled)
                pause_btn.Enabled = true;

            // Tick event handling, and timer start
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer1.Start();

        }
        private void Pause_btn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            starttimer_btn.Enabled = true;
            resettimer_btn.Enabled = true;
            timetextbox.Enabled = true;
            timer1 = new Timer { Interval = 1000 };
        }

        private void Resettime_btn_Click(object sender, EventArgs e)
        {
            if (mPomodoroStateIs50)
            {
                if (StopCount % 2 == 0)
                {
                    timetextbox.Text = m50;
                }
                else
                {
                    timetextbox.Text = m17;
                }

            }
            else
            {
                if (StopCount % 2 == 0)
                {
                    timetextbox.Text = m25;
                }
                else if (StopCount % 2 !=0 && StopCount != 7)
                {
                    timetextbox.Text = m10;
                }
                else if (StopCount == 7)
                {
                    timetextbox.Text = m30;
                }

                if (StopCount == 8)
                {
                    //Reset stop count
                    StopCount = 0;
                }

            }

            starttimer_btn.Enabled = true;
            timetextbox.Enabled = true;
            timer1 = new Timer { Interval = 1000 };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= 1;
                var timespan = TimeSpan.FromSeconds(TimeLeft);
                timetextbox.Text = timespan.ToString(@"mm\:ss");
            }
            else
            {
                timer1.Stop();
                StopCount++;

                pause_btn.Enabled = false;
                resettimer_btn.Enabled = true;
                IntPtr ForegroundWin = Class1.GetForegroundWindow();
                if (ForegroundWin != this.Handle)
                {
                    Class1.FlashWindow(this.Handle, false);
                }

                if (mPomodoroStateIs50)
                {
                    if (StopCount % 2 != 0)
                        MessageBox.Show("Time is up, take a 17 minute break", "Time is up!", MessageBoxButtons.OK);
                    else if (StopCount % 2 == 0)
                        MessageBox.Show("Break time is over! Get ready for another session!", " Break Time is up!", MessageBoxButtons.OK);
                }
                else 
                {
                    if (StopCount % 2 != 0 && StopCount != 7)
                        MessageBox.Show("Time is up, take a 10 minute break", "Time is up!", MessageBoxButtons.OK);
                    else if (StopCount % 2 == 0)
                        MessageBox.Show("Break time is over! Get ready for another session!", " Break Time is up!", MessageBoxButtons.OK);
                    else if (StopCount == 7)
                        MessageBox.Show("Time is up, take a 30 minute break", "Time is up!", MessageBoxButtons.OK);

                }


            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Guard against stop count reset if already on 25 min
            // E.g user could click 25 just because it is there. 
            if (mPomodoroStateIs50)
            {
                DialogResult result = MessageBox.Show("Leaving 50 min state...this will reset all break counts.",
                    "Swtiching to 25 min state...",
                     MessageBoxButtons.OKCancel);

                if (result != System.Windows.Forms.DialogResult.Cancel)
                {
                    toolStripMenuItem2.CheckState = CheckState.Checked;
                    toolStripMenuItem3.CheckState = CheckState.Unchecked;
                    timetextbox.Text = m25;
                    mPomodoroStateIs50 = false;

                    // Reset stop count
                    StopCount = 0;
                }

            }
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // Guard against stop count reset if already on 50 min
            // E.g user could click 50 just because it is there. 
            if (!mPomodoroStateIs50)
            {
                DialogResult result = MessageBox.Show("Leaving 25 min state...this will reset all break counts.",
                    "Swtiching to 50 min state...",
                     MessageBoxButtons.OKCancel);

                if (result != System.Windows.Forms.DialogResult.Cancel)
                {
                    toolStripMenuItem3.CheckState = CheckState.Checked;
                    toolStripMenuItem2.CheckState = CheckState.Unchecked;
                    timetextbox.Text = m50;
                    mPomodoroStateIs50 = true;

                    // Reset stop count
                    StopCount = 0;
                }

            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string aboutStr = "20200809-dev";
            MessageBox.Show(aboutStr + "\n Issues, bugs, pull requests: https://github.com/przet/Promoduro.",
                "About Promoduro...",
                 MessageBoxButtons.OK);
        }
    }
    public class Class1
    {
        [DllImport("user32.dll")]
        public static extern int FlashWindow(IntPtr Hwnd, bool Revert);
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

    }
}
