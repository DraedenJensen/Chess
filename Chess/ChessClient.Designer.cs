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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Imprint MT Shadow", 48F, FontStyle.Underline, GraphicsUnit.Point);
            label1.Location = new Point(181, 67);
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
            button1.Location = new Point(181, 214);
            button1.Name = "button1";
            button1.Size = new Size(474, 75);
            button1.TabIndex = 1;
            button1.Text = "Play against computer";
            button1.UseVisualStyleBackColor = false;
            button1.Click += startComputerGame;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.BackColor = Color.DarkGray;
            button2.Font = new Font("Bell MT", 18F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(181, 342);
            button2.Name = "button2";
            button2.Size = new Size(474, 75);
            button2.TabIndex = 2;
            button2.Text = "Play local multiplayer";
            button2.UseVisualStyleBackColor = false;
            button2.Click += StartMultiplayerGame;
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
            pictureBox2.Location = new Point(661, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(175, 553);
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // ChessClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(836, 553);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ChessClient";
            Text = "Chess";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}