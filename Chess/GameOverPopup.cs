using Chess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessClientGUI
{
    public partial class GameOverPopup : Form
    {
        ChessGame currentGame;

        /// <summary>
        /// Creates a new popup to get user input when a chess game ends.
        /// </summary>
        /// <param name="endType">String to show on the UI, determined by how the game ended</param>
        /// <param name="color">Losing color (1 or -1) if it's a normal checkmate. Double the losing color (2 or -2) if it was resignation. 0 if stalemate</param>
        /// <param name="currentGame">The current ChessGame form which opened this window</param>
        public GameOverPopup(string endType, int color, ChessGame currentGame)
        {
            InitializeComponent();
            this.currentGame = currentGame;

            bigLabel.Text = endType;
            if (color == -1)
            {
                smallLabel.Text = "White has won!";
            }
            else if (color == 1)
            {
                smallLabel.Text = "Black has won!";
            }
            else if (color == -2)
            {
                smallLabel.Text = "White resigned!";
            }
            else if (color == 2)
            {
                smallLabel.Text = "Black resigned!";
            }
            else
            {
                smallLabel.Text = "";
            }
        }

        /// <summary>
        /// Event handler method which starts a new chess game with the same initial settings as the previous.
        /// </summary>
        private void Restart(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            currentGame.Hide();
            currentGame.Close();
            ChessGame newGame = new(currentGame.SinglePlayerDifficulty, currentGame.SinglePlayerColor, currentGame.Theme, currentGame.FlipBoard, currentGame.ShowMoves, currentGame.FullScreen);
            newGame.ShowDialog();
        }

        /// <summary>
        /// Event handler method which returns to the main menu.
        /// </summary
        private void ReturnToMenu(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            currentGame.Hide();
            currentGame.Close();
            ChessClient newMenu = new();
            newMenu.ShowDialog();
        }

        /// <summary>
        /// Event handler method which quits the entire program.
        /// </summary>
        private void Quit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
