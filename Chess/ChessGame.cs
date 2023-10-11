using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessModels;

namespace ChessClientGUI
{
    public partial class ChessGame : Form
    {
        private Chessboard board;
        public ChessGame()
        {
            InitializeComponent();

            for (int row = 8; row >= 1; row--)
            {
                for (int column = 1; column <= 8; column++)
                {
                    PictureBox box = new();
                    box.Name = $"({column.ToString()}, {row.ToString()})";
                    box.Size = new(100, 100);
                    box.Margin = new Padding(0);
                    box.BackgroundImageLayout = ImageLayout.Zoom;

                    if ((row + column) % 2 == 1)
                    {
                        box.BackColor = Color.White;
                    }
                    else
                    {
                        box.BackColor = Color.DarkGray;
                    }

                    boardBox.Controls.Add(box);
                }
            }

            board = new();
            DrawBoard();
        }

        private void DrawBoard()
        {
            foreach ((int, int) square in board.GameBoard.Keys)
            {
                PictureBox box = ((PictureBox)boardBox.Controls.Find(square.ToString(), true)[0]);
                ChessPiece piece = board.GameBoard[square];
                if (piece.Color == 1)
                {
                    switch (piece.Type)
                    {
                        case "king":
                            box.BackgroundImage = ChessClientGUI.Properties.Resources.white_king;
                            break;
                        case "queen":
                            box.BackgroundImage = ChessClientGUI.Properties.Resources.white_queen;
                            break;
                        case "rook":
                            box.BackgroundImage = ChessClientGUI.Properties.Resources.white_rook;
                            break;
                        case "bishop":
                            box.BackgroundImage = ChessClientGUI.Properties.Resources.white_bishop;
                            break;
                        case "knight":
                            box.BackgroundImage = ChessClientGUI.Properties.Resources.white_knight;
                            break;
                        case "pawn":
                            box.BackgroundImage = ChessClientGUI.Properties.Resources.white_pawn;
                            break;
                    }
                }
                else
                {
                    switch (piece.Type)
                    {
                        case "king":
                            box.BackgroundImage = ChessClientGUI.Properties.Resources.black_king;
                            break;
                        case "queen":
                            box.BackgroundImage = ChessClientGUI.Properties.Resources.black_queen;
                            break;
                        case "rook":
                            box.BackgroundImage = ChessClientGUI.Properties.Resources.black_rook;
                            break;
                        case "bishop":
                            box.BackgroundImage = ChessClientGUI.Properties.Resources.black_bishop;
                            break;
                        case "knight":
                            box.BackgroundImage = ChessClientGUI.Properties.Resources.black_knight;
                            break;
                        case "pawn":
                            box.BackgroundImage = ChessClientGUI.Properties.Resources.black_pawn;
                            break;
                    }
                }
            }
        }
    }
}
