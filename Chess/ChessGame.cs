using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
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
        int turn;
        private (int, int) pieceSelected;
        private List<PictureBox> potentialMoves;

        public int SinglePlayerDifficulty { get; set; }
        public int SinglePlayerColor { get; set; }
        public string Theme { get; set; }
        public bool FlipBoard { get; set; }
        public bool ShowMoves { get; set; }
        public bool FullScreen { get; set; }

        private Color priorColor;
        private PictureBox blueBox;
        private bool singlePlayer;
        private StockfishInterface engine;
        private char userPromotionChar;
        private char computerPromotionChar;

        int test;
        
        FlowLayoutPanel blackCaptures;
        FlowLayoutPanel whiteCaptures;
        Label checkLabel;
        Label turnLabel;
        Label timeLabel;
        Button resign;
        TextBox moveHistory;
        PictureBox line;
        Stopwatch timer;

        public ChessGame(int difficulty, int color, string theme, bool flipBoard, bool showMoves, bool fullScreen)
        {
            InitializeComponent();

            Theme = theme;
            SinglePlayerDifficulty = difficulty;
            SinglePlayerColor = color;
            FlipBoard = flipBoard;
            ShowMoves = showMoves;
            FullScreen = fullScreen;
            computerPromotionChar = ' ';
            userPromotionChar = ' ';

            if (SinglePlayerDifficulty != 0)
            {
                singlePlayer = true;
            }

            InitializeHiddenComponents();

            if (theme == "wood")
            {
                boardBox.BackgroundImage = ChessClientGUI.Properties.Resources.wood_board;
            }
            else if (theme == "marble")
            {
                boardBox.BackgroundImage = ChessClientGUI.Properties.Resources.marble_board;
            }

            for (int row = 8; row >= 1; row--)
            {
                for (int column = 1; column <= 8; column++)
                {
                    PictureBox box = new();
                    box.Name = $"{column.ToString()}{row.ToString()}";
                    if (SinglePlayerColor == -1)
                    {
                        box.Name = $"{(9 - column).ToString()}{(9 - row).ToString()}";
                    }
                    box.Size = new(100, 100);
                    box.Margin = new Padding(0);
                    box.BackgroundImageLayout = ImageLayout.Zoom;
                    box.Click += squareSelected;

                    if ((row + column) % 2 == 1)
                    {
                        if (theme == "gray" || theme == "green")
                        {
                            box.BackColor = Color.White;
                        }
                    }
                    else
                    {
                        if (theme == "gray")
                        {
                            box.BackColor = Color.DarkGray;
                        }
                        else if (theme == "green")
                        {
                            box.BackColor = Color.OliveDrab;
                        }
                    }

                    boardBox.Controls.Add(box);
                }
            }

            board = new(ShowPieceOnSquare, RemovePieceFromSquare, Check, PrintMove, Promotion, Checkmate, Stalemate);
            turnColor = 1;
            turn = 1;
            pieceSelected = (0, 0);
            potentialMoves = new();

            test = 2;

            if (singlePlayer)
            {
                engine = new(SinglePlayerDifficulty);
                
                if (SinglePlayerColor == -1)
                {
                    string computerMove = engine.PassMoveToEngine("");
                    Debug.WriteLine("Computer Move: " + computerMove);
                    (int, int) oldPosition = ((int)(computerMove[0] - 'a' + 1), int.Parse(computerMove[1].ToString()));
                    (int, int) newPosition = ((int)(computerMove[2] - 'a' + 1), int.Parse(computerMove[3].ToString()));
                    Debug.WriteLine($"{oldPosition} {newPosition}");

                    board.MovePiece(oldPosition, newPosition);
                    turnColor *= -1;
                    turnLabel.Text = "Black's turn";
                }
            }

            if (fullScreen)
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void squareSelected(object sender, EventArgs e)
        {
            if (singlePlayer && SinglePlayerColor != turnColor)
            {
                return;
            }

            string selectedSquare = ((PictureBox)sender).Name;
            (int, int) selectedCoordinates = (int.Parse(selectedSquare.Substring(0, 1)), int.Parse(selectedSquare.Substring(1)));

            // Return if the same space is selected again -- nothing changes
            if (pieceSelected == selectedCoordinates)
            {
                return;
            }
            else
            {
                if (blueBox != null)
                {
                    blueBox.BackColor = priorColor;
                }
            }

            if (ShowMoves)
            {
                foreach (PictureBox box in potentialMoves)
                {
                    box.Image = null;
                }
            }

            // If we've already selected a piece, check if the new selection is a valid move for that piece
            if (pieceSelected != (0, 0))
            {
                if (potentialMoves.Contains(sender))
                {
                    board.MovePiece(pieceSelected, selectedCoordinates);

                    if (board.CapturedPieces.Count > blackCaptures.Controls.Count + whiteCaptures.Controls.Count)
                    {
                        PictureBox box = new();
                        box.Size = new Size(60, 60);
                        box.BackgroundImageLayout = ImageLayout.Stretch;

                        ChessPiece newlyCaptured = board.CapturedPieces[board.CapturedPieces.Count - 1];

                        if (newlyCaptured.Color == 1)
                        {
                            blackCaptures.Controls.Add(box);
                        }
                        else
                        {
                            whiteCaptures.Controls.Add(box);
                        }

                        ShowPieceHelper(box, newlyCaptured);
                    }
                    turnColor *= -1;
                    if (turnColor == 1)
                    {
                        turnLabel.Text = "White's turn";
                        turn++;
                    }
                    else
                    {
                        turnLabel.Text = "Black's turn";
                    }

                    if (singlePlayer)
                    {
                        ComputerMove(pieceSelected, selectedCoordinates);
                    }

                    pieceSelected = (0, 0);
                    potentialMoves.Clear();

                    if (FlipBoard)
                    {
                        boardBox.Visible = false;
                        for (int i = 0; i < 32; i++)
                        {
                            PictureBox thisBox = ((PictureBox)boardBox.Controls[i]);
                            PictureBox mirrorBox = ((PictureBox)boardBox.Controls[63 - i]);

                            boardBox.Controls.SetChildIndex(thisBox, 63 - i);
                            boardBox.Controls.SetChildIndex(mirrorBox, i);
                        }
                        boardBox.Visible = true;
                    }

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
            if (!ShowMoves)
            {
                blueBox = ((PictureBox)boardBox.Controls.Find(selectedCoordinates.Item1.ToString() + selectedCoordinates.Item2.ToString(), true)[0]);
                priorColor = blueBox.BackColor;
                if (Theme == "gray" || Theme == "green")
                {
                    blueBox.BackColor = Color.FromArgb(50, blueBox.BackColor);
                }
                else
                {
                    blueBox.BackColor = Color.FromArgb(50, Color.DeepSkyBlue);
                }
            }
            foreach ((int, int) potentialMove in piece.AvailableMoves)
            {
                PictureBox box = ((PictureBox)boardBox.Controls.Find(potentialMove.Item1.ToString() + potentialMove.Item2.ToString(), true)[0]);
                if (ShowMoves)
                {
                    box.Image = ChessClientGUI.Properties.Resources.translucentDot;
                }
                potentialMoves.Add(box);
            }
        }

        private void ComputerMove((int, int) pieceSelected, (int, int) selectedCoordinates)
        {
            string longNotation = "";
            longNotation += (char)('a' + pieceSelected.Item1 - 1);
            longNotation += pieceSelected.Item2;
            longNotation += (char)('a' + selectedCoordinates.Item1 - 1);
            longNotation += selectedCoordinates.Item2;
            if (userPromotionChar != ' ')
            {
                longNotation += userPromotionChar;
            }
            userPromotionChar = ' ';

            string computerMove = engine.PassMoveToEngine(longNotation);

            Debug.WriteLine("Computer Move: " + computerMove);
            (int, int) oldPosition = ((int)(computerMove[0] - 'a' + 1), int.Parse(computerMove[1].ToString()));
            (int, int) newPosition = ((int)(computerMove[2] - 'a' + 1), int.Parse(computerMove[3].ToString()));
            Debug.WriteLine($"{oldPosition} {newPosition}");

            if (computerMove.Length > 4)
            {
                computerPromotionChar = computerMove[4];
            }

            board.MovePiece(oldPosition, newPosition);
            
            turnColor *= -1;
            if (turnColor == 1)
            {
                turnLabel.Text = "White's turn";
                turn++;
            }
            else
            {
                turnLabel.Text = "Black's turn";
            }
        }

        private void Check(int check)
        {
            if (check == 0)
            {
                checkLabel.Text = "";
            }
            else
            {
                checkLabel.Text = "(Check)";
            }
        }

        private void PrintMove(string notation)
        {
            if (turnColor == 1)
            {
                if (turn < 10)
                {
                    moveHistory.AppendText($"{turn}.          {notation}");
                }
                else
                {
                    moveHistory.AppendText($"{turn}.         {notation}");
                }
                for (int i = 0; i < 14 - notation.Length; i++)
                {
                    moveHistory.AppendText(" ");
                }
            }
            else
            {
                moveHistory.AppendText($"{notation}");
                moveHistory.AppendText(Environment.NewLine);
            }
        }

        private string Promotion(int color)
        {
            string selectedType = "";
            switch (computerPromotionChar)
            {
                case ' ':
                    PromotionPopup promotion = new(color);
                    promotion.ShowDialog();

                    while (promotion.SelectedType == "") { }

                    selectedType = promotion.SelectedType;
                    userPromotionChar = selectedType.ToUpper()[0];
                    if (userPromotionChar == 'K')
                    {
                        userPromotionChar = 'N';
                    }
                    break;
                case 'Q':
                    selectedType = "queen";
                    break;
                case 'R':
                    selectedType = "rook";
                    break;
                case 'B':
                    selectedType = "bishop";
                    break;
                case 'N':
                    selectedType = "knight";
                    break;
            }

            computerPromotionChar = ' ';
            return selectedType;
        }

        private void Checkmate(int color)
        {
            GameOverPopup checkmate = new("Checkmate!", color, this);
            checkmate.ShowDialog();
        }

        private void Stalemate()
        {
            GameOverPopup stalemate = new("Stalemate!", 0, this);
            stalemate.ShowDialog();
        }

        private void Resign(object sender, EventArgs e)
        {
            string message;
            if (turnColor == 1)
            {
                message = "Black wins!";
            }
            else
            {
                message = "White wins!";
            }
            GameOverPopup resigned = new(message, turnColor * -2, this);
            resigned.ShowDialog();
        }

        private void RemovePieceFromSquare((int, int) square)
        {
            PictureBox box = ((PictureBox)boardBox.Controls.Find(square.Item1.ToString() + square.Item2.ToString(), true)[0]);
            box.BackgroundImage = null;
        }

        private void ShowPieceHelper(PictureBox box, ChessPiece piece)
        {
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

        private void ShowPieceOnSquare((int, int) square, ChessPiece piece)
        {
            PictureBox box = ((PictureBox)boardBox.Controls.Find(square.Item1.ToString() + square.Item2.ToString(), true)[0]);
            ShowPieceHelper(box, piece);
        }

        private void InitializeHiddenComponents()
        {
            blackCaptures = new();
            whiteCaptures = new();

            blackCaptures.Size = new Size(1000, 63);
            blackCaptures.Padding = new Padding(0);
            blackCaptures.Visible = false;

            whiteCaptures.Size = new Size(1000, 63);
            whiteCaptures.Padding = new Padding(0);
            whiteCaptures.Visible = false;

            timeLabel = new();
            line = new();
            turnLabel = new();
            moveHistory = new();
            checkLabel = new();

            timeLabel.Size = new Size(400, 100);
            timeLabel.TextAlign = ContentAlignment.MiddleCenter;
            timeLabel.Font = new Font("Bell MT", 48F, GraphicsUnit.Point);
            timeLabel.Visible = false;

            timer = new();
            timer.Start();
            Thread thread = new(UpdateElapsedTime);
            thread.Start();

            line.Size = new Size(400, 20);
            line.BackgroundImage = ChessClientGUI.Properties.Resources.line;
            line.BackgroundImageLayout = ImageLayout.Stretch;
            line.Visible = false;

            turnLabel.Size = new Size(400, 100);
            turnLabel.TextAlign = ContentAlignment.MiddleCenter;
            turnLabel.Font = new Font("Imprint MT Shadow", 36F, GraphicsUnit.Point);
            turnLabel.Text = "White's turn";
            turnLabel.Visible = false;

            checkLabel.Size = new Size(400, 75);
            checkLabel.TextAlign = ContentAlignment.MiddleCenter;
            checkLabel.Font = new Font("Imprint MT Shadow", 15F, GraphicsUnit.Point);
            checkLabel.Visible = false;

            resign = new();
            resign.Size = new Size(100, 50);
            resign.BackColor = Color.White;
            resign.Text = "Resign";
            resign.Font = new Font("Bell MT", 16F, GraphicsUnit.Point);
            resign.Click += Resign;
            resign.Visible = false;

            moveHistory.BorderStyle = BorderStyle.FixedSingle;
            moveHistory.Size = new Size(325, 500);
            moveHistory.BackColor = Color.DarkGray;
            moveHistory.Padding = new(5);
            moveHistory.Font = new Font("Bell MT", 15F, GraphicsUnit.Point);
            moveHistory.Multiline = true;
            moveHistory.ReadOnly = true;
            moveHistory.ScrollBars = ScrollBars.Vertical;
            moveHistory.Visible = false;

            Controls.Add(blackCaptures);
            Controls.Add(whiteCaptures);
            Controls.Add(timeLabel);
            Controls.Add(line);
            Controls.Add(turnLabel);
            Controls.Add(moveHistory);
            Controls.Add(checkLabel);
            Controls.Add(resign);
        }

        private void UpdateElapsedTime()
        {
            while (true)
            {
                try
                {
                    Invoke(new Action(() =>
                    {
                        long elapsed = timer.ElapsedMilliseconds;
                        int seconds = (int)(elapsed / 1000) % 60;
                        int minutes = (int)(elapsed / 60000) % 60;
                        int hours = (int)(elapsed / 3600000);
                        timeLabel.Text = $"{hours.ToString("D2")}:{minutes.ToString("D2")}:{seconds.ToString("D2")}";
                    }));
                }
                catch (Exception ex) { }
            }
        }

        private void ResizeLayout(object sender, EventArgs e)
        {
            Form form = (Form)sender;

            if (form.Size.Width > 900)
            {
                boardBox.Location = new Point(100, form.Height / 2 - 450);

                blackCaptures.Location = new Point(900, boardBox.Location.Y);
                whiteCaptures.Location = new Point(900, boardBox.Location.Y + 740);
                turnLabel.Location = new Point(950, boardBox.Location.Y + 275);
                line.Location = new Point(950, turnLabel.Location.Y + 115);
                lock (timeLabel)
                {
                    timeLabel.Location = new Point(950, turnLabel.Location.Y + 150);
                }
                moveHistory.Location = new Point(1400, boardBox.Location.Y + 150);
                checkLabel.Location = new Point(950, turnLabel.Location.Y - 50);

                blackCaptures.Visible = true;
                whiteCaptures.Visible = true;
                turnLabel.Visible = true;
                line.Visible = true;
                lock (timeLabel)
                {
                    timeLabel.Visible = true;
                }
                moveHistory.Visible = true;
                checkLabel.Visible = true;

                resign.Location = new Point(timeLabel.Location.X + 150, timeLabel.Location.Y + 120);
                resign.Visible = true;
            }
            else
            {
                boardBox.Location = new Point(0, 1);
                blackCaptures.Visible = false;
                whiteCaptures.Visible = false;
            }
        }
    }
}
