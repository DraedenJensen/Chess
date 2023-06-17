using ChessModel;
using System.Diagnostics;

namespace ChessModelsTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Tests whether the Chessboard constructor fills the backing board Dictionary with expected keys and values
        /// </summary>
        [TestMethod]
        public void TestChessboardConstructor_Basic()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            Assert.IsTrue(board.Count == 32);

            int[] arr = { 1, 2, 7, 8 };
            foreach (int j in arr)
            {
                for (int i = 1; i < 9; i++)
                {
                    Debug.WriteLine($"({i}, {j}): {board[(i, j)].Color}, {board[(i, j)].Type}, {board[(i, j)].Captured}");
                }
            }
        }

        /// <summary>
        /// Tests that all pieces have the correct starting moves after initialization
        /// </summary>
        [TestMethod]
        public void TestChessboardConstructor_AvailableMoveInitialization()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            PrintAllPiecesMoves(board);

            foreach (ChessPiece piece in board.Values)
            {
                if (piece.Type == "knight" || piece.Type == "pawn")
                {
                    Assert.IsTrue(piece.AvailableMoves.Count == 2);
                }
                else
                {
                    Assert.IsTrue(piece.AvailableMoves.Count == 0);
                }
            }
        }

        /// <summary>
        /// The very first test to check moving. Ensures a single pawn move affects the board as expected
        /// </summary>
        [TestMethod]
        public void TestSingleMove()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            chessBoard.MovePiece((5, 2), (5, 4));
            PrintAllPiecesMoves(board);
        }

        /// <summary>
        /// Still fairly straightforward, but now we're testing a few moves in succession. This test
        /// was built incrementally to ensure that after every move, the results were what we expect.
        /// Not testing captures or special moves yet
        /// </summary>
        [TestMethod]
        public void TestBasicMoveSequence() {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            chessBoard.MovePiece((5, 2), (5, 4));
            Debug.WriteLine("White pawn to e4. \nSame output as the first test.");
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("Black pawn to e5." +
                "\nAdvancing white pawn should now be blocked.");
            chessBoard.MovePiece((5, 7), (5, 5));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("White bishop to b5." +
                "\nAdvancing bishop should have a lot of options from this point." +
                "\nIncluding to attack the pawn on d7.");
            chessBoard.MovePiece((6, 1), (2, 5));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("Black knight to c6." +
                "\n5 of this knight's 8 potential moves should be available." +
                "\nAlso, white's advanced bishop should be affected.");
            chessBoard.MovePiece((2, 8), (3, 6));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("White queen to g4." +
                "\nLet's get this queen out and make sure her many available moves are all there.");
            chessBoard.MovePiece((4, 1), (7, 4));
            Assert.IsTrue(board[(7, 4)].AvailableMoves.Count == 14);
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("Black pawn to d6." +
                "\nWe're moving a pawn just one square forward, that shouldn't be an issue." +
                "\nBlack bishop should be able to attack the white queen but not go past her.");
            chessBoard.MovePiece((4, 7), (4, 6));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("White knight to h3" +
                "\nThis has a slight effect on white's available moves." +
                "\nAlso, make sure the knight can't move past the edge.");
            chessBoard.MovePiece((7, 1), (8, 3));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("Black pawn to d5." +
                "\nPawn moves again, which should open up a killing move for white's blocked pawn.");
            chessBoard.MovePiece((4, 6), (4, 5));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("White king to e2." +
                "\nThis ensures moving the king out of the way opens up spaces for white's rook." +
                "\nIt also tests the king algorithm more adequately.");
            chessBoard.MovePiece((5, 1), (5, 2));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("Black pawn to a5." +
                "\nBlack moves another pawn; slight ramifications ensue.");
            chessBoard.MovePiece((1, 7), (1, 5));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("White pawn to d4." +
                "\nAffects the pawn get-together we've got going on in the center, as well as the white king.");
            chessBoard.MovePiece((4, 2), (4, 4));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("Black rook to a6." +
                "\nLet's get some more thorough rook testing." +
                "\nRook is blocked by the knight at the moment.");
            chessBoard.MovePiece((1, 8), (1, 6));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("White bishop to g5." +
                "\nOpens up a lot of moves for this bishop." +
                "\nAlso slightly expands the white rook's options, and slightly restricts the black queen.");
            chessBoard.MovePiece((3, 1), (7, 5));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("Black queen to d7." +
                "\nLittle queen move here which will change the diagonals.");
            chessBoard.MovePiece((4, 8), (4, 7));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("White knight to c3." +
                "\nOpens up both white rooks.");
            chessBoard.MovePiece((2, 1), (3, 3));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");
        }

        /// <summary>
        /// Private helper method used for testing which displays all pieces' positions, colors, types, and available moves
        /// </summary>
        private void PrintAllPiecesMoves(Dictionary<(int, int), ChessPiece> board)
        {
            for (int j = 0; j < 9; j++)
            {
                for (int i = 1; i < 9; i++)
                {
                    if (board.ContainsKey((i, j)))
                    {
                        ChessPiece piece = board[(i, j)];

                        Debug.Write($"({i}, {j}): {piece.Color}, {piece.Type}, Available moves: ");
                        foreach ((int, int) square in piece.AvailableMoves)
                        {
                            Debug.Write($"({square.Item1}, {square.Item2}), ");
                        }
                        Debug.WriteLine("");
                    }
                }
            }
        }
    }
}