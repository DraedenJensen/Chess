namespace ChessModel
{
    public class Chessboard
    {
        public Dictionary<(int, int), ChessPiece> GameBoard { get; protected set; }

        private bool whiteInCheck;
        private bool blackInCheck;

        private int turn;

        /// <summary>
        /// Constructor which initializes all pieces and values.
        /// </summary>
        public Chessboard()
        {
            GameBoard = new();
            whiteInCheck = false;
            blackInCheck = false;
            turn = 1;

            // Fill back row pieces
            string[] arr = { "rook", "knight", "bishop", "queen", "king", "bishop", "knight", "rook" };
            for (int i = 0; i < 8; i++)
            {
                ChessPiece white = new(true, arr[i], false);
                ChessPiece black = new(false, arr[i], false);

                GameBoard.Add((i + 1, 1), white);
                GameBoard.Add((i + 1, 8), black);
            }

            // Fill pawns
            for (int i = 1; i < 9; i++)
            {
                ChessPiece whitePawn = new(true, "pawn", false);
                ChessPiece blackPawn = new(false, "pawn", false);

                GameBoard.Add((i, 2), whitePawn);
                GameBoard.Add((i, 7), blackPawn);
            }
        }
    }
}