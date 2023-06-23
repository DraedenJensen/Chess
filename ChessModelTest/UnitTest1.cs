using ChessModels;
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