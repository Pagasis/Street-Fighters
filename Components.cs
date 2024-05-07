using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Street_Fighters
{
    public class Player
    {
        public int playerType; // decides player direction
        public int X, Y = 300, fireballX, fireballY;
        public int actionStrength, moveTime;
        public ProgressBar health, mana;
        public Image currentMovement, standing, backwards, forwards, punchLight, punchStrong, block, fireballmove, fireball;
        public bool goLeft, goRight, playingAction, blocking, shotFireball, directionPressed;
        public int totalFrame, endFrame;
        public float num = 0f;
        public static int windowWidth;
        public Player(int playerType, ProgressBar healthBar, ProgressBar manaBar)
        {
            this.playerType = playerType;

            // Actions
            standing = Image.FromFile($"SFImages\\standing{playerType}.gif");
            backwards = Image.FromFile($"SFImages\\backwards{playerType}.gif");
            forwards = Image.FromFile($"SFImages\\forwards{playerType}.gif");
            punchLight = Image.FromFile($"SFImages\\punchLight{playerType}.gif");
            punchStrong = Image.FromFile($"SFImages\\punchStrong{playerType}.gif");
            block = Image.FromFile($"SFImages\\block{playerType}.png");
            fireballmove = Image.FromFile($"SFImages\\fireballmove{playerType}.gif");
            fireball = Image.FromFile($"SFImages\\fireball{playerType}.gif");
            health = healthBar;
            mana = manaBar;
            currentMovement = standing;
            X = (playerType == 1) ? 100 : (windowWidth - currentMovement.Width - 100);
            blocking = false;
        }

        public void Reset()
        {
            currentMovement = standing;
            num = 0;
            // actionStrength = 0;
            playingAction = false;
        }

        public void SetPlayerAction(Image movement, int strength)
        {
            if (strength == -1)
                blocking = true;
            else
                actionStrength = strength;
            currentMovement = movement;
            playingAction = true;
        }

        public void UpdateHealth(int damage) {
            if (health.Value - damage >= 0)
                health.Value -= damage;
            else
                health.Value = 0;
        }

        public void ShootFireBall(EventHandler OnFrameChangedHandler)
        {
            ImageAnimator.Animate(fireball, OnFrameChangedHandler);
            fireballX = X + ((playerType == 2) ? 50 : (currentMovement.Width - 50));
            fireballY = Y - 33;
            shotFireball = true;
            mana.Value -= actionStrength;
        }
        private bool DetectCollision(string action, Player opponent)
        {
            if (action.Equals("fireball"))
            {
                if (fireballX + fireball.Width <= opponent.X || fireballX >= opponent.X + opponent.currentMovement.Width || fireballY + fireball.Height <= opponent.Y || fireballY >= opponent.Y + opponent.currentMovement.Height)
                    return false;
                /*else if (fireballX + fireball.Width >= opponent.fireballX && fireballX <= opponent.fireballX + opponent.fireball.Width)
                    return true;*/
                else
                    return true;
            }
            else
            {
                if (X + this.currentMovement.Width <= opponent.X || X >= opponent.X + opponent.currentMovement.Width || Y + this.currentMovement.Height <= opponent.Y || Y >= opponent.Y + opponent.currentMovement.Height)
                    return false;
                else
                    return true;
            }
        }
        public void CheckPunchHit(Player opponent)
        {
            bool collision = DetectCollision("punch", opponent);
            if (collision && playingAction && num > endFrame && !shotFireball)
            {
                opponent.moveTime = actionStrength;
                opponent.UpdateHealth(actionStrength);
                // MessageBox.Show(opponent.moveTime.ToString());
            }
        }
        public void CheckFireBallHit(Player opponent)
        {
            bool collision = DetectCollision("fireball", opponent);
            if (collision)
            {
                opponent.moveTime = actionStrength;
                shotFireball = false;
                fireballX = X;
                opponent.UpdateHealth(30); // + ((opponent.blocking) ? -2 : 0)
                // MessageBox.Show(opponent.moveTime.ToString());
            }
        }
    }

    public class Maps
    {
        public int mapNumber = 0;
        public List<string> maps;
        public Image currentMap;

        public Maps() {
            // Get the background image filenames
            maps = Directory.GetFiles("SFImages\\background", "*.jpg").ToList();
            // Set the first image as background
            currentMap = Image.FromFile(maps[mapNumber]);
        }
    }

    public class Time
    {
        public string minute, second;
        public Time(string minute, string second)
        { 
            this.minute = minute;
            this.second = second;
        }
        public void decrement()
        {
            int sec = int.Parse(second);
            sec--;
            if (sec < 0)
            {
                int min = int.Parse(minute);
                min--;
                minute = "0"+min.ToString();
                sec = 59;
            }
            if (sec.ToString().Length == 1)
                second = "0"+sec.ToString();
            else
                second = sec.ToString();
        }
        public string time()
        {
            return minute + ":" + second;
        }
    }
}