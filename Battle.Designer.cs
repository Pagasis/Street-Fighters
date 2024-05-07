namespace Street_Fighters
{
    partial class Battle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Battle));
            this.GamePlayTimer = new System.Windows.Forms.Timer(this.components);
            this.p1HealthBar = new System.Windows.Forms.ProgressBar();
            this.p2HealthBar = new System.Windows.Forms.ProgressBar();
            this.p1ManaBar = new System.Windows.Forms.ProgressBar();
            this.p2ManaBar = new System.Windows.Forms.ProgressBar();
            this.manaTimer = new System.Windows.Forms.Timer(this.components);
            this.time = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GamePlayTimer
            // 
            this.GamePlayTimer.Enabled = true;
            this.GamePlayTimer.Interval = 20;
            this.GamePlayTimer.Tick += new System.EventHandler(this.GamePlayTimer_Tick);
            // 
            // p1HealthBar
            // 
            this.p1HealthBar.BackColor = System.Drawing.SystemColors.Info;
            this.p1HealthBar.ForeColor = System.Drawing.Color.Firebrick;
            this.p1HealthBar.Location = new System.Drawing.Point(12, 12);
            this.p1HealthBar.Maximum = 500;
            this.p1HealthBar.Name = "p1HealthBar";
            this.p1HealthBar.Size = new System.Drawing.Size(200, 25);
            this.p1HealthBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.p1HealthBar.TabIndex = 0;
            this.p1HealthBar.Value = 500;
            // 
            // p2HealthBar
            // 
            this.p2HealthBar.BackColor = System.Drawing.SystemColors.Info;
            this.p2HealthBar.ForeColor = System.Drawing.Color.Firebrick;
            this.p2HealthBar.Location = new System.Drawing.Point(572, 12);
            this.p2HealthBar.Maximum = 500;
            this.p2HealthBar.Name = "p2HealthBar";
            this.p2HealthBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.p2HealthBar.RightToLeftLayout = true;
            this.p2HealthBar.Size = new System.Drawing.Size(200, 25);
            this.p2HealthBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.p2HealthBar.TabIndex = 1;
            this.p2HealthBar.Value = 500;
            // 
            // p1ManaBar
            // 
            this.p1ManaBar.BackColor = System.Drawing.SystemColors.Info;
            this.p1ManaBar.ForeColor = System.Drawing.Color.DodgerBlue;
            this.p1ManaBar.Location = new System.Drawing.Point(12, 44);
            this.p1ManaBar.Maximum = 60;
            this.p1ManaBar.Name = "p1ManaBar";
            this.p1ManaBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.p1ManaBar.Size = new System.Drawing.Size(125, 15);
            this.p1ManaBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.p1ManaBar.TabIndex = 2;
            this.p1ManaBar.Value = 20;
            // 
            // p2ManaBar
            // 
            this.p2ManaBar.BackColor = System.Drawing.SystemColors.Info;
            this.p2ManaBar.ForeColor = System.Drawing.Color.DodgerBlue;
            this.p2ManaBar.Location = new System.Drawing.Point(647, 44);
            this.p2ManaBar.Maximum = 60;
            this.p2ManaBar.Name = "p2ManaBar";
            this.p2ManaBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.p2ManaBar.RightToLeftLayout = true;
            this.p2ManaBar.Size = new System.Drawing.Size(125, 15);
            this.p2ManaBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.p2ManaBar.TabIndex = 3;
            this.p2ManaBar.Value = 20;
            // 
            // manaTimer
            // 
            this.manaTimer.Enabled = true;
            this.manaTimer.Interval = 1000;
            this.manaTimer.Tick += new System.EventHandler(this.manaTimer_Tick);
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.BackColor = System.Drawing.Color.Transparent;
            this.time.Font = new System.Drawing.Font("Unispace", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time.ForeColor = System.Drawing.Color.MidnightBlue;
            this.time.Location = new System.Drawing.Point(315, 12);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(170, 58);
            this.time.TabIndex = 4;
            this.time.Text = "03:00";
            // 
            // Battle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.time);
            this.Controls.Add(this.p2ManaBar);
            this.Controls.Add(this.p1ManaBar);
            this.Controls.Add(this.p2HealthBar);
            this.Controls.Add(this.p1HealthBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Battle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Battle_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer GamePlayTimer;
        private System.Windows.Forms.ProgressBar p1HealthBar;
        private System.Windows.Forms.ProgressBar p2HealthBar;
        private System.Windows.Forms.ProgressBar p1ManaBar;
        private System.Windows.Forms.ProgressBar p2ManaBar;
        private System.Windows.Forms.Timer manaTimer;
        private System.Windows.Forms.Label time;
    }
}

