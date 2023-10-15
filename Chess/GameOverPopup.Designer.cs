namespace ChessClientGUI
{
    partial class GameOverPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameOverPopup));
            bigLabel = new Label();
            smallLabel = new Label();
            pictureBox1 = new PictureBox();
            playAgain = new Button();
            mainMenu = new Button();
            quit = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // bigLabel
            // 
            bigLabel.Font = new Font("Imprint MT Shadow", 48F, FontStyle.Regular, GraphicsUnit.Point);
            bigLabel.Location = new Point(110, 28);
            bigLabel.Name = "bigLabel";
            bigLabel.Size = new Size(582, 94);
            bigLabel.TabIndex = 0;
            bigLabel.Text = "Checkmate!";
            bigLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // smallLabel
            // 
            smallLabel.AutoSize = true;
            smallLabel.Font = new Font("Bell MT", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            smallLabel.Location = new Point(283, 159);
            smallLabel.Name = "smallLabel";
            smallLabel.Size = new Size(236, 39);
            smallLabel.TabIndex = 1;
            smallLabel.Text = "White has won!";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.line;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(81, 112);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(640, 40);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // playAgain
            // 
            playAgain.Font = new Font("Bell MT", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            playAgain.Location = new Point(102, 236);
            playAgain.Margin = new Padding(25, 3, 25, 3);
            playAgain.Name = "playAgain";
            playAgain.Size = new Size(166, 51);
            playAgain.TabIndex = 3;
            playAgain.Text = "Play again";
            playAgain.UseVisualStyleBackColor = true;
            playAgain.Click += Restart;
            // 
            // mainMenu
            // 
            mainMenu.Font = new Font("Bell MT", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            mainMenu.Location = new Point(318, 236);
            mainMenu.Margin = new Padding(25, 3, 25, 3);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new Size(166, 51);
            mainMenu.TabIndex = 4;
            mainMenu.Text = "Main menu";
            mainMenu.UseVisualStyleBackColor = true;
            mainMenu.Click += ReturnToMenu;
            // 
            // quit
            // 
            quit.Font = new Font("Bell MT", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            quit.Location = new Point(534, 236);
            quit.Margin = new Padding(25, 3, 25, 3);
            quit.Name = "quit";
            quit.Size = new Size(166, 51);
            quit.TabIndex = 5;
            quit.Text = "Quit";
            quit.UseVisualStyleBackColor = true;
            quit.Click += Quit;
            // 
            // GameOverPopup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(802, 333);
            ControlBox = false;
            Controls.Add(quit);
            Controls.Add(mainMenu);
            Controls.Add(playAgain);
            Controls.Add(pictureBox1);
            Controls.Add(smallLabel);
            Controls.Add(bigLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GameOverPopup";
            RightToLeftLayout = true;
            Text = "Chess";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label bigLabel;
        private Label smallLabel;
        private PictureBox pictureBox1;
        private Button playAgain;
        private Button mainMenu;
        private Button quit;
    }
}