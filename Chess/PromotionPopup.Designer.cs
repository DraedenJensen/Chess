namespace ChessClientGUI
{
    partial class PromotionPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PromotionPopup));
            label1 = new Label();
            knight = new Button();
            bishop = new Button();
            rook = new Button();
            queen = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Bell MT", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(75, 54);
            label1.Name = "label1";
            label1.Size = new Size(650, 46);
            label1.TabIndex = 0;
            label1.Text = "Select a piece to promote this pawn to.";
            // 
            // knight
            // 
            knight.Location = new Point(559, 117);
            knight.Name = "knight";
            knight.Size = new Size(150, 150);
            knight.TabIndex = 3;
            knight.UseVisualStyleBackColor = true;
            knight.Click += PieceSelected;
            // 
            // bishop
            // 
            bishop.Location = new Point(247, 117);
            bishop.Name = "bishop";
            bishop.Size = new Size(150, 150);
            bishop.TabIndex = 2;
            bishop.UseVisualStyleBackColor = true;
            bishop.Click += PieceSelected;
            // 
            // rook
            // 
            rook.Location = new Point(403, 117);
            rook.Name = "rook";
            rook.Size = new Size(150, 150);
            rook.TabIndex = 1;
            rook.UseVisualStyleBackColor = true;
            rook.Click += PieceSelected;
            // 
            // queen
            // 
            queen.Location = new Point(91, 117);
            queen.Name = "queen";
            queen.Size = new Size(150, 150);
            queen.TabIndex = 0;
            queen.UseVisualStyleBackColor = true;
            queen.Click += PieceSelected;
            // 
            // PromotionPopup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(802, 333);
            ControlBox = false;
            Controls.Add(knight);
            Controls.Add(rook);
            Controls.Add(queen);
            Controls.Add(bishop);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PromotionPopup";
            Text = "Chess";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button knight;
        private Button bishop;
        private Button rook;
        private Button queen;
    }
}