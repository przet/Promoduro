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
        public Form1()
        {
            InitializeComponent();
            timetextbox.Text = "25:00";
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
            timetextbox.Text = "25:00";
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
                pause_btn.Enabled = false;
                resettimer_btn.Enabled = true;
                IntPtr ForegroundWin = Class1.GetForegroundWindow();
                if (ForegroundWin != this.Handle)
                {
                    Class1.FlashWindow(this.Handle, false);
                }
                MessageBox.Show("Time is up, take a 3 - 5 minute break", "Time is up!", MessageBoxButtons.OK);
                
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        int Counter_Background_cycle_button_click = 1;
        private void Background_cycle_button_Click(object sender, EventArgs e)
        {
            switch (Counter_Background_cycle_button_click)
            {
                case 1:
                    this.BackgroundImage = Properties.Resources._35611264264_42fbb8164c_b;
                    Counter_Background_cycle_button_click++;
                    break;

                case 2:
                    this.BackgroundImage = Properties.Resources.code_coding_programmer_305278;
                    Counter_Background_cycle_button_click++;
                    break;

                case 3:
                    this.BackgroundImage = Properties.Resources.giphy;
                    Counter_Background_cycle_button_click++;
                    break;
                case 4:
                    this.BackgroundImage = Properties.Resources.dark_973772_960_720;
                    Counter_Background_cycle_button_click++;
                    break;
                case 5:
                    this.BackgroundImage = Properties.Resources.magician_3047235_960_720;
                    Counter_Background_cycle_button_click = 1;
                    break;
            }
                
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
