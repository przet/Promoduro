// Special thanks to Geoff Stratton, who wrote a countime timer and posted his code:
// https://www.geoffstratton.com/cnet-countdown-timer
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

namespace promoduro_winforms
{
    public partial class Form1 : Form
    {
        private int TimeLeft;
        public Form1()
        {
            InitializeComponent();
            maskedTextBox.Text = "25:00";
            timer1.Interval = 1000;

            // Funky stuff with time countdown, but i _think_ I know what is going on...
            // Buttons (and hence functionality) disabled for now
            pause_btn.Visible = false;
        }

        private void Starttimer_btn_Click(object sender, EventArgs e)
        {
            string[] TotalSeconds = maskedTextBox.Text.Split(':');
            int Minutes = Convert.ToInt32(TotalSeconds[0]);
            int Seconds = Convert.ToInt32(TotalSeconds[1]);
            TimeLeft = (Minutes * 60) + Seconds;

            // Lock buttons and input
            starttimer_btn.Enabled = false;
            maskedTextBox.Enabled = false;
            resettimer_btn.Enabled = false;

            // Tick event handling, and timer start
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer1.Start();

        }
        private void pause_btn_Click(object sender, EventArgs e)
        {
            timer1.Stop();

        }

        private void resettime_btn_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MaskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= 1;
                var timespan = TimeSpan.FromSeconds(TimeLeft);
                maskedTextBox.Text = timespan.ToString(@"mm\:ss");
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("Time is up!", "Time is up, take a 3 - 5 minute break", MessageBoxButtons.OK);
            }
        }

    }
}
