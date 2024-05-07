using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Street_Fighters
{
    public partial class GameOverScreen : Form
    {
        Player winner;
        Time time = new Time("00","10");

        public GameOverScreen(Player winner)
        {
            InitializeComponent();
            this.winner = winner;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            ImageAnimator.Animate(winner.currentMovement, this.OnFrameChangedHandler);
        }

        private void OnFrameChangedHandler(object sender, EventArgs e)
        { // for updating the image
            this.Invalidate();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
            ImageAnimator.UpdateFrames();
            time.decrement();
            if (time.time() == "00:00")
                StartOver();
        }

        private void GameOverScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(winner.currentMovement, new Point(winner.X, winner.Y));
        }

        private void StartOver()
        {
            timer.Stop();
            Start startagain = new Start();
            startagain.Show();
            this.Hide();
        }
    }
}
