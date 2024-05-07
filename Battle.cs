using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Media;
namespace Street_Fighters
{
    public partial class Battle : Form
    {
        Player player1, player2;
        Maps map;
        Time gameTime;
        private SoundPlayer soundPlayer;

        public Battle()
        {
            InitializeComponent();
            SetupGround();
            soundPlayer = new SoundPlayer(Path.Combine(Application.StartupPath, "SFImages\\bgmusic.wav"));
            soundPlayer.PlayLooping();
        }
        private void Battle_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop and release the resources when the form is closing
            soundPlayer.Stop();
            soundPlayer.Dispose();
            base.OnFormClosing(e);
        }

        // Events
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && !player1.directionPressed)
                MovePlayerAnimation(player1,"left");
            if (e.KeyCode == Keys.D && !player1.directionPressed)
                MovePlayerAnimation(player1,"right");
            if (e.KeyCode == Keys.J && !player2.directionPressed)
                MovePlayerAnimation(player2, "left");
            if (e.KeyCode == Keys.L && !player2.directionPressed)
                MovePlayerAnimation(player2, "right");
            /*if (e.KeyCode == Keys.S && !player1.playingAction && !player1.goLeft && !player1.goRight)
            {
                player1.SetPlayerAction(player1.block, -1);
                //SetupAnimation(player1);
            }
            if (e.KeyCode == Keys.K && !player2.playingAction && !player2.goLeft && !player2.goRight)
            {
                player2.SetPlayerAction(player2.block, -1);
                //SetupAnimation(player2);
            }*/
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            
            // Movement Keys
            // player1
            if (e.KeyCode==Keys.D || e.KeyCode == Keys.A)
            {
                player1.goLeft = false; player1.goRight = false; player1.directionPressed = false;
                player1.Reset();
                SetupAnimation(player1);
            }
            // player2
            if (e.KeyCode == Keys.J || e.KeyCode == Keys.L)
            {
                player2.goLeft = false; player2.goRight = false; player2.directionPressed = false;
                player2.Reset();
                SetupAnimation(player2);
            }
            // Action Keys
            // player1
            if (e.KeyCode == Keys.Q && !player1.playingAction && !player1.goLeft && !player1.goRight)
            {
                player1.SetPlayerAction(player1.punchLight, 2);
                SetupAnimation(player1);
            }
            if (e.KeyCode == Keys.W && !player1.playingAction && !player1.goLeft && !player1.goRight)
            {
                player1.SetPlayerAction(player1.punchStrong, 5);
                SetupAnimation(player1);
            }
            if (e.KeyCode == Keys.E && !player1.playingAction && !player1.goLeft && !player1.goRight && !player1.shotFireball)
            {
                if (player1.mana.Value - 30 > player1.mana.Minimum)
                {
                    player1.SetPlayerAction(player1.fireballmove, 30);
                    SetupAnimation(player1);
                }
            }
            /*if (e.KeyCode == Keys.S && !player1.playingAction && !player1.goLeft && !player1.goRight)
            {
                player1.blocking = false;
                player1.Reset();
            }*/
            // player2
            if (e.KeyCode == Keys.U && !player2.playingAction && !player2.goLeft && !player2.goRight)
            {
                player2.SetPlayerAction(player2.punchLight, 2);
                SetupAnimation(player2);
            }
            if (e.KeyCode == Keys.I && !player2.playingAction && !player2.goLeft && !player2.goRight)
            {
                player2.SetPlayerAction(player2.punchStrong, 5);
                SetupAnimation(player2);
            }
            if (e.KeyCode == Keys.O && !player2.playingAction && !player2.goLeft && !player2.goRight && !player2.shotFireball)
            {
                if (player2.mana.Value - 30 > player2.mana.Minimum)
                {
                    player2.SetPlayerAction(player2.fireballmove, 30);
                    SetupAnimation(player2);
                }
            }
            /*if (e.KeyCode == Keys.K && !player2.playingAction && !player2.goLeft && !player2.goRight)
            {
                player2.blocking = false;
                player2.Reset();
            }*/
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(map.currentMap, new Point(0,0));
            e.Graphics.DrawImage(player1.currentMovement, new Point(player1.X,player1.Y));
            e.Graphics.DrawImage(player2.currentMovement, new Point(player2.X, player2.Y));

            if (player1.shotFireball)
                e.Graphics.DrawImage(player1.fireball, new Point(player1.fireballX, player1.fireballY));
            if (player2.shotFireball)
                e.Graphics.DrawImage(player2.fireball, new Point(player2.fireballX, player2.fireballY));
        }

        private void GamePlayTimer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
            ImageAnimator.UpdateFrames();
            MovePlayer();
            if (player1.health.Value == 0 || player2.health.Value == 0 || gameTime.time() == "00:00")
            {
                if (player1.health.Value == 0)
                    GameOver(player2);
                else if (player2.health.Value == 0)
                    GameOver(player1);
                else if (gameTime.time() == "00:00")
                {
                    if (player1.health.Value > player2.health.Value)
                        GameOver(player1);
                    else
                        GameOver(player2);
                }
            }

            player1.CheckPunchHit(player2);
            player2.CheckPunchHit(player1);

            if (player1.playingAction)
            {
                if (player1.num < player1.totalFrame)
                    player1.num += 0.5f; // Lower increment value makes it easy to check for collision
                else
                {
                    player1.Reset();
                    SetupAnimation(player1);
                }
            }
            if (player2.playingAction)
            {
                if (player2.num < player2.totalFrame)
                    player2.num += 0.5f; // Lower increment value makes it easy to check for collision
                else
                {
                    player2.Reset();
                    SetupAnimation(player2);
                }
            }
            // Fireball Instructions
            // Fireballs hit each other
            /*if (player1.shotFireball && player2.shotFireball)
                player1.CheckFireBallHit(player2);*/
            // player1
            if (player1.shotFireball)
            {
                player1.fireballX += 10;
                player1.CheckFireBallHit(player2);
            }
            // if (player1.fireballX > this.ClientSize.Width) player1.shotFireball = false;
            else if ((player1.num > player1.endFrame) && (player2.moveTime == 0) && (player1.actionStrength == 30))
                player1.ShootFireBall(OnFrameChangedHandler);
            // player2
            if (player2.shotFireball)
            {
                player2.fireballX -= 10;
                player2.CheckFireBallHit(player1);
            }
            // if (player2.fireballX < 0) player2.shotFireball = false;
            else if ((player2.num > player2.endFrame) && (player1.moveTime == 0) && (player2.actionStrength == 30))
                player2.ShootFireBall(OnFrameChangedHandler);

            // Hit Instructions (opponent animation)
            // When player1 makes a hit, move player2
            if (player2.moveTime > 0)
            {
                player2.moveTime--;
                if (player2.X + 10 < this.ClientSize.Width - player2.currentMovement.Width)
                    player2.X += 10;
                else
                    player2.X = this.ClientSize.Width - player2.currentMovement.Width;
                // add player2 damage animation
            }
            /*else if (player2.moveTime == 0)
            {
                player2.currentMovement = player2.standing;
                player2.moveTime = 0;
            }*/
            // When player2 makes a hit , move player1
            if (player1.moveTime > 0)
            {
                player1.moveTime--;
                if (player1.X - 10 > 0)
                    player1.X -= 10;
                else
                    player1.X = 0;
                // add player1 damage animation
            }
            /*else if (player1.moveTime == 0)
            {
                player1.currentMovement = player1.standing;
                player1.moveTime = 0;
            }*/

        }

        private void manaTimer_Tick(object sender, EventArgs e)
        {
            gameTime.decrement();
            time.Text = gameTime.time();
            if (player1.mana.Value + 2 <= player1.mana.Maximum)
                player1.mana.Value += 2;
            if (player2.mana.Value + 2 <= player2.mana.Maximum)
                player2.mana.Value += 2;
        }

        // Custom Functions
        private void SetupGround()
        { // Loads the images
            // For smooth animation
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            // Initiating players and map
            Player.windowWidth = this.ClientSize.Width;
            player1 = new Player(1, p1HealthBar, p1ManaBar);
            player2 = new Player(2, p2HealthBar, p2ManaBar);
            map = new Maps();
            gameTime = new Time("03","00");
            SetupAnimation(player1); SetupAnimation(player2);
        }

        private void SetupAnimation(Player player)
        { // Start the animation process or reload the animation
            ImageAnimator.Animate(player.currentMovement, this.OnFrameChangedHandler);
            // To calculate number of frames in a .gif
            FrameDimension dimensions = new FrameDimension(player.currentMovement.FrameDimensionsList[0]);
            player.totalFrame = player.currentMovement.GetFrameCount(dimensions);
            player.endFrame = player.totalFrame - 3; // the last 3 frames are used to reset the image
        }

        private void OnFrameChangedHandler(object sender, EventArgs e)
        { // for updating the image
            this.Invalidate();
        }

        private void MovePlayer()
        {
            // Move player1
            if (player1.goLeft)
            {
                if (player1.X > 0)
                    player1.X -= 5;
                
            } if (player1.goRight)
            {
                if (player1.X + player1.currentMovement.Width - 35 <= player2.X)
                    //((player1.X + player1.currentMovement.Width) < this.ClientSize.Width)
                    player1.X += 5;
            }
            // Move player2
            if (player2.goLeft)
            {
                if (player2.X >= player1.X + player1.currentMovement.Width - 35)
                    //player2.X > 0
                    player2.X -= 5;

            }
            if (player2.goRight)
            {
                if ((player2.X + player2.currentMovement.Width) < this.ClientSize.Width)
                    player2.X += 5;
            }
        }

        private void MovePlayerAnimation(Player player, string direction)
        {
            if (player.playerType == 1)
            {
                if (direction == "left")
                {
                    player.goLeft = true; player.currentMovement = player.backwards;
                }
                if (direction == "right")
                {
                    player.goRight = true; player.currentMovement = player.forwards;
                }
            }
            else if (player.playerType == 2)
            {
                if (direction == "left")
                {
                    player.goLeft = true; player.currentMovement = player.forwards;
                }
                if (direction == "right")
                {
                    player.goRight = true; player.currentMovement = player.backwards;
                }
            }
            player.directionPressed = true;
            player.playingAction = false;
            SetupAnimation(player);
        }

        private void GameOver(Player winner)
        {
            GamePlayTimer.Stop();
            manaTimer.Stop();
            winner.currentMovement = winner.standing;
            winner.X = 350; winner.Y = 150;
            GameOverScreen gos = new GameOverScreen(winner);
            gos.Show();
            this.Hide();
        }
    }
}
