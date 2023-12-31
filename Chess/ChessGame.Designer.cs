﻿using System.Drawing.Text;

namespace ChessClientGUI
{
    partial class ChessGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChessGame));
            boardBox = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // boardBox
            // 
            boardBox.BackColor = Color.Transparent;
            boardBox.BackgroundImageLayout = ImageLayout.Stretch;
            boardBox.BorderStyle = BorderStyle.FixedSingle;
            boardBox.Location = new Point(0, 1);
            boardBox.Name = "boardBox";
            boardBox.Size = new Size(802, 802);
            boardBox.TabIndex = 0;
            // 
            // ChessGame
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Green;
            ClientSize = new Size(802, 803);
            Controls.Add(boardBox);
            ForeColor = SystemColors.ControlLightLight;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ChessGame";
            Text = "Chess";
            SizeChanged += ResizeLayout;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel boardBox;

    }
}