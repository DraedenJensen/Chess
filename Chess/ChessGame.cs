using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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
        private int turnColor;
        private (int, int) pieceSelected;
        private List<PictureBox> potentialMoves;
        public ChessGame()
        {
            InitializeComponent();

            for (int row = 8; row >= 1; row--)
            {
                for (int column = 1; column <= 8; column++)
                {
                    PictureBox box = new();
                    box.Name = $"{column.ToString()}{row.ToString()}";
                    box.Size = new(100, 100);
                    box.Margin = new Padding(0);
                    box.BackgroundImageLayout = ImageLayout.Zoom;
                    box.Click += squareSelected;

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

            board = new(ShowPieceOnSquare, RemovePieceFromSquare, Check, Promotion, Checkmate, Stalemate);
            turnColor = 1;
            pieceSelected = (0, 0);
            potentialMoves = new();
        }

        private void squareSelected(object sender, EventArgs e)
        {
            string selectedSquare = ((PictureBox)sender).Name;
            (int, int) selectedCoordinates = (int.Parse(selectedSquare.Substring(0, 1)), int.Parse(selectedSquare.Substring(1)));

            // Return if the same space is selected again -- nothing changes
            if (pieceSelected == selectedCoordinates)
            {
                return;
            }

            foreach (PictureBox box in potentialMoves)
            {
                box.Image = null;
            }

            // If we've already selected a piece, check if the new selection is a valid move for that piece
            if (pieceSelected != (0, 0))
            {
                if (potentialMoves.Contains(sender))
                {
                    board.MovePiece(pieceSelected, selectedCoordinates);
                    turnColor *= -1;
                    pieceSelected = (0, 0);
                    potentialMoves.Clear();
                    return;
                }
            }

            // Reset selected piece to be blank and clear dots
            pieceSelected = (0, 0);
            potentialMoves.Clear();

            // Return if the selected space doesn't contain a piece -- we only cleared the previously selected piece
            if (!board.GameBoard.ContainsKey(selectedCoordinates))
            {
                return;
            }

            ChessPiece piece = board.GameBoard[selectedCoordinates];

            // Return if the selected space belongs to the other color -- we only cleared the previously selected piece
            if (piece.Color != turnColor)
            {
                return;
            }

            // If we make it past all those checks, we can finally update the piece, and keep track of the new pictureBoxes with dots
            pieceSelected = selectedCoordinates;
            foreach ((int, int) potentialMove in piece.AvailableMoves)
            {
                PictureBox box = ((PictureBox)boardBox.Controls.Find(potentialMove.Item1.ToString() + potentialMove.Item2.ToString(), true)[0]);
                box.Image = ChessClientGUI.Properties.Resources.translucentDot;
                potentialMoves.Add(box);
            }
        }

        private void Check()
        {

        }

        private string Promotion()
        {
            return "queen";
        }

        private void Checkmate(int color)
        {

        }

        private void Stalemate()
        {

        }

        private void RemovePieceFromSquare((int, int) square)
        {
            ((PictureBox)boardBox.Controls.Find(square.Item1.ToString() + square.Item2.ToString(), true)[0]).BackgroundImage = null;
        }

        private void ShowPieceOnSquare((int, int) square, ChessPiece piece)
        {
            PictureBox box = ((PictureBox)boardBox.Controls.Find(square.Item1.ToString() + square.Item2.ToString(), true)[0]);

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
