// FULL CREDIT TO https://www.geoffstratton.com/cnet-countdown-timer
// Cut + paste from that site for testing purposes (to have a working baseline)

using System;
using System.Windows.Forms;
using System.Media;
 
namespace CountdownTimer
{
    public partial class FrmTimer : Form
    {
        private int timeLeft;
                 
        public FrmTimer()
        {
            InitializeComponent();
        }
 
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtTimer.Text == "00:00")
            { 
                MessageBox.Show("Please enter the time to start!", "Enter the Time", MessageBoxButtons.OK);
            } 
            else
            {
                // Convert text to seconds as int for timer
                string[] totalSeconds = txtTimer.Text.Split(':');
                int minutes = Convert.ToInt32(totalSeconds[0]);
                int seconds = Convert.ToInt32(totalSeconds[1]);
                timeLeft = (minutes*60) + seconds;
 
                // Lock Start and Clear buttons and text box
                btnStart.Enabled = false;
                btnClear.Enabled = false;
                txtTimer.ReadOnly = true;
 
                // Define Tick eventhandler and start timer
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Start();
            }
        }
 
        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timeLeft = 0;
            btnStart.Enabled = true;
            btnClear.Enabled = true;
            txtTimer.ReadOnly = false;
        }
 
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTimer.Text = "00:00";
        }
 
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                // Display time remaining as mm:ss
                var timespan = TimeSpan.FromSeconds(timeLeft);
                txtTimer.Text = timespan.ToString(@"mm\:ss");
                // Alternate method
                //int secondsLeft = timeLeft % 60;
                //int minutesLeft = timeLeft / 60;
            }
            else
            {
                timer1.Stop();
                SystemSounds.Exclamation.Play();
                MessageBox.Show("Time's up!", "Time has elapsed", MessageBoxButtons.OK);
            }
        }
    }
}