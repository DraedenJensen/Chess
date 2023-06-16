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

            int[] arr = { 1, 2, 7, 8 };
            foreach (int j in arr)
            {
                for (int i = 1; i < 9; i++)
                {
                    ChessPiece piece = board[(i, j)];

                    Debug.Write($"({i}, {j}): {piece.Color}, {piece.Type}, Available moves: ");
                    foreach ((int, int) square in piece.AvailableMoves)
                    {
                         Debug.Write($"({square.Item1}, {square.Item2}), ");
                    }
                    Debug.WriteLine("");

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
        }
    }
}