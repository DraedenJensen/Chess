using ChessModel;
using System.Diagnostics;

namespace ChessModelsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestChessboardConstructor()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            Assert.IsTrue(board.Count == 32);

            int[] arr = { 1, 2, 7, 8 };
                
            foreach (int j in arr)
            {
                for (int i = 1; i < 9; i++)
                {
                    Debug.WriteLine($"({i}, {j}): {board[(i,j)].Color}, {board[(i, j)].Type}, {board[(i, j)].Captured}");
                }
            }
        }
    }
}