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
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            singlePlayerSettings = new Panel();
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
            mainMenu = new Panel();
            button5 = new Button();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            multiplayerSettings = new Panel();
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
            credits = new Panel();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            text = new TextBox();
            pictureBox5 = new PictureBox();
            button7 = new Button();
            label17 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            singlePlayerSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            mainMenu.SuspendLayout();
            multiplayerSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            credits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
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
            // singlePlayerSettings
            // 
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
            singlePlayerSettings.TabIndex = 13;
            singlePlayerSettings.Visible = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(90, 238);
            label12.Name = "label12";
            label12.Size = new Size(384, 34);
            label12.TabIndex = 26;
            label12.Text = "Color . . . . . . . . . . . . . . . . . . . .";
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.BackgroundImage = ChessClientGUI.Properties.Resources.line;
            pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox4.Location = new Point(29, 82);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(568, 41);
            pictureBox4.TabIndex = 25;
            pictureBox4.TabStop = false;
            // 
            // fullScreen2
            // 
            fullScreen2.Appearance = Appearance.Button;
            fullScreen2.BackgroundImageLayout = ImageLayout.Zoom;
            fullScreen2.Location = new Point(540, 338);
            fullScreen2.Name = "fullScreen2";
            fullScreen2.Size = new Size(30, 30);
            fullScreen2.TabIndex = 24;
            fullScreen2.UseVisualStyleBackColor = true;
            fullScreen2.CheckedChanged += ToggleFullScreen;
            // 
            // showMoves2
            // 
            showMoves2.Appearance = Appearance.Button;
            showMoves2.BackgroundImageLayout = ImageLayout.Zoom;
            showMoves2.Location = new Point(540, 288);
            showMoves2.Name = "showMoves2";
            showMoves2.Size = new Size(30, 30);
            showMoves2.TabIndex = 22;
            showMoves2.UseVisualStyleBackColor = true;
            showMoves2.CheckedChanged += ToggleShowMoves;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.AutoSize = true;
            flowLayoutPanel4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel4.Controls.Add(white);
            flowLayoutPanel4.Controls.Add(black);
            flowLayoutPanel4.Location = new Point(485, 234);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(84, 42);
            flowLayoutPanel4.TabIndex = 23;
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
            flowLayoutPanel2.Location = new Point(249, 143);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(321, 31);
            flowLayoutPanel2.TabIndex = 20;
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
            flowLayoutPanel3.Location = new Point(226, 188);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(344, 31);
            flowLayoutPanel3.TabIndex = 21;
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
            label7.Location = new Point(90, 338);
            label7.Name = "label7";
            label7.Size = new Size(455, 34);
            label7.TabIndex = 19;
            label7.Text = "Full Screen . . . . . . . . . . . . . . . . . . . .";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(90, 288);
            label8.Name = "label8";
            label8.Size = new Size(462, 34);
            label8.TabIndex = 18;
            label8.Text = "Hide available moves . . . . . . . . . . . . ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(90, 188);
            label9.Name = "label9";
            label9.Size = new Size(130, 34);
            label9.TabIndex = 17;
            label9.Text = "Difficulty";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(90, 143);
            label10.Name = "label10";
            label10.Size = new Size(162, 34);
            label10.TabIndex = 16;
            label10.Text = "Theme . . . .";
            // 
            // button3
            // 
            button3.BackColor = Color.Brown;
            button3.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(179, 391);
            button3.Name = "button3";
            button3.Size = new Size(269, 67);
            button3.TabIndex = 15;
            button3.Text = "Start Game";
            button3.UseVisualStyleBackColor = false;
            button3.Click += StartSinglePlayerGame;
            // 
            // button4
            // 
            button4.BackColor = Color.White;
            button4.Font = new Font("Bell MT", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(229, 464);
            button4.Name = "button4";
            button4.Size = new Size(168, 45);
            button4.TabIndex = 14;
            button4.Text = "Back to menu";
            button4.UseVisualStyleBackColor = false;
            button4.Click += returnToMenu;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Imprint MT Shadow", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(44, 8);
            label11.Name = "label11";
            label11.Size = new Size(539, 71);
            label11.TabIndex = 13;
            label11.Text = "Single Player Game";
            // 
            // mainMenu
            // 
            mainMenu.Controls.Add(button5);
            mainMenu.Controls.Add(label1);
            mainMenu.Controls.Add(button1);
            mainMenu.Controls.Add(button2);
            mainMenu.Location = new Point(193, 44);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new Size(639, 465);
            mainMenu.TabIndex = 16;
            // 
            // button5
            // 
            button5.BackColor = Color.DarkGray;
            button5.Font = new Font("Bell MT", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(250, 405);
            button5.Name = "button5";
            button5.Size = new Size(139, 40);
            button5.TabIndex = 9;
            button5.Text = "Credits";
            button5.UseVisualStyleBackColor = false;
            button5.Click += showCredits;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Imprint MT Shadow", 48F, FontStyle.Underline, GraphicsUnit.Point);
            label1.Location = new Point(82, 25);
            label1.Name = "label1";
            label1.Size = new Size(474, 94);
            label1.TabIndex = 6;
            label1.Text = "CHESS";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.Brown;
            button1.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(82, 161);
            button1.Name = "button1";
            button1.Size = new Size(474, 75);
            button1.TabIndex = 7;
            button1.Text = "Play against computer";
            button1.UseVisualStyleBackColor = false;
            button1.Click += ShowSinglePlayerSettings;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.BackColor = Color.Brown;
            button2.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(82, 270);
            button2.Name = "button2";
            button2.Size = new Size(474, 75);
            button2.TabIndex = 8;
            button2.Text = "Play local multiplayer";
            button2.UseVisualStyleBackColor = false;
            button2.Click += ShowMultiplayerSettings;
            // 
            // multiplayerSettings
            // 
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
            multiplayerSettings.Location = new Point(199, 12);
            multiplayerSettings.Name = "multiplayerSettings";
            multiplayerSettings.Size = new Size(627, 516);
            multiplayerSettings.TabIndex = 17;
            multiplayerSettings.Visible = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.BackgroundImage = ChessClientGUI.Properties.Resources.line;
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(29, 93);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(568, 41);
            pictureBox3.TabIndex = 35;
            pictureBox3.TabStop = false;
            // 
            // fullScreenBox
            // 
            fullScreenBox.Appearance = Appearance.Button;
            fullScreenBox.BackgroundImageLayout = ImageLayout.Zoom;
            fullScreenBox.Location = new Point(493, 320);
            fullScreenBox.Name = "fullScreenBox";
            fullScreenBox.Size = new Size(30, 30);
            fullScreenBox.TabIndex = 34;
            fullScreenBox.UseVisualStyleBackColor = true;
            fullScreenBox.CheckedChanged += ToggleFullScreen;
            // 
            // showMovesBox
            // 
            showMovesBox.Appearance = Appearance.Button;
            showMovesBox.BackgroundImageLayout = ImageLayout.Zoom;
            showMovesBox.Location = new Point(493, 260);
            showMovesBox.Name = "showMovesBox";
            showMovesBox.Size = new Size(30, 30);
            showMovesBox.TabIndex = 33;
            showMovesBox.UseVisualStyleBackColor = true;
            showMovesBox.CheckedChanged += ToggleShowMoves;
            // 
            // flipBoardBox
            // 
            flipBoardBox.Appearance = Appearance.Button;
            flipBoardBox.BackgroundImageLayout = ImageLayout.Zoom;
            flipBoardBox.Location = new Point(493, 200);
            flipBoardBox.Name = "flipBoardBox";
            flipBoardBox.Size = new Size(30, 30);
            flipBoardBox.TabIndex = 32;
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
            flowLayoutPanel1.Location = new Point(205, 142);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(321, 31);
            flowLayoutPanel1.TabIndex = 31;
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
            label6.Location = new Point(103, 320);
            label6.Name = "label6";
            label6.Size = new Size(395, 34);
            label6.TabIndex = 30;
            label6.Text = "Full Screen . . . . . . . . . . . . . . . .";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(103, 260);
            label5.Name = "label5";
            label5.Size = new Size(402, 34);
            label5.TabIndex = 29;
            label5.Text = "Hide available moves . . . . . . . . ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(103, 200);
            label4.Name = "label4";
            label4.Size = new Size(406, 34);
            label4.TabIndex = 28;
            label4.Text = "Flip board on black's turn . . . . .";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(100, 140);
            label3.Name = "label3";
            label3.Size = new Size(102, 34);
            label3.TabIndex = 27;
            label3.Text = "Theme";
            // 
            // startMultiplayerGame
            // 
            startMultiplayerGame.BackColor = Color.Brown;
            startMultiplayerGame.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            startMultiplayerGame.Location = new Point(179, 380);
            startMultiplayerGame.Name = "startMultiplayerGame";
            startMultiplayerGame.Size = new Size(269, 67);
            startMultiplayerGame.TabIndex = 26;
            startMultiplayerGame.Text = "Start Game";
            startMultiplayerGame.UseVisualStyleBackColor = false;
            startMultiplayerGame.Click += StartMultiplayerGame;
            // 
            // backButton
            // 
            backButton.BackColor = Color.DarkGray;
            backButton.Font = new Font("Bell MT", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            backButton.Location = new Point(229, 453);
            backButton.Name = "backButton";
            backButton.Size = new Size(168, 45);
            backButton.TabIndex = 25;
            backButton.Text = "Back to menu";
            backButton.UseVisualStyleBackColor = false;
            backButton.Click += returnToMenu;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Imprint MT Shadow", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(65, 19);
            label2.Name = "label2";
            label2.Size = new Size(497, 71);
            label2.TabIndex = 24;
            label2.Text = "Multiplayer Game";
            // 
            // credits
            // 
            credits.Controls.Add(textBox2);
            credits.Controls.Add(textBox1);
            credits.Controls.Add(text);
            credits.Controls.Add(pictureBox5);
            credits.Controls.Add(button7);
            credits.Controls.Add(label17);
            credits.Location = new Point(199, 12);
            credits.Name = "credits";
            credits.Size = new Size(627, 516);
            credits.TabIndex = 36;
            credits.Visible = false;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.Green;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Bell MT", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(29, 335);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(568, 87);
            textBox2.TabIndex = 38;
            textBox2.Text = "Playing against a computer use Stockfish, a free open-source chess engine. Downloads for the source code are found at at https://stockfishchess.org/download/ ";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Green;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Bell MT", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(29, 235);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(568, 87);
            textBox1.TabIndex = 37;
            textBox1.Text = "Chess piece icons were taken from the free online library at  greenchess.net. Downloads can be found at https://greenchess.net/info.php?item=downloads";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // text
            // 
            text.BackColor = Color.Green;
            text.BorderStyle = BorderStyle.None;
            text.Font = new Font("Bell MT", 12F, FontStyle.Regular, GraphicsUnit.Point);
            text.Location = new Point(29, 165);
            text.Multiline = true;
            text.Name = "text";
            text.ReadOnly = true;
            text.Size = new Size(568, 63);
            text.TabIndex = 36;
            text.Text = "The UI and game logic were written independently by Draeden Jensen in 2023.";
            text.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.BackgroundImage = ChessClientGUI.Properties.Resources.line;
            pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox5.Location = new Point(29, 93);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(568, 41);
            pictureBox5.TabIndex = 35;
            pictureBox5.TabStop = false;
            // 
            // button7
            // 
            button7.BackColor = Color.DarkGray;
            button7.Font = new Font("Bell MT", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            button7.Location = new Point(229, 453);
            button7.Name = "button7";
            button7.Size = new Size(168, 45);
            button7.TabIndex = 25;
            button7.Text = "Back to menu";
            button7.UseVisualStyleBackColor = false;
            button7.Click += returnToMenu;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Imprint MT Shadow", 36F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(206, 19);
            label17.Name = "label17";
            label17.Size = new Size(215, 71);
            label17.TabIndex = 24;
            label17.Text = "Credits";
            // 
            // ChessClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Green;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1024, 553);
            Controls.Add(credits);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(multiplayerSettings);
            Controls.Add(singlePlayerSettings);
            Controls.Add(mainMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ChessClient";
            Text = "Chess";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            singlePlayerSettings.ResumeLayout(false);
            singlePlayerSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            mainMenu.ResumeLayout(false);
            multiplayerSettings.ResumeLayout(false);
            multiplayerSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            credits.ResumeLayout(false);
            credits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel singlePlayerSettings;
        private Panel multiplayerSettings;
        private Label label12;
        private PictureBox pictureBox4;
        private CheckBox fullScreen2;
        private CheckBox showMoves2;
        private FlowLayoutPanel flowLayoutPanel4;
        private RadioButton white;
        private RadioButton black;
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
        private Panel mainMenu;
        private Label label1;
        private Button button1;
        private Button button2;
        private PictureBox pictureBox3;
        private CheckBox fullScreenBox;
        private CheckBox showMovesBox;
        private CheckBox flipBoardBox;
        private FlowLayoutPanel flowLayoutPanel1;
        private RadioButton gray;
        private RadioButton green;
        private RadioButton wood;
        private RadioButton marble;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button startMultiplayerGame;
        private Button backButton;
        private Label label2;
        private Button button5;
        private Panel credits;
        private PictureBox pictureBox5;
        private Button button7;
        private Label label17;
        private TextBox text;
        private TextBox textBox2;
        private TextBox textBox1;
    }
}