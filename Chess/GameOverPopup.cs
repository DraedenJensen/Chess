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
            else
            {
                smallLabel.Text = "";
            }
        }

        private void Restart(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            currentGame.Hide();
            currentGame.Close();
            ChessGame newGame = new();
            newGame.ShowDialog();
        }

        private void ReturnToMenu(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            currentGame.Hide();
            currentGame.Close();
            ChessClient newMenu = new();
            newMenu.ShowDialog();
        }

        private void Quit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
