// Thanks to Geoff Stratton:
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
        private int _5_MinBreakCount = 0;
        public Form1()
        {
            InitializeComponent();
#if DEBUG
            timetextbox.Text = "00:05";
#else
            timetextbox.Text = "50:00";
#endif

            timer1 = new Timer { Interval = 1000 };
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
            if (StopCount % 2 == 0)
#if DEBUG
            timetextbox.Text = "00:05";
#else
            timetextbox.Text = "50:00";
#endif
            else
            {
#if DEBUG
            timetextbox.Text = "00:01";
#else
            timetextbox.Text = "17:00";
#endif
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
                if (StopCount % 2 != 0)
                    _5_MinBreakCount++;

                pause_btn.Enabled = false;
                resettimer_btn.Enabled = true;
                IntPtr ForegroundWin = Class1.GetForegroundWindow();
                if (ForegroundWin != this.Handle)
                {
                    Class1.FlashWindow(this.Handle, false);
                }

                if (StopCount % 2 != 0) 
                    MessageBox.Show("Time is up, take a 17 minute break", "Time is up!", MessageBoxButtons.OK);
                else if (StopCount % 2 == 0) 
                    MessageBox.Show("Break time is over! Get ready for another session!", " Break Time is up!", MessageBoxButtons.OK);
                
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

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
