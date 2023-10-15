namespace Chess
{
    partial class ChessClient
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChessClient));
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            mainMenu = new GroupBox();
            multiplayerSettings = new GroupBox();
            pictureBox3 = new PictureBox();
            fullScreenBox = new CheckBox();
            showMovesBox = new CheckBox();
            flipBoardBox = new CheckBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            gray = new RadioButton();
            green = new RadioButton();
            wood = new RadioButton();
            marble = new RadioButton();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            startMultiplayerGame = new Button();
            backButton = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            mainMenu.SuspendLayout();
            multiplayerSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Imprint MT Shadow", 48F, FontStyle.Underline, GraphicsUnit.Point);
            label1.Location = new Point(82, 41);
            label1.Name = "label1";
            label1.Size = new Size(474, 94);
            label1.TabIndex = 0;
            label1.Text = "CHESS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.DarkGray;
            button1.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(82, 179);
            button1.Name = "button1";
            button1.Size = new Size(474, 75);
            button1.TabIndex = 1;
            button1.Text = "Play against computer";
            button1.UseVisualStyleBackColor = false;
            button1.Click += ShowSinglePlayerSettings;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.BackColor = Color.DarkGray;
            button2.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(82, 308);
            button2.Name = "button2";
            button2.Size = new Size(474, 75);
            button2.TabIndex = 2;
            button2.Text = "Play local multiplayer";
            button2.UseVisualStyleBackColor = false;
            button2.Click += ShowMultiplayerSettings;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = ChessClientGUI.Properties.Resources.blackPillar3;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Dock = DockStyle.Left;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(175, 553);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = ChessClientGUI.Properties.Resources.blackPillar3;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Dock = DockStyle.Right;
            pictureBox2.Location = new Point(849, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(175, 553);
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // mainMenu
            // 
            mainMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mainMenu.Controls.Add(label1);
            mainMenu.Controls.Add(button1);
            mainMenu.Controls.Add(button2);
            mainMenu.Location = new Point(193, 44);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new Size(639, 465);
            mainMenu.TabIndex = 5;
            mainMenu.TabStop = false;
            // 
            // multiplayerSettings
            // 
            multiplayerSettings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            multiplayerSettings.Controls.Add(pictureBox3);
            multiplayerSettings.Controls.Add(fullScreenBox);
            multiplayerSettings.Controls.Add(showMovesBox);
            multiplayerSettings.Controls.Add(flipBoardBox);
            multiplayerSettings.Controls.Add(flowLayoutPanel1);
            multiplayerSettings.Controls.Add(label6);
            multiplayerSettings.Controls.Add(label5);
            multiplayerSettings.Controls.Add(label4);
            multiplayerSettings.Controls.Add(label3);
            multiplayerSettings.Controls.Add(startMultiplayerGame);
            multiplayerSettings.Controls.Add(backButton);
            multiplayerSettings.Controls.Add(label2);
            multiplayerSettings.Location = new Point(199, 28);
            multiplayerSettings.Name = "multiplayerSettings";
            multiplayerSettings.Size = new Size(627, 516);
            multiplayerSettings.TabIndex = 3;
            multiplayerSettings.TabStop = false;
            multiplayerSettings.Visible = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.BackgroundImage = ChessClientGUI.Properties.Resources.line;
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(29, 77);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(568, 41);
            pictureBox3.TabIndex = 11;
            pictureBox3.TabStop = false;
            // 
            // fullScreenBox
            // 
            fullScreenBox.Appearance = Appearance.Button;
            fullScreenBox.BackgroundImageLayout = ImageLayout.Zoom;
            fullScreenBox.Location = new Point(493, 304);
            fullScreenBox.Name = "fullScreenBox";
            fullScreenBox.Size = new Size(30, 30);
            fullScreenBox.TabIndex = 10;
            fullScreenBox.UseVisualStyleBackColor = true;
            fullScreenBox.CheckedChanged += ToggleFullScreen;
            // 
            // showMovesBox
            // 
            showMovesBox.Appearance = Appearance.Button;
            showMovesBox.BackgroundImageLayout = ImageLayout.Zoom;
            showMovesBox.Location = new Point(493, 244);
            showMovesBox.Name = "showMovesBox";
            showMovesBox.Size = new Size(30, 30);
            showMovesBox.TabIndex = 9;
            showMovesBox.UseVisualStyleBackColor = true;
            showMovesBox.CheckedChanged += ToggleShowMoves;
            // 
            // flipBoardBox
            // 
            flipBoardBox.Appearance = Appearance.Button;
            flipBoardBox.BackgroundImageLayout = ImageLayout.Zoom;
            flipBoardBox.Location = new Point(493, 184);
            flipBoardBox.Name = "flipBoardBox";
            flipBoardBox.Size = new Size(30, 30);
            flipBoardBox.TabIndex = 8;
            flipBoardBox.UseVisualStyleBackColor = true;
            flipBoardBox.CheckedChanged += ToggleBoardFlip;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.Controls.Add(gray);
            flowLayoutPanel1.Controls.Add(green);
            flowLayoutPanel1.Controls.Add(wood);
            flowLayoutPanel1.Controls.Add(marble);
            flowLayoutPanel1.Location = new Point(205, 126);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(321, 31);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // gray
            // 
            gray.Appearance = Appearance.Button;
            gray.AutoSize = true;
            gray.Checked = true;
            gray.Font = new Font("Bell MT", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gray.Location = new Point(1, 1);
            gray.Margin = new Padding(1);
            gray.Name = "gray";
            gray.Size = new Size(94, 29);
            gray.TabIndex = 0;
            gray.TabStop = true;
            gray.Text = "Simple gray";
            gray.UseVisualStyleBackColor = true;
            gray.CheckedChanged += ChangeTheme;
            // 
            // green
            // 
            green.Appearance = Appearance.Button;
            green.AutoSize = true;
            green.Font = new Font("Bell MT", 9F, FontStyle.Regular, GraphicsUnit.Point);
            green.Location = new Point(97, 1);
            green.Margin = new Padding(1);
            green.Name = "green";
            green.Size = new Size(99, 29);
            green.TabIndex = 1;
            green.Text = "Simple green";
            green.UseVisualStyleBackColor = true;
            green.CheckedChanged += ChangeTheme;
            // 
            // wood
            // 
            wood.Appearance = Appearance.Button;
            wood.AutoSize = true;
            wood.Font = new Font("Bell MT", 9F, FontStyle.Regular, GraphicsUnit.Point);
            wood.Location = new Point(198, 1);
            wood.Margin = new Padding(1);
            wood.Name = "wood";
            wood.Size = new Size(56, 29);
            wood.TabIndex = 2;
            wood.Text = "Wood";
            wood.UseVisualStyleBackColor = true;
            wood.CheckedChanged += ChangeTheme;
            // 
            // marble
            // 
            marble.Appearance = Appearance.Button;
            marble.AutoSize = true;
            marble.Font = new Font("Bell MT", 9F, FontStyle.Regular, GraphicsUnit.Point);
            marble.Location = new Point(256, 1);
            marble.Margin = new Padding(1);
            marble.Name = "marble";
            marble.Size = new Size(64, 29);
            marble.TabIndex = 3;
            marble.Text = "Marble";
            marble.UseVisualStyleBackColor = true;
            marble.CheckedChanged += ChangeTheme;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(103, 304);
            label6.Name = "label6";
            label6.Size = new Size(395, 34);
            label6.TabIndex = 6;
            label6.Text = "Full Screen . . . . . . . . . . . . . . . .";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(103, 244);
            label5.Name = "label5";
            label5.Size = new Size(402, 34);
            label5.TabIndex = 5;
            label5.Text = "Hide available moves . . . . . . . . ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(103, 184);
            label4.Name = "label4";
            label4.Size = new Size(406, 34);
            label4.TabIndex = 4;
            label4.Text = "Flip board on black's turn . . . . .";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(100, 124);
            label3.Name = "label3";
            label3.Size = new Size(102, 34);
            label3.TabIndex = 3;
            label3.Text = "Theme";
            // 
            // startMultiplayerGame
            // 
            startMultiplayerGame.BackColor = Color.DarkGray;
            startMultiplayerGame.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            startMultiplayerGame.Location = new Point(179, 364);
            startMultiplayerGame.Name = "startMultiplayerGame";
            startMultiplayerGame.Size = new Size(269, 67);
            startMultiplayerGame.TabIndex = 2;
            startMultiplayerGame.Text = "Start Game";
            startMultiplayerGame.UseVisualStyleBackColor = false;
            startMultiplayerGame.Click += StartMultiplayerGame;
            // 
            // backButton
            // 
            backButton.BackColor = Color.White;
            backButton.Font = new Font("Bell MT", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            backButton.Location = new Point(229, 437);
            backButton.Name = "backButton";
            backButton.Size = new Size(168, 45);
            backButton.TabIndex = 1;
            backButton.Text = "Back to menu";
            backButton.UseVisualStyleBackColor = false;
            backButton.Click += returnToMenu;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Imprint MT Shadow", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(65, 3);
            label2.Name = "label2";
            label2.Size = new Size(497, 71);
            label2.TabIndex = 0;
            label2.Text = "Multiplayer Game";
            // 
            // ChessClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1024, 553);
            Controls.Add(multiplayerSettings);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(mainMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ChessClient";
            Text = "Chess";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            mainMenu.ResumeLayout(false);
            multiplayerSettings.ResumeLayout(false);
            multiplayerSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private GroupBox mainMenu;
        private GroupBox multiplayerSettings;
        private Button backButton;
        private Label label2;
        private Button startMultiplayerGame;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private FlowLayoutPanel flowLayoutPanel1;
        private RadioButton gray;
        private RadioButton green;
        private RadioButton wood;
        private RadioButton marble;
        private CheckBox fullScreenBox;
        private CheckBox showMovesBox;
        private CheckBox flipBoardBox;
        private PictureBox pictureBox3;
    }
}