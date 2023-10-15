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
            singlePlayerSettings = new GroupBox();
            label12 = new Label();
            pictureBox4 = new PictureBox();
            fullScreen2 = new CheckBox();
            showMoves2 = new CheckBox();
            flowLayoutPanel4 = new FlowLayoutPanel();
            white = new RadioButton();
            black = new RadioButton();
            flowLayoutPanel2 = new FlowLayoutPanel();
            gray2 = new RadioButton();
            green2 = new RadioButton();
            wood2 = new RadioButton();
            marble2 = new RadioButton();
            flowLayoutPanel3 = new FlowLayoutPanel();
            skill1 = new RadioButton();
            skill2 = new RadioButton();
            skill3 = new RadioButton();
            skill4 = new RadioButton();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            button3 = new Button();
            button4 = new Button();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            mainMenu.SuspendLayout();
            multiplayerSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            singlePlayerSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
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
            multiplayerSettings.Location = new Point(199, 25);
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
            // singlePlayerSettings
            // 
            singlePlayerSettings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            singlePlayerSettings.Controls.Add(label12);
            singlePlayerSettings.Controls.Add(pictureBox4);
            singlePlayerSettings.Controls.Add(fullScreen2);
            singlePlayerSettings.Controls.Add(showMoves2);
            singlePlayerSettings.Controls.Add(flowLayoutPanel4);
            singlePlayerSettings.Controls.Add(flowLayoutPanel2);
            singlePlayerSettings.Controls.Add(flowLayoutPanel3);
            singlePlayerSettings.Controls.Add(label7);
            singlePlayerSettings.Controls.Add(label8);
            singlePlayerSettings.Controls.Add(label9);
            singlePlayerSettings.Controls.Add(label10);
            singlePlayerSettings.Controls.Add(button3);
            singlePlayerSettings.Controls.Add(button4);
            singlePlayerSettings.Controls.Add(label11);
            singlePlayerSettings.Location = new Point(199, 12);
            singlePlayerSettings.Name = "singlePlayerSettings";
            singlePlayerSettings.Size = new Size(627, 516);
            singlePlayerSettings.TabIndex = 12;
            singlePlayerSettings.TabStop = false;
            singlePlayerSettings.Visible = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(90, 233);
            label12.Name = "label12";
            label12.Size = new Size(384, 34);
            label12.TabIndex = 12;
            label12.Text = "Color . . . . . . . . . . . . . . . . . . . .";
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.BackgroundImage = ChessClientGUI.Properties.Resources.line;
            pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox4.Location = new Point(29, 77);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(568, 41);
            pictureBox4.TabIndex = 11;
            pictureBox4.TabStop = false;
            // 
            // fullScreen2
            // 
            fullScreen2.Appearance = Appearance.Button;
            fullScreen2.BackgroundImageLayout = ImageLayout.Zoom;
            fullScreen2.Location = new Point(540, 333);
            fullScreen2.Name = "fullScreen2";
            fullScreen2.Size = new Size(30, 30);
            fullScreen2.TabIndex = 10;
            fullScreen2.UseVisualStyleBackColor = true;
            fullScreen2.CheckedChanged += ToggleFullScreen;
            // 
            // showMoves2
            // 
            showMoves2.Appearance = Appearance.Button;
            showMoves2.BackgroundImageLayout = ImageLayout.Zoom;
            showMoves2.Location = new Point(540, 283);
            showMoves2.Name = "showMoves2";
            showMoves2.Size = new Size(30, 30);
            showMoves2.TabIndex = 9;
            showMoves2.UseVisualStyleBackColor = true;
            showMoves2.CheckedChanged += ToggleShowMoves;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.AutoSize = true;
            flowLayoutPanel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel4.Controls.Add(white);
            flowLayoutPanel4.Controls.Add(black);
            flowLayoutPanel4.Location = new Point(485, 229);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(84, 42);
            flowLayoutPanel4.TabIndex = 9;
            // 
            // white
            // 
            white.Appearance = Appearance.Button;
            white.BackgroundImage = ChessClientGUI.Properties.Resources.white_king;
            white.BackgroundImageLayout = ImageLayout.Stretch;
            white.Checked = true;
            white.Font = new Font("Bell MT", 9F, FontStyle.Regular, GraphicsUnit.Point);
            white.Location = new Point(1, 1);
            white.Margin = new Padding(1);
            white.Name = "white";
            white.Size = new Size(40, 40);
            white.TabIndex = 0;
            white.TabStop = true;
            white.UseVisualStyleBackColor = true;
            white.CheckedChanged += ColorChanged;
            // 
            // black
            // 
            black.Appearance = Appearance.Button;
            black.BackgroundImage = ChessClientGUI.Properties.Resources.black_king;
            black.BackgroundImageLayout = ImageLayout.Stretch;
            black.Font = new Font("Bell MT", 9F, FontStyle.Regular, GraphicsUnit.Point);
            black.Location = new Point(43, 1);
            black.Margin = new Padding(1);
            black.Name = "black";
            black.Size = new Size(40, 40);
            black.TabIndex = 1;
            black.UseVisualStyleBackColor = true;
            black.CheckedChanged += ColorChanged;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(gray2);
            flowLayoutPanel2.Controls.Add(green2);
            flowLayoutPanel2.Controls.Add(wood2);
            flowLayoutPanel2.Controls.Add(marble2);
            flowLayoutPanel2.Location = new Point(249, 138);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(321, 31);
            flowLayoutPanel2.TabIndex = 7;
            // 
            // gray2
            // 
            gray2.Appearance = Appearance.Button;
            gray2.AutoSize = true;
            gray2.Checked = true;
            gray2.Font = new Font("Bell MT", 9F, FontStyle.Regular, GraphicsUnit.Point);
            gray2.Location = new Point(1, 1);
            gray2.Margin = new Padding(1);
            gray2.Name = "gray2";
            gray2.Size = new Size(94, 29);
            gray2.TabIndex = 0;
            gray2.TabStop = true;
            gray2.Text = "Simple gray";
            gray2.UseVisualStyleBackColor = true;
            gray2.CheckedChanged += ChangeTheme;
            // 
            // green2
            // 
            green2.Appearance = Appearance.Button;
            green2.AutoSize = true;
            green2.Font = new Font("Bell MT", 9F, FontStyle.Regular, GraphicsUnit.Point);
            green2.Location = new Point(97, 1);
            green2.Margin = new Padding(1);
            green2.Name = "green2";
            green2.Size = new Size(99, 29);
            green2.TabIndex = 1;
            green2.Text = "Simple green";
            green2.UseVisualStyleBackColor = true;
            green2.CheckedChanged += ChangeTheme;
            // 
            // wood2
            // 
            wood2.Appearance = Appearance.Button;
            wood2.AutoSize = true;
            wood2.Font = new Font("Bell MT", 9F, FontStyle.Regular, GraphicsUnit.Point);
            wood2.Location = new Point(198, 1);
            wood2.Margin = new Padding(1);
            wood2.Name = "wood2";
            wood2.Size = new Size(56, 29);
            wood2.TabIndex = 2;
            wood2.Text = "Wood";
            wood2.UseVisualStyleBackColor = true;
            wood2.CheckedChanged += ChangeTheme;
            // 
            // marble2
            // 
            marble2.Appearance = Appearance.Button;
            marble2.AutoSize = true;
            marble2.Font = new Font("Bell MT", 9F, FontStyle.Regular, GraphicsUnit.Point);
            marble2.Location = new Point(256, 1);
            marble2.Margin = new Padding(1);
            marble2.Name = "marble2";
            marble2.Size = new Size(64, 29);
            marble2.TabIndex = 3;
            marble2.Text = "Marble";
            marble2.UseVisualStyleBackColor = true;
            marble2.CheckedChanged += ChangeTheme;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.AutoSize = true;
            flowLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel3.Controls.Add(skill1);
            flowLayoutPanel3.Controls.Add(skill2);
            flowLayoutPanel3.Controls.Add(skill3);
            flowLayoutPanel3.Controls.Add(skill4);
            flowLayoutPanel3.Location = new Point(226, 183);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(344, 31);
            flowLayoutPanel3.TabIndex = 8;
            // 
            // skill1
            // 
            skill1.Appearance = Appearance.Button;
            skill1.AutoSize = true;
            skill1.Checked = true;
            skill1.Font = new Font("Bell MT", 9F, FontStyle.Regular, GraphicsUnit.Point);
            skill1.Location = new Point(1, 1);
            skill1.Margin = new Padding(1);
            skill1.Name = "skill1";
            skill1.Size = new Size(74, 29);
            skill1.TabIndex = 0;
            skill1.TabStop = true;
            skill1.Text = "Beginner";
            skill1.UseVisualStyleBackColor = true;
            skill1.CheckedChanged += DifficultyChanged;
            // 
            // skill2
            // 
            skill2.Appearance = Appearance.Button;
            skill2.AutoSize = true;
            skill2.Font = new Font("Bell MT", 9F, FontStyle.Regular, GraphicsUnit.Point);
            skill2.Location = new Point(77, 1);
            skill2.Margin = new Padding(1);
            skill2.Name = "skill2";
            skill2.Size = new Size(98, 29);
            skill2.TabIndex = 1;
            skill2.Text = "Intermediate";
            skill2.UseVisualStyleBackColor = true;
            skill2.CheckedChanged += DifficultyChanged;
            // 
            // skill3
            // 
            skill3.Appearance = Appearance.Button;
            skill3.AutoSize = true;
            skill3.Font = new Font("Bell MT", 9F, FontStyle.Regular, GraphicsUnit.Point);
            skill3.Location = new Point(177, 1);
            skill3.Margin = new Padding(1);
            skill3.Name = "skill3";
            skill3.Size = new Size(62, 29);
            skill3.TabIndex = 2;
            skill3.Text = "Expert";
            skill3.UseVisualStyleBackColor = true;
            skill3.CheckedChanged += DifficultyChanged;
            // 
            // skill4
            // 
            skill4.Appearance = Appearance.Button;
            skill4.AutoSize = true;
            skill4.Font = new Font("Bell MT", 9F, FontStyle.Regular, GraphicsUnit.Point);
            skill4.Location = new Point(241, 1);
            skill4.Margin = new Padding(1);
            skill4.Name = "skill4";
            skill4.Size = new Size(102, 29);
            skill4.TabIndex = 3;
            skill4.Text = "Grandmaster";
            skill4.UseVisualStyleBackColor = true;
            skill4.CheckedChanged += DifficultyChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(90, 333);
            label7.Name = "label7";
            label7.Size = new Size(455, 34);
            label7.TabIndex = 6;
            label7.Text = "Full Screen . . . . . . . . . . . . . . . . . . . .";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(90, 283);
            label8.Name = "label8";
            label8.Size = new Size(462, 34);
            label8.TabIndex = 5;
            label8.Text = "Hide available moves . . . . . . . . . . . . ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(90, 183);
            label9.Name = "label9";
            label9.Size = new Size(130, 34);
            label9.TabIndex = 4;
            label9.Text = "Difficulty";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(90, 138);
            label10.Name = "label10";
            label10.Size = new Size(162, 34);
            label10.TabIndex = 3;
            label10.Text = "Theme . . . .";
            // 
            // button3
            // 
            button3.BackColor = Color.DarkGray;
            button3.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(179, 386);
            button3.Name = "button3";
            button3.Size = new Size(269, 67);
            button3.TabIndex = 2;
            button3.Text = "Start Game";
            button3.UseVisualStyleBackColor = false;
            button3.Click += StartSinglePlayerGame;
            // 
            // button4
            // 
            button4.BackColor = Color.White;
            button4.Font = new Font("Bell MT", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(229, 459);
            button4.Name = "button4";
            button4.Size = new Size(168, 45);
            button4.TabIndex = 1;
            button4.Text = "Back to menu";
            button4.UseVisualStyleBackColor = false;
            button4.Click += returnToMenu;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Imprint MT Shadow", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(44, 3);
            label11.Name = "label11";
            label11.Size = new Size(539, 71);
            label11.TabIndex = 0;
            label11.Text = "Single Player Game";
            // 
            // ChessClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1024, 553);
            Controls.Add(singlePlayerSettings);
            Controls.Add(multiplayerSettings);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(mainMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
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
            singlePlayerSettings.ResumeLayout(false);
            singlePlayerSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
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
        private GroupBox singlePlayerSettings;
        private PictureBox pictureBox4;
        private CheckBox fullScreen2;
        private CheckBox showMoves2;
        private FlowLayoutPanel flowLayoutPanel2;
        private RadioButton gray2;
        private RadioButton green2;
        private RadioButton wood2;
        private RadioButton marble2;
        private FlowLayoutPanel flowLayoutPanel3;
        private RadioButton skill1;
        private RadioButton skill2;
        private RadioButton skill3;
        private RadioButton skill4;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button button3;
        private Button button4;
        private Label label11;
        private Label label12;
        private FlowLayoutPanel flowLayoutPanel4;
        private RadioButton white;
        private RadioButton black;
    }
}