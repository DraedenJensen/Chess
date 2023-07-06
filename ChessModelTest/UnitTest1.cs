using ChessModels;
using NuGet.Frameworks;
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

            Assert.IsTrue(chessBoard.MovePiece((5, 2), (5, 4)));
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

            Assert.IsTrue(chessBoard.MovePiece((5, 2), (5, 4)));
            Debug.WriteLine("White pawn to e4. \nSame output as the first test.");
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("Black pawn to e5." +
                "\nAdvancing white pawn should now be blocked.");
            Assert.IsTrue(chessBoard.MovePiece((5, 7), (5, 5)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("White bishop to b5." +
                "\nAdvancing bishop should have a lot of options from this point." +
                "\nIncluding to attack the pawn on d7.");
            Assert.IsTrue(chessBoard.MovePiece((6, 1), (2, 5)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("Black knight to c6." +
                "\n5 of this knight's 8 potential moves should be available." +
                "\nAlso, white's advanced bishop should be affected.");
            Assert.IsTrue(chessBoard.MovePiece((2, 8), (3, 6)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("White queen to g4." +
                "\nLet's get this queen out and make sure her many available moves are all there.");
            Assert.IsTrue(chessBoard.MovePiece((4, 1), (7, 4)));
            Assert.IsTrue(board[(7, 4)].AvailableMoves.Count == 14);
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("Black pawn to d6." +
                "\nWe're moving a pawn just one square forward, that shouldn't be an issue." +
                "\nBlack bishop should be able to attack the white queen but not go past her.");
            Assert.IsTrue(chessBoard.MovePiece((4, 7), (4, 6)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("White knight to h3" +
                "\nThis has a slight effect on white's available moves." +
                "\nAlso, make sure the knight can't move past the edge.");
            Assert.IsTrue(chessBoard.MovePiece((7, 1), (8, 3)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("Black pawn to d5." +
                "\nPawn moves again, which should open up a killing move for white's blocked pawn.");
            Assert.IsTrue(chessBoard.MovePiece((4, 6), (4, 5)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("White king to e2." +
                "\nThis ensures moving the king out of the way opens up spaces for white's rook." +
                "\nIt also tests the king algorithm more adequately.");
            Assert.IsTrue(chessBoard.MovePiece((5, 1), (5, 2)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("Black pawn to a5." +
                "\nBlack moves another pawn; slight ramifications ensue.");
            Assert.IsTrue(chessBoard.MovePiece((1, 7), (1, 5)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("White pawn to d4." +
                "\nAffects the pawn get-together we've got going on in the center, as well as the white king.");
            Assert.IsTrue(chessBoard.MovePiece((4, 2), (4, 4)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("Black rook to a6." +
                "\nLet's get some more thorough rook testing." +
                "\nRook is blocked by the knight at the moment.");
            Assert.IsTrue(chessBoard.MovePiece((1, 8), (1, 6)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("White bishop to g5." +
                "\nOpens up a lot of moves for this bishop." +
                "\nAlso slightly expands the white rook's options, and slightly restricts the black queen.");
            Assert.IsTrue(chessBoard.MovePiece((3, 1), (7, 5)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("Black queen to d7." +
                "\nLittle queen move here which will change the diagonals.");
            Assert.IsTrue(chessBoard.MovePiece((4, 8), (4, 7)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            Debug.WriteLine("White knight to c3." +
                "\nOpens up both white rooks.");
            Assert.IsTrue(chessBoard.MovePiece((2, 1), (3, 3)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");
        }

        /// <summary>
        /// Tests pawn's unique diagonal movement for capturing
        /// </summary>
        [TestMethod]
        public void TestPawnCapture()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;
            HashSet<ChessPiece> captured = chessBoard.CapturedPieces;

            // White pawn to e4
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (5, 4)));
            // Black pawn to d5
            Assert.IsTrue(chessBoard.MovePiece((4, 7), (4, 5)));

            Debug.WriteLine("White pawn captures black pawn and switches to its file.");
            Assert.IsTrue(chessBoard.MovePiece((5, 4), (4, 5)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");
            Assert.IsTrue(captured.Count == 1);

            // Black pawn to e6, setting the white pawn up for a chain of captures
            Assert.IsTrue(chessBoard.MovePiece((5, 7), (5, 6)));

            // We'll disregard rules for a sec
            // The model doesn't currently require turn order or implement promotion
            // We're just here to test pawn capturing

            // White pawn captures black pawn
            Assert.IsTrue(chessBoard.MovePiece((4, 5), (5, 6)));
            Assert.IsTrue(captured.Count == 2);
            // White pawn captures another pawn
            Assert.IsTrue(chessBoard.MovePiece((5, 6), (6, 7)));
            Assert.IsTrue(captured.Count == 3);
            
            // White pawn captures black knight
            Debug.WriteLine("White pawn has now captured 4 pieces and has reached the end of the board." +
                "\nNo promotion yet.");
            Assert.IsTrue(chessBoard.MovePiece((6, 7), (7, 8)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");
            Assert.IsTrue(captured.Count == 4);
        }

        /// <summary>
        /// Tests some other moves' capturing. The above 2 tests together pretty thoroughly show that capturing works as
        /// intended, but we'll get a bit more testing to be safe.
        /// </summary>
        [TestMethod]
        public void TestOtherPiecesCapture()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;
            HashSet<ChessPiece> captured = chessBoard.CapturedPieces;

            // White pawn to e4
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (5, 4)));
            // Black pawn to d5
            Assert.IsTrue(chessBoard.MovePiece((4, 7), (4, 5)));
            // White queen to h5
            Assert.IsTrue(chessBoard.MovePiece((4, 1), (8, 5)));
            // Black bishop to f5
            Assert.IsTrue(chessBoard.MovePiece((3, 8), (6, 5)));

            // White queen captures black pawn (outstanding move)
            Assert.IsTrue(chessBoard.MovePiece((8, 5), (8, 7)));
            Assert.IsTrue(captured.Count == 1);

            // Black bishop captures white pawn
            Assert.IsTrue(chessBoard.MovePiece((6, 5), (5, 4)));
            Assert.IsTrue(captured.Count == 2);

            // White queen captures black knight diagonally
            Assert.IsTrue(chessBoard.MovePiece((8, 7), (7, 8)));
            Assert.IsTrue(captured.Count == 3);

            // Black rook finally stops this madman of a queen
            Assert.IsTrue(chessBoard.MovePiece((8, 8), (7, 8)));
            Assert.IsTrue(captured.Count == 4);

            // White knight to c3
            Assert.IsTrue(chessBoard.MovePiece((2, 1), (3, 3)));

            // Black bishop captures white pawn
            Assert.IsTrue(chessBoard.MovePiece((5, 4), (3, 2)));
            Assert.IsTrue(captured.Count == 5);

            // White knight captures black pawn
            Assert.IsTrue(chessBoard.MovePiece((3, 3), (4, 5)));

            foreach (ChessPiece piece in captured)
            {
                Debug.WriteLine(piece.Color + " " + piece.Type);
            }
        }

        /// <summary>
        /// Every bishop, queen, and rook now keeps track of any row or diagonal in which at least 1 piece is all
        /// that separates them from the enemy king. This test ensures that this component is working properly. 
        /// </summary>
        [TestMethod]
        public void TestPotentialLinesOfCheck()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            // White pawn to e4
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (5, 4)));
            foreach (ChessPiece piece in board.Values)
            {
                Assert.IsTrue(piece.PotentialLineOfCheck.Item1.Count == 0);
            }

            // Black pawn to e5
            Assert.IsTrue(chessBoard.MovePiece((5, 7), (5, 5)));
            foreach (ChessPiece piece in board.Values)
            {
                Assert.IsTrue(piece.PotentialLineOfCheck.Item1.Count == 0);
            }

            // White bishop to b5
            // The bishop now has a single piece in the way of check
            Assert.IsTrue(chessBoard.MovePiece((6, 1), (2, 5)));
            foreach (var entry in board)
            {
                if (entry.Key == (2, 5))
                {
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Count == 1);
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Contains((4, 7)));

                    HashSet<(int, int)> line = entry.Value.PotentialLineOfCheck.Item2;
                    Assert.IsTrue(line.Count == 2);
                    Assert.IsTrue(line.Contains((3, 6)));
                    Assert.IsTrue(line.Contains((4, 7)));
                }
                else
                {
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Count == 0);
                }
            }

            // Black pawn to c6
            // There are now 2 pieces in bishop's potential line of check
            Assert.IsTrue(chessBoard.MovePiece((3, 7), (3, 6)));
            foreach (var entry in board)
            {
                if (entry.Key == (2, 5))
                {
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Count == 2);
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Contains((4, 7)));
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Contains((3, 6)));

                    HashSet<(int, int)> line = entry.Value.PotentialLineOfCheck.Item2;
                    Assert.IsTrue(line.Count == 2);
                    Assert.IsTrue(line.Contains((3, 6)));
                    Assert.IsTrue(line.Contains((4, 7)));
                }
                else
                {
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Count == 0);
                }
            }

            // White queen to h5
            // The queen should now have a potential check line
            Assert.IsTrue(chessBoard.MovePiece((4, 1), (8, 5)));
            foreach (var entry in board)
            {
                if (entry.Key == (2, 5))
                {
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Count == 2);
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Contains((4, 7)));
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Contains((3, 6)));

                    HashSet<(int, int)> line = entry.Value.PotentialLineOfCheck.Item2;
                    Assert.IsTrue(line.Count == 2);
                    Assert.IsTrue(line.Contains((3, 6)));
                    Assert.IsTrue(line.Contains((4, 7)));
                }
                else if (entry.Key == (8, 5))
                {
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Count == 1);
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Contains((6, 7)));

                    HashSet<(int, int)> line = entry.Value.PotentialLineOfCheck.Item2;
                    Assert.IsTrue(line.Count == 2);
                    Assert.IsTrue(line.Contains((7, 6)));
                    Assert.IsTrue(line.Contains((6, 7)));
                }
                else
                {
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Count == 0);
                }
            }

            // Black pawn to d5
            // One of the pawns is now out of the bishop's way, so the bishop as well as queen are each separated by a single piece
            Assert.IsTrue(chessBoard.MovePiece((4, 7), (4, 5)));
            foreach (var entry in board)
            {
                if (entry.Key == (2, 5))
                {
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Count == 1);
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Contains((3, 6)));

                    HashSet<(int, int)> line = entry.Value.PotentialLineOfCheck.Item2;
                    Assert.IsTrue(line.Count == 2);
                    Assert.IsTrue(line.Contains((3, 6)));
                    Assert.IsTrue(line.Contains((4, 7)));
                }
                else if (entry.Key == (8, 5))
                {
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Count == 1);
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Contains((6, 7)));

                    HashSet<(int, int)> line = entry.Value.PotentialLineOfCheck.Item2;
                    Assert.IsTrue(line.Count == 2);
                    Assert.IsTrue(line.Contains((7, 6)));
                    Assert.IsTrue(line.Contains((6, 7)));
                }
                else
                {
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Count == 0);
                }
            }

            // White knight to f3, nothing changes
            Assert.IsTrue(chessBoard.MovePiece((7, 1), (6, 3)));

            // Black queen to e7
            // The black queen now has a check line
            Assert.IsTrue(chessBoard.MovePiece((4, 8), (5, 7)));
            foreach (var entry in board)
            {
                if (entry.Key == (2, 5))
                {
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Count == 1);
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Contains((3, 6)));

                    HashSet<(int, int)> line = entry.Value.PotentialLineOfCheck.Item2;
                    Assert.IsTrue(line.Count == 2);
                    Assert.IsTrue(line.Contains((3, 6)));
                    Assert.IsTrue(line.Contains((4, 7)));
                }
                else if (entry.Key == (8, 5))
                {
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Count == 1);
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Contains((6, 7)));

                    HashSet<(int, int)> line = entry.Value.PotentialLineOfCheck.Item2;
                    Assert.IsTrue(line.Count == 2);
                    Assert.IsTrue(line.Contains((7, 6)));
                    Assert.IsTrue(line.Contains((6, 7)));
                }
                else if (entry.Key == (5, 7))
                {
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Count == 2);
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Contains((5, 4)));
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Contains((5, 5)));

                    HashSet<(int, int)> line = entry.Value.PotentialLineOfCheck.Item2;
                    Assert.IsTrue(line.Count == 5);
                    Assert.IsTrue(line.Contains((5, 2)));
                    Assert.IsTrue(line.Contains((5, 3)));
                    Assert.IsTrue(line.Contains((5, 4)));
                    Assert.IsTrue(line.Contains((5, 5)));
                    Assert.IsTrue(line.Contains((5, 6)));
                }
                else
                {
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Count == 0);
                }
            }

            // White pawn to d5
            // Only 1 piece in the black queen's way
            Assert.IsTrue(chessBoard.MovePiece((5, 4), (4, 5)));
            ChessPiece queen = board[(5, 7)];
            Assert.IsTrue(queen.PotentialLineOfCheck.Item1.Count == 1);
            Assert.IsTrue(queen.PotentialLineOfCheck.Item1.Contains((5, 5)));

            HashSet<(int, int)> queenLine = queen.PotentialLineOfCheck.Item2;
            Assert.IsTrue(queenLine.Count == 5);
            Assert.IsTrue(queenLine.Contains((5, 2)));
            Assert.IsTrue(queenLine.Contains((5, 3)));
            Assert.IsTrue(queenLine.Contains((5, 4)));
            Assert.IsTrue(queenLine.Contains((5, 5)));
            Assert.IsTrue(queenLine.Contains((5, 6)));

            // Black king to d8
            // He got out of both the bishop and the queen's line of attack
            Assert.IsTrue(chessBoard.MovePiece((5, 8), (4, 8)));
            foreach (var entry in board)
            {
                if (entry.Key != (5, 7))
                {
                    Assert.IsTrue(entry.Value.PotentialLineOfCheck.Item1.Count == 0);
                }
            }

            // White queen to h4
            // She's back in the king's line of sight
            Assert.IsTrue(chessBoard.MovePiece((8, 5), (8, 4)));
            queen = board[(8, 4)];
            Assert.IsTrue(queen.PotentialLineOfCheck.Item1.Count == 1);
            Assert.IsTrue(queen.PotentialLineOfCheck.Item1.Contains((5, 7)));

            queenLine = queen.PotentialLineOfCheck.Item2;
            Assert.IsTrue(queenLine.Count == 3);
            Assert.IsTrue(queenLine.Contains((7, 5)));
            Assert.IsTrue(queenLine.Contains((6, 6)));
            Assert.IsTrue(queenLine.Contains((5, 7)));

            // Black pawn to a5, this changes nothing
            Assert.IsTrue(chessBoard.MovePiece((1, 7), (1, 5)));

            // White knight to g5
            // Knight in its own queen's way
            Assert.IsTrue(chessBoard.MovePiece((6, 3), (7, 5)));
            Assert.IsTrue(queen.PotentialLineOfCheck.Item1.Count == 2);
            Assert.IsTrue(queen.PotentialLineOfCheck.Item1.Contains((7, 5)));

            // Black queen to e6
            // Her line of sight hasn't changed except being 1 square smaller
            Assert.IsTrue(chessBoard.MovePiece((5, 7), (5, 6)));
            Assert.IsTrue(queen.PotentialLineOfCheck.Item1.Count == 1);
            queen = board[(5, 6)];
            Assert.IsTrue(queen.PotentialLineOfCheck.Item2.Count == 4);

            // White king to e2, nothing much changes
            Assert.IsTrue(chessBoard.MovePiece((5, 1), (5, 2)));
            // Black pawn to a4, nothing changes
            Assert.IsTrue(chessBoard.MovePiece((1, 5), (1, 4)));

            // White rook to d1
            // Now the rook has a long line of sight
            Assert.IsTrue(chessBoard.MovePiece((8, 1), (4, 1)));
            ChessPiece rook = board[(4, 1)];
            Assert.IsTrue(rook.PotentialLineOfCheck.Item1.Count == 2);
            Assert.IsTrue(rook.PotentialLineOfCheck.Item1.Contains((4, 2)));
            Assert.IsTrue(rook.PotentialLineOfCheck.Item1.Contains((4, 5)));

            HashSet<(int, int)> rookLine = rook.PotentialLineOfCheck.Item2;
            Assert.IsTrue(rookLine.Count == 6);
            Assert.IsTrue(rookLine.Contains((4, 2)));
            Assert.IsTrue(rookLine.Contains((4, 3)));
            Assert.IsTrue(rookLine.Contains((4, 4)));
            Assert.IsTrue(rookLine.Contains((4, 5)));
            Assert.IsTrue(rookLine.Contains((4, 6)));
            Assert.IsTrue(rookLine.Contains((4, 7)));
        }

        /// <summary>
        /// Tests that invalid moves return false and don't change the board
        /// </summary>
        [TestMethod]
        public void TestInvalidMoves()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            // Moving from a square not on board
            Assert.IsFalse(chessBoard.MovePiece((-2, 1), (4, 2)));
            // Moving from a square with no piece
            Assert.IsFalse(chessBoard.MovePiece((4, 4), (4, 5)));
            // Move not allowed for a piece
            Assert.IsFalse(chessBoard.MovePiece((4, 2), (3, 3)));
            Assert.IsFalse(chessBoard.MovePiece((5, 1), (5, 2)));
            Assert.IsFalse(chessBoard.MovePiece((8, 1), (8, 4)));
            // Moving to a square not on board
            Assert.IsFalse(chessBoard.MovePiece((1, 1), (0, 1)));
        }

        /// <summary>
        /// Tests that a non-king piece will not be allowed to move into check 
        /// </summary>
        [TestMethod]
        public void TestMovingNonKingIntoCheck()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            // White pawn to e4
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (5, 4)));
            // Black pawn to e5
            Assert.IsTrue(chessBoard.MovePiece((5, 7), (5, 5)));

            // White bishop to b5
            // Now the black pawn can't move
            Assert.IsTrue(chessBoard.MovePiece((6, 1), (2, 5)));
            Assert.IsTrue(board[(4, 7)].AvailableMoves.Count == 0);
            Assert.IsFalse(chessBoard.MovePiece((4, 7), (4, 6)));

            // Black pawn to c6
            // Now the pawn can move again
            Assert.IsTrue(chessBoard.MovePiece((3, 7), (3, 6)));
            Assert.IsTrue(board[(4, 7)].AvailableMoves.Count == 2);
            Assert.IsTrue(board[(3, 6)].AvailableMoves.Count == 2);

            // White queen to h5
            // Now the pawn on the other side of the king is blocked
            Assert.IsTrue(chessBoard.MovePiece((4, 1), (8, 5)));
            Assert.IsTrue(board[(6, 7)].AvailableMoves.Count == 0);
            Assert.IsFalse(chessBoard.MovePiece((6, 7), (6, 5)));

            // Black queen to e7
            Assert.IsTrue(chessBoard.MovePiece((4, 8), (5, 7)));

            // White queen to e5
            // Black queen can't move away from this file, but she still has 2 options, including killing the queen
            Assert.IsTrue(chessBoard.MovePiece((8, 5), (5, 5)));
            Debug.WriteLine(board[(5, 7)].AvailableMoves.Count);
            Assert.IsTrue(board[(5, 7)].AvailableMoves.Count == 2);
            Assert.IsTrue(board[(5, 7)].AvailableMoves.Contains((5, 5)));
            Assert.IsTrue(board[(5, 7)].AvailableMoves.Contains((5, 5)));

            // Black queen to e5
            // She kills the other queen so now she has plenty of options
            Assert.IsTrue(chessBoard.MovePiece((5, 7), (5, 5)));
            Assert.IsTrue(board[(5, 5)].AvailableMoves.Count == 18);

            // White bishop to c6
            // Pawn's only move is to kill the bishop
            Assert.IsTrue(chessBoard.MovePiece((2, 5), (3, 6)));
            Assert.IsTrue(board[(4, 7)].AvailableMoves.Count == 1);
            
            // Pawn then takes that move
            Assert.IsTrue(chessBoard.MovePiece((4, 7), (3, 6)));
            Assert.IsTrue(board[(3, 6)].AvailableMoves.Count == 1);
        }

        /// <summary>
        /// Tests that a king will not be allowed to move into check
        /// </summary>
        [TestMethod]
        public void TestMovingKingIntoCheck()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            // White pawn to e4
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (5, 4)));
            // Black pawn to d5
            Assert.IsTrue(chessBoard.MovePiece((4, 7), (4, 5)));
            // White pawn to b4
            Assert.IsTrue(chessBoard.MovePiece((2, 2), (2, 4)));

            // Black bishop to g4
            // The king can't move forward without moving into check
            Assert.IsTrue(chessBoard.MovePiece((3, 8), (7, 4)));
            Assert.IsTrue(board[(5, 1)].AvailableMoves.Count == 0);

            // White pawn to d3
            // This opens a move for a king
            Assert.IsTrue(chessBoard.MovePiece((4, 2), (4, 3)));
            Assert.IsTrue(board[(5, 1)].AvailableMoves.Count == 1);
        }

        [TestMethod]
        public void TestCheck()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            // White pawn to e4
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (5, 4)));
            // Black pawn to e5
            Assert.IsTrue(chessBoard.MovePiece((5, 7), (5, 5)));
            // White pawn to f4
            Assert.IsTrue(chessBoard.MovePiece((6, 2), (6, 4)));

            // Black queen to h4
            // White is in check
            // The only available moves should be moving the white king out of the way, or moving the pawn into the way
            Assert.IsTrue(chessBoard.MovePiece((4, 8), (8, 4)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // White pawn to g3
            // White is no longer in check, moves open up
            Assert.IsTrue(chessBoard.MovePiece((7, 2), (7, 3)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // Black queen to g3
            // White is back in check; should only be able to move the king or kill the queen
            Assert.IsTrue(chessBoard.MovePiece((8, 4), (7, 3)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // White king to e2
            // White is no longer in check, moves open up (but the king can't move anywhere from here)
            Assert.IsTrue(chessBoard.MovePiece((5, 1), (5, 2)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // Black pawn to d5
            Assert.IsTrue(chessBoard.MovePiece((4, 7), (4, 5)));
            // White pawn to d5
            Assert.IsTrue(chessBoard.MovePiece((5, 4), (4, 5)));

            // Black bishop to g4
            // White is in check, and their only possible move is to block with the knight
            Assert.IsTrue(chessBoard.MovePiece((3, 8), (7, 4)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // White knight to f3
            Assert.IsTrue(chessBoard.MovePiece((7, 1), (6, 3)));
            // Black knight to c6
            Assert.IsTrue(chessBoard.MovePiece((2, 8), (3, 6)));
            // White pawn to d6
            Assert.IsTrue(chessBoard.MovePiece((4, 5), (4, 6)));
            // Black bishop to f5
            Assert.IsTrue(chessBoard.MovePiece((7, 4), (6, 5)));

            // White pawn to d7
            // Testing pawn check - black must move the king or kill the pawn with the king or bishop
            Assert.IsTrue(chessBoard.MovePiece((4, 6), (4, 7)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // Black king to d8
            // Black escapes check and blocks the white pawn from moving forward
            Assert.IsTrue(chessBoard.MovePiece((5, 8), (4, 8)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // White pawn to a4
            Assert.IsTrue(chessBoard.MovePiece((1, 2), (1, 4)));

            // Black knight to d4
            // White is in check; they can either move their king or kill the knight with their knight
            Assert.IsTrue(chessBoard.MovePiece((3, 6), (4, 4)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // White king to e3
            // Fun fact, the king is NOT in check, but he has nowhere to go (poor guy)
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (5, 3)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // Black pawn to e4
            // Now the king can kill the knight, if he so chooses
            Assert.IsTrue(chessBoard.MovePiece((5, 5), (5, 4)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // White bishop to h3
            Assert.IsTrue(chessBoard.MovePiece((6, 1), (8, 3)));

            // Black bishop to c5
            // Now the king can't kill the knight, even if he so chooses
            Assert.IsTrue(chessBoard.MovePiece((6, 8), (3, 5)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // White bishop to f5
            // The black bishop is dead, so now the white king can kill the pawn in front of it
            // But the black king can no longer kill the pawn in front of it
            Assert.IsTrue(chessBoard.MovePiece((8, 3), (6, 5)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // Black king to e7
            Assert.IsTrue(chessBoard.MovePiece((4, 8), (5, 7)));
            // White pawn to d3
            Assert.IsTrue(chessBoard.MovePiece((4, 2), (4, 3)));
            // Black pawn to d3
            Assert.IsTrue(chessBoard.MovePiece((5, 4), (4, 3)));
            // White queen to d3
            Assert.IsTrue(chessBoard.MovePiece((4, 1), (4, 3)));
            // Black rook to e8
            Assert.IsTrue(chessBoard.MovePiece((1, 8), (5, 8)));

            // White queen to d4
            // The black king only has two possible moves
            Assert.IsTrue(chessBoard.MovePiece((4, 3), (4, 4)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // Black king to f8
            // This puts white into check; the king has two possible moves
            // They can also block with the bishop, or kill with the pawn
            Assert.IsTrue(chessBoard.MovePiece((5, 7), (6, 8)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // White king to d2
            Assert.IsTrue(chessBoard.MovePiece((5, 3), (4, 2)));

            // Black rook to e2
            // The white king should be able to kill this rook
            Assert.IsTrue(chessBoard.MovePiece((5, 8), (5, 2)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // White king to e2
            Assert.IsTrue(chessBoard.MovePiece((4, 2), (5, 2)));

            // Black queen to f3
            // The white king is in check
            Assert.IsTrue(chessBoard.MovePiece((7, 3), (6, 3)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // White king to f3
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (6, 3)));
            // Black pawn to b6
            Assert.IsTrue(chessBoard.MovePiece((2, 7), (2, 6)));

            // White queen to c5
            // Black is in check; king has no moves
            // Only option is to block with knight, or kill with pawn
            Assert.IsTrue(chessBoard.MovePiece((4, 4), (3, 5)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");
        }

        /// <summary>
        /// Tests that kings can't move next to each other
        /// </summary>
        [TestMethod]
        public void TestKingBlockingKing()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            // White pawn to e4
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (5, 4)));
            // Black pawn to e5
            Assert.IsTrue(chessBoard.MovePiece((5, 7), (5, 5)));

            // White king to e2
            Assert.IsTrue(chessBoard.MovePiece((5, 1), (5, 2)));
            // Black king to e7
            Assert.IsTrue(chessBoard.MovePiece((5, 8), (5, 7)));
            // White king to f3
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (6, 3)));
            // Black king to f6
            Assert.IsTrue(chessBoard.MovePiece((5, 7), (6, 6)));

            // White king to g4
            // The black king shouldn't be able to move within the white king's range
            Assert.IsTrue(chessBoard.MovePiece((6, 3), (7, 4)));
            Assert.IsTrue(board[(6, 6)].AvailableMoves.Count == 3);
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // Black king to g6
            // This cuts off either king from moving forward at all
            Assert.IsTrue(chessBoard.MovePiece((6, 6), (7, 6)));
            Assert.IsTrue(board[(7, 6)].AvailableMoves.Count == 2);
            Assert.IsTrue(board[(7, 4)].AvailableMoves.Count == 3);
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");
        }

        /// <summary>
        /// Tests that castling appears as an available move for a king when it should
        /// </summary>
        [TestMethod]
        public void TestCastling_Verification()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            // White pawn to e4
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (5, 4)));
            // Black pawn to e5
            Assert.IsTrue(chessBoard.MovePiece((5, 7), (5, 5)));

            // Neither king can castle, bishop and knight in the way
            Assert.IsTrue(board[(5, 1)].AvailableMoves.Count == 1);
            Assert.IsTrue(board[(5, 8)].AvailableMoves.Count == 1);

            // White knight to f3
            Assert.IsTrue(chessBoard.MovePiece((7, 1), (6, 3)));
            // Black knight to f6
            Assert.IsTrue(chessBoard.MovePiece((7, 8), (6, 6)));

            // Neither king can castle, bishop in the way
            Assert.IsTrue(board[(5, 1)].AvailableMoves.Count == 1);
            Assert.IsTrue(board[(5, 8)].AvailableMoves.Count == 1);

            // White bishop to c4
            Assert.IsTrue(chessBoard.MovePiece((6, 1), (3, 4)));
            // Black bishop to c5
            Assert.IsTrue(chessBoard.MovePiece((6, 8), (3, 5)));

            // Both kings can castle
            Assert.IsTrue(board[(5, 1)].AvailableMoves.Count == 3);
            Assert.IsTrue(board[(5, 8)].AvailableMoves.Count == 3);
            Assert.IsTrue(board[(5, 1)].AvailableMoves.Contains((7, 1)));
            Assert.IsTrue(board[(5, 8)].AvailableMoves.Contains((7, 8)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // White knight to g1
            Assert.IsTrue(chessBoard.MovePiece((6, 3), (7, 1)));
            // Black knight to g8
            Assert.IsTrue(chessBoard.MovePiece((6, 6), (7, 8)));

            // Neither king can castle anymore
            Assert.IsTrue(board[(5, 1)].AvailableMoves.Count == 2);
            Assert.IsTrue(board[(5, 8)].AvailableMoves.Count == 2);
            Assert.IsFalse(board[(5, 1)].AvailableMoves.Contains((7, 1)));
            Assert.IsFalse(board[(5, 8)].AvailableMoves.Contains((7, 8)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // White knight to f3
            Assert.IsTrue(chessBoard.MovePiece((7, 1), (6, 3)));
            // Black knight to f6
            Assert.IsTrue(chessBoard.MovePiece((7, 8), (6, 6)));

            // White rook to g1
            Assert.IsTrue(chessBoard.MovePiece((8, 1), (7, 1)));
            // Black king to e7
            Assert.IsTrue(chessBoard.MovePiece((5, 8), (5, 7)));

            // Neither king can castle
            Assert.IsTrue(board[(5, 1)].AvailableMoves.Count == 2);
            Assert.IsTrue(board[(5, 7)].AvailableMoves.Count == 3);
            Assert.IsFalse(board[(5, 1)].AvailableMoves.Contains((7, 1)));
            Assert.IsFalse(board[(5, 7)].AvailableMoves.Contains((7, 8)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // White rook to h1
            Assert.IsTrue(chessBoard.MovePiece((7, 1), (8, 1)));
            // Black king to e8
            Assert.IsTrue(chessBoard.MovePiece((5, 7), (5, 8)));

            // Neither king can castle, white rook and black king have moved
            Assert.IsTrue(board[(5, 1)].AvailableMoves.Count == 2);
            Assert.IsTrue(board[(5, 8)].AvailableMoves.Count == 2);
            Assert.IsFalse(board[(5, 1)].AvailableMoves.Contains((7, 1)));
            Assert.IsFalse(board[(5, 8)].AvailableMoves.Contains((7, 8)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // White pawn to d4
            Assert.IsTrue(chessBoard.MovePiece((4, 2), (4, 4)));
            // Black pawn to d5
            Assert.IsTrue(chessBoard.MovePiece((4, 7), (4, 5)));

            // White queen to e2
            Assert.IsTrue(chessBoard.MovePiece((4, 1), (5, 2)));
            // Black queen to e7
            Assert.IsTrue(chessBoard.MovePiece((4, 8), (5, 7)));
            // White bishop to d2
            Assert.IsTrue(chessBoard.MovePiece((3, 1), (4, 2)));
            // Black bishop to d7
            Assert.IsTrue(chessBoard.MovePiece((3, 8), (4, 7)));
            // White knight to c3
            Assert.IsTrue(chessBoard.MovePiece((2, 1), (3, 3)));
            // Black knight to c6
            Assert.IsTrue(chessBoard.MovePiece((2, 8), (3, 6)));

            // White king can castle queen side, he hasn't moved
            // Black king can't castle at all, he already moved
            Assert.IsTrue(board[(5, 1)].AvailableMoves.Count == 3);
            Assert.IsTrue(board[(5, 8)].AvailableMoves.Count == 2);
            Assert.IsTrue(board[(5, 1)].AvailableMoves.Contains((3, 1)));
            Assert.IsFalse(board[(5, 8)].AvailableMoves.Contains((3, 8)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");
        }

        /// <summary>
        /// Tests that castling works as intended, first with both kings castling king-side
        /// </summary>
        [TestMethod]
        public void TestCastling_KingSide()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            // White pawn to e4
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (5, 4)));
            // Black pawn to e5
            Assert.IsTrue(chessBoard.MovePiece((5, 7), (5, 5)));
            // White knight to f3
            Assert.IsTrue(chessBoard.MovePiece((7, 1), (6, 3)));
            // Black knight to f6
            Assert.IsTrue(chessBoard.MovePiece((7, 8), (6, 6)));
            // White bishop to c4
            Assert.IsTrue(chessBoard.MovePiece((6, 1), (3, 4)));
            // Black bishop to c5
            Assert.IsTrue(chessBoard.MovePiece((6, 8), (3, 5)));

            // White king castles
            Assert.IsTrue(chessBoard.MovePiece((5, 1), (7, 1)));
            // Black king castles
            Assert.IsTrue(chessBoard.MovePiece((5, 8), (7, 8)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");
        }

        /// <summary>
        /// Tests that castling works as intended, now with both kings castling queen-side
        /// </summary>
        [TestMethod]
        public void TestCastling_QueenSide()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            // White pawn to d4
            Assert.IsTrue(chessBoard.MovePiece((4, 2), (4, 4)));
            // Black pawn to d5
            Assert.IsTrue(chessBoard.MovePiece((4, 7), (4, 5)));
            // White knight to c3
            Assert.IsTrue(chessBoard.MovePiece((2, 1), (3, 3)));
            // Black knight to c6
            Assert.IsTrue(chessBoard.MovePiece((2, 8), (3, 6)));
            // White bishop to e3
            Assert.IsTrue(chessBoard.MovePiece((3, 1), (5, 3)));
            // Black bishop to e6
            Assert.IsTrue(chessBoard.MovePiece((3, 8), (5, 6)));
            // White queen to d3
            Assert.IsTrue(chessBoard.MovePiece((4, 1), (4, 3)));
            // Black queen to d6
            Assert.IsTrue(chessBoard.MovePiece((4, 8), (4, 6)));

            // White king castles
            Assert.IsTrue(chessBoard.MovePiece((5, 1), (3, 1)));
            // Black king castles
            Assert.IsTrue(chessBoard.MovePiece((5, 8), (3, 8)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");
        }

        /// <summary>
        /// Tests that you can't castle into check, even if all other conditions are met
        /// </summary>
        [TestMethod]
        public void TestCastling_IntoCheck()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            // White pawn to e4
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (5, 4)));
            // Black pawn to e5
            Assert.IsTrue(chessBoard.MovePiece((5, 7), (5, 5)));
            // White knight to h3
            Assert.IsTrue(chessBoard.MovePiece((7, 1), (8, 3)));
            // Black knight to f6
            Assert.IsTrue(chessBoard.MovePiece((7, 8), (6, 6)));
            // White bishop to c4
            Assert.IsTrue(chessBoard.MovePiece((6, 1), (3, 4)));
            // Black bishop to c5
            Assert.IsTrue(chessBoard.MovePiece((6, 8), (3, 5)));
            // White pawn to f4
            Assert.IsTrue(chessBoard.MovePiece((6, 2), (6, 4)));

            // Black king castles
            // But the white king can't castle, they'd be moving into check
            Assert.IsTrue(chessBoard.MovePiece((5, 8), (7, 8)));
            Assert.IsTrue(board[(5, 1)].AvailableMoves.Count == 2);
            Assert.IsFalse(board[(5, 1)].AvailableMoves.Contains((7, 1)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // White pawn to d4
            // This blocks the bishop's line, so the white king can now castle
            Assert.IsTrue(chessBoard.MovePiece((4, 2), (4, 4)));
            Assert.IsTrue(board[(5, 1)].AvailableMoves.Count == 5);
            Assert.IsTrue(board[(5, 1)].AvailableMoves.Contains((7, 1)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // Black bishop to b6
            Assert.IsTrue(chessBoard.MovePiece((3, 5), (2, 6)));

            // White king castles
            // Now the white knight is pinned
            Assert.IsTrue(chessBoard.MovePiece((5, 1), (7, 1)));
            Assert.IsTrue(board[(4, 4)].AvailableMoves.Count == 0);
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");
        }

        /// <summary>
        /// Tests that you cannot castle out of check, even if all other conditions are met
        /// </summary>
        [TestMethod]
        public void TestCastling_OutOfCheck()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            // White pawn to e4
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (5, 4)));
            // Black pawn to e5
            Assert.IsTrue(chessBoard.MovePiece((5, 7), (5, 5)));
            // White knight to f3
            Assert.IsTrue(chessBoard.MovePiece((7, 1), (6, 3)));
            // Black knight to f6
            Assert.IsTrue(chessBoard.MovePiece((7, 8), (6, 6)));
            // White bishop to c4
            Assert.IsTrue(chessBoard.MovePiece((6, 1), (3, 4)));
            // Black knight to c6
            Assert.IsTrue(chessBoard.MovePiece((2, 8), (3, 6)));
            // White pawn to d4
            Assert.IsTrue(chessBoard.MovePiece((4, 2), (4, 4)));
            
            // Black bishop to b4
            // White king would be able to castle, but can't due to check
            Assert.IsTrue(chessBoard.MovePiece((6, 8), (2, 4)));
            Assert.IsTrue(board[(5, 1)].AvailableMoves.Count == 2);
            Assert.IsFalse(board[(5, 1)].AvailableMoves.Contains((7, 1)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // White queen to d2
            // This blocks check, so the white king could castle again
            Assert.IsTrue(chessBoard.MovePiece((4, 1), (4, 2)));
            Assert.IsTrue(board[(5, 1)].AvailableMoves.Count == 4);
            Assert.IsTrue(board[(5, 1)].AvailableMoves.Contains((7, 1)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");
        }
        
        // Tests a basic case for en passant, first for white, then for black
        [TestMethod]
        public void TestEnPassant_Basic()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            // White pawn to e4
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (5, 4)));
            // Black pawn to a5
            Assert.IsTrue(chessBoard.MovePiece((1, 7), (1, 5)));
            // White pawn to e5
            Assert.IsTrue(chessBoard.MovePiece((5, 4), (5, 5)));
            
            // Black pawn to d5
            // White should be able to en passant
            Assert.IsTrue(chessBoard.MovePiece((4, 7), (4, 5)));
            Assert.IsTrue(board[(5, 5)].AvailableMoves.Contains((4, 6)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // White pawn to d6
            // En passant; black pawn at d5 should be captured
            Assert.IsTrue(chessBoard.MovePiece((5, 5), (4, 6)));
            Assert.IsTrue(chessBoard.CapturedPieces.Count == 1);
            Assert.IsFalse(board.ContainsKey((4, 5)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // Black pawn to a4
            Assert.IsTrue(chessBoard.MovePiece((1, 5), (1, 4)));
            
            // White pawn to b4
            // Black should be able to en passant
            Assert.IsTrue(chessBoard.MovePiece((2, 2), (2, 4)));
            Assert.IsTrue(board[(1, 4)].AvailableMoves.Contains((2, 3)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // Black pawn to b3
            // En passant; white pawn at b4 should be captured
            Assert.IsTrue(chessBoard.MovePiece((1, 4), (2, 3)));
            Assert.IsTrue(chessBoard.CapturedPieces.Count == 2);
            Assert.IsFalse(board.ContainsKey((2, 4)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");
        }

        /// <summary>
        /// Tests that an opportunity for en passant is only available for one turn, even if the
        /// pawn setup doesn't change
        /// </summary>
        [TestMethod]
        public void TestEnPassant_GoesAway()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            // White pawn to e4
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (5, 4)));
            // Black pawn to a5
            Assert.IsTrue(chessBoard.MovePiece((1, 7), (1, 5)));
            // White pawn to e5
            Assert.IsTrue(chessBoard.MovePiece((5, 4), (5, 5)));
            
            // Black pawn to d5
            // White can en passant
            Assert.IsTrue(chessBoard.MovePiece((4, 7), (4, 5)));
            Assert.IsTrue(board[(5, 5)].AvailableMoves.Contains((4, 6)));
            
            // White pawn to h4
            // White has given up the opportunity for en passant
            Assert.IsTrue(chessBoard.MovePiece((8, 2), (8, 4)));
            Assert.IsFalse(board[(5, 5)].AvailableMoves.Contains((4, 6)));
        }

        /// <summary>
        /// Tests that an opportunity for en passant goes away if not taken, but a new one can replace
        /// it on the very next turn (trust me this is relevant for the way I coded en passant
        /// </summary>
        [TestMethod]
        public void TestEnPassant_CanChange()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            // White pawn to e4
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (5, 4)));
            // Black pawn to a5
            Assert.IsTrue(chessBoard.MovePiece((1, 7), (1, 5)));
            // White pawn to e5
            Assert.IsTrue(chessBoard.MovePiece((5, 4), (5, 5)));
            // Black pawn to a4;
            Assert.IsTrue(chessBoard.MovePiece((1, 5), (1, 4)));

            // White pawn to b4
            // Black can en passant
            Assert.IsTrue(chessBoard.MovePiece((2, 2), (2, 4)));
            Assert.IsTrue(board[(1, 4)].AvailableMoves.Contains((2, 3)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // Black pawn to d5
            // Black can no longer en passant
            // White can en passant
            Assert.IsTrue(chessBoard.MovePiece((4, 7), (4, 5)));
            Assert.IsFalse(board[(1, 4)].AvailableMoves.Contains((2, 3)));
            Assert.IsTrue(board[(5, 5)].AvailableMoves.Contains((4, 6)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");
        }

        /// <summary>
        /// Tests that the usual rules for moving into work with the special case of en passant
        /// </summary>
        [TestMethod]
        public void TestEnPassant_MovingIntoCheck()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            // White pawn to e4
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (5, 4)));
            // Black pawn to e6
            Assert.IsTrue(chessBoard.MovePiece((5, 7), (5, 6)));
            // White queen to f3
            Assert.IsTrue(chessBoard.MovePiece((4, 1), (6, 3)));
            // Black queen to e7
            Assert.IsTrue(chessBoard.MovePiece((4, 8), (5, 7)));
            // White queen to f5
            Assert.IsTrue(chessBoard.MovePiece((6, 3), (6, 5)));
            // Black pawn to f5
            Assert.IsTrue(chessBoard.MovePiece((5, 6), (6, 5)));
            // White pawn to e5
            Assert.IsTrue(chessBoard.MovePiece((5, 4), (5, 5)));

            // Black pawn to d5
            // Normally white could en passant, but can't because that would be moving into check
            Assert.IsTrue(chessBoard.MovePiece((4, 7), (4, 5)));
            Assert.IsFalse(board[(5, 5)].AvailableMoves.Contains((4, 6)));

            // White king to d1
            // King is out of the way now
            // But white still can't en passant, the opportunity is lost
            Assert.IsTrue(chessBoard.MovePiece((5, 1), (4, 1)));
            Assert.IsFalse(board[(5, 5)].AvailableMoves.Contains((4, 6)));
        }

        /// <summary>
        /// Tests that the usual rules for moving out of check with the special case of en passant
        /// </summary>
        [TestMethod]
        public void TestEnPassant_MovingOutOfCheck()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            // White pawn to e4
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (5, 4)));
            // Black pawn to h6
            Assert.IsTrue(chessBoard.MovePiece((8, 7), (8, 6)));
            // White king to e2
            Assert.IsTrue(chessBoard.MovePiece((5, 1), (5, 2)));
            // Black pawn to h5
            Assert.IsTrue(chessBoard.MovePiece((8, 6), (8, 5)));
            // White king to d3
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (4, 3)));
            // Black pawn to h4
            Assert.IsTrue(chessBoard.MovePiece((8, 5), (8, 4)));
            // White king to c4
            Assert.IsTrue(chessBoard.MovePiece((4, 3), (3, 4)));
            // Black pawn to h3
            Assert.IsTrue(chessBoard.MovePiece((8, 4), (8, 3)));
            // White pawn to e5
            Assert.IsTrue(chessBoard.MovePiece((5, 4), (5, 5)));

            // Black pawn to d5
            // White king is in check
            // En passant is certainly... an option
            Assert.IsTrue(chessBoard.MovePiece((4, 7), (4, 5)));
            Assert.IsTrue(board[(5, 5)].AvailableMoves.Contains((4, 6)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // White pawn to d6
            // En passant out of check
            Assert.IsTrue(chessBoard.MovePiece((5, 5), (4, 6)));
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");
        }

        /// <summary>
        /// Tests a basic case for pawn promotion, with the default promotion method which just replaces
        /// a pawn with a queen
        /// </summary>
        [TestMethod]
        public void TestPromotion_Basic()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            // White pawn to e4
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (5, 4)));
            //Black pawn to f5
            Assert.IsTrue(chessBoard.MovePiece((6, 7), (6, 5)));
            // White pawn to f5
            Assert.IsTrue(chessBoard.MovePiece((5, 4), (6, 5)));
            // Black pawn to g6
            Assert.IsTrue(chessBoard.MovePiece((7, 7), (7, 6)));
            // White pawn to g6
            Assert.IsTrue(chessBoard.MovePiece((6, 5), (7, 6)));
            // Black pawn to h5
            Assert.IsTrue(chessBoard.MovePiece((8, 7), (8, 5)));
            // White pawn to g7
            Assert.IsTrue(chessBoard.MovePiece((7, 6), (7, 7)));
            // Black pawn to h4
            Assert.IsTrue(chessBoard.MovePiece((8, 5), (8, 4)));

            // White pawn to h8
            // Promoted to queen
            Assert.IsTrue(chessBoard.MovePiece((7, 7), (8, 8)));
            Assert.IsTrue(board[(8, 8)].Type == "queen");
            Assert.IsTrue(board[(8, 8)].AvailableMoves.Count == 10);
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");

            // Black bishop to g7
            // Threatens this new queen
            Assert.IsTrue(chessBoard.MovePiece((6, 8), (7, 7)));
            Assert.IsTrue(board[(7, 7)].AvailableMoves.Contains((8, 8)));
            Assert.IsTrue(board[(8, 8)].AvailableMoves.Count == 6);
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");
        }

        /// <summary>
        /// Tests that a promotion can suddenly put a king in check
        /// </summary>
        [TestMethod]
        public void TestPromotion_Check()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            // White pawn to e4
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (5, 4)));
            //Black pawn to f5
            Assert.IsTrue(chessBoard.MovePiece((6, 7), (6, 5)));
            // White pawn to f5
            Assert.IsTrue(chessBoard.MovePiece((5, 4), (6, 5)));
            // Black pawn to g6
            Assert.IsTrue(chessBoard.MovePiece((7, 7), (7, 6)));
            // White pawn to g6
            Assert.IsTrue(chessBoard.MovePiece((6, 5), (7, 6)));
            // Black bishop to h6
            Assert.IsTrue(chessBoard.MovePiece((6, 8), (8, 6)));
            // White pawn to g7
            Assert.IsTrue(chessBoard.MovePiece((7, 6), (7, 7)));
            // Black knight to f6
            Assert.IsTrue(chessBoard.MovePiece((7, 8), (6, 6)));

            // White pawn to g8
            // Promoted to queen
            // Black is in check
            Assert.IsTrue(chessBoard.MovePiece((7, 7), (7, 8)));
            Assert.IsTrue(board[(8, 8)].AvailableMoves.Count == 1);
            Assert.IsTrue(board[(8, 6)].AvailableMoves.Count == 1);
            Assert.IsTrue(board[(6, 6)].AvailableMoves.Count == 1);
            Assert.IsTrue(board[(5, 8)].AvailableMoves.Count == 0);
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");
        }

        /// <summary>
        /// Tests a very basic checkmate setup using the Fool's Mate opening
        /// </summary>
        [TestMethod]
        public void TestCheckmate()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            // White pawn to f3
            Assert.IsTrue(chessBoard.MovePiece((6, 2), (6, 3)));
            // Black pawn to e5
            Assert.IsTrue(chessBoard.MovePiece((5, 7), (5, 5)));
            // White pawn to g4
            Assert.IsTrue(chessBoard.MovePiece((7, 2), (7, 4)));

            // Black queen to h4
            // White has no moves
            // Checkmate
            Assert.IsTrue(chessBoard.MovePiece((4, 8), (8, 4)));
            Assert.IsTrue(chessBoard.GameOver);
            PrintAllPiecesMoves(board);
            Debug.WriteLine("");
        }

        /// <summary>
        /// Tests a... decidedly less basic stalemate setup
        /// </summary>
        [TestMethod]
        public void TestStalemate()
        {
            Chessboard chessBoard = new();
            Dictionary<(int, int), ChessPiece> board = chessBoard.GameBoard;

            // White pawn to e3
            Assert.IsTrue(chessBoard.MovePiece((5, 2), (5, 3)));
            // Black pawn to a5
            Assert.IsTrue(chessBoard.MovePiece((1, 7), (1, 5)));
            // White queen to h5
            Assert.IsTrue(chessBoard.MovePiece((4, 1), (8, 5)));
            // Black rook to a6
            Assert.IsTrue(chessBoard.MovePiece((1, 8), (1, 6)));
            // White queen to a5
            Assert.IsTrue(chessBoard.MovePiece((8, 5), (1, 5)));
            // Black pawn to h5
            Assert.IsTrue(chessBoard.MovePiece((8, 7), (8, 5)));
            // White pawn to h4
            Assert.IsTrue(chessBoard.MovePiece((8, 2), (8, 4)));
            // Black rook to h6
            Assert.IsTrue(chessBoard.MovePiece((1, 6), (8, 6)));
            // White queen to c7
            Assert.IsTrue(chessBoard.MovePiece((1, 5), (3, 7)));
            // Black pawn to f6
            Assert.IsTrue(chessBoard.MovePiece((6, 7), (6, 6)));
            // White queen to d7
            Assert.IsTrue(chessBoard.MovePiece((3, 7), (4, 7)));
            // Black king to f7
            Assert.IsTrue(chessBoard.MovePiece((5, 8), (6, 7)));
            // White queen to b7
            Assert.IsTrue(chessBoard.MovePiece((4, 7), (2, 7)));
            // Black queen to d3
            Assert.IsTrue(chessBoard.MovePiece((4, 8), (4, 3)));
            // White queen to b8
            Assert.IsTrue(chessBoard.MovePiece((2, 7), (2, 8)));
            // Black queen to h7
            Assert.IsTrue(chessBoard.MovePiece((4, 3), (8, 7)));
            // White queen to c8
            Assert.IsTrue(chessBoard.MovePiece((2, 8), (3, 8)));
            // Black king to g6
            Assert.IsTrue(chessBoard.MovePiece((6, 7), (7, 6)));
            
            // White queen to e6
            // Black is not in check but has no moves
            // Stalemate
            Assert.IsTrue(chessBoard.MovePiece((3, 8), (5, 6)));
            Assert.IsTrue(chessBoard.GameOver);
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