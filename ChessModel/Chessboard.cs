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
                ChessPiece white = new(1, arr[i], false);
                ChessPiece black = new(-1, arr[i], false);

                GameBoard.Add((i + 1, 1), white);
                GameBoard.Add((i + 1, 8), black);
            }

            // Fill pawns
            for (int i = 1; i < 9; i++)
            {
                ChessPiece whitePawn = new(1, "pawn", false);
                ChessPiece blackPawn = new(-1, "pawn", false);

                GameBoard.Add((i, 2), whitePawn);
                GameBoard.Add((i, 7), blackPawn);
            }

            foreach (var entry in GameBoard) 
            {
                UpdatePossibleMoves(entry.Key, entry.Value);
            }
        }
        
        public void MovePiece((int, int) oldPosition, (int, int) newPosition)
        {

        }

        private void UpdateCoordinates((int, int) oldPosition, (int, int) newPosition)
        {

        }

        /// <summary>
        /// Private helper method which updates the set of possible moves for a given piece. This method is called for every
        /// piece at the start of the game, then updated after every move
        /// </summary>
        /// <param name="position">New position of the piece being moved</param>
        /// <param name="piece">Piece at that position</param>
        private void UpdatePossibleMoves((int, int) position,ChessPiece piece) 
        {
            //TODO deal with moving into check

            int x = position.Item1;
            int y = position.Item2;

            switch(piece.Type) 
            {
                case "pawn":
                    piece.AvailableMoves = GetPossibleMovesPawn(x, y, piece);
                    break;
                case "knight":
                    piece.AvailableMoves = GetPossibleMovesKnight(x, y, piece);
                    break;
                case "bishop":
                    piece.AvailableMoves = GetPossibleMovesBishop(x, y, piece);
                    break;
                case "rook":
                    piece.AvailableMoves = GetPossibleMovesRook(x, y, piece);
                    break;
                case "queen":
                    piece.AvailableMoves = GetPossibleMovesQueen(x, y, piece);
                    break;
                case "king":
                    piece.AvailableMoves = GetPossibleMovesKing(x, y, piece);
                    break;
            }
        }

        private HashSet<(int, int)> GetPossibleMovesPawn(int x, int y, ChessPiece piece)
        {
            int color = piece.Color;

            HashSet<(int, int)> newMoves = new();

            //TODO Check for promotion first
            if ((color == -1 && y == 1) || (color == 1 && y == 8))
            {
                return PromotePawn(x, y);
            }

            // Base case
            if (!(GameBoard.ContainsKey((x, y + color)) || y == 8))
            {
                newMoves.Add((x, y + color));
            }

            // Check for captures
            for (int i = -1; i < 2; i += 2)
            {
                if (GameBoard.ContainsKey((x + i, y + color)))
                {
                    if (GameBoard[(x + i, y + color)].Color != color)
                    {
                        newMoves.Add((x + i, y + color));
                    }
                }
            }

            // Check for starting double move
            if ((color == -1 && y == 7) || (color == 1 && y == 2))
            {
                if (!GameBoard.ContainsKey((x, y + color * 2)))
                {
                    newMoves.Add((x, y + color * 2));
                }
            }

            // TODO Check for en passant

            return newMoves;
        }

        private HashSet<(int, int)> PromotePawn(int x, int y)
        {
            //TODO
            return new HashSet<(int, int)>();
        }

        private HashSet<(int, int)> GetPossibleMovesKnight(int x, int y, ChessPiece piece)
        {
            HashSet<(int, int)> newMoves = new();

            // Nested for loop iterates through all 4 combinations of {1, -1} with {2, -2}
            // Inside each loop iteration, we check the 2 possibilities of (x + i, y + j) as well as (x + j, y + i)
            // 4 * 2 = all 8 possible moves a knight could at most have from any given position have been checked
            for (int i = -2; i < 3; i += 4)
            {
                for (int j = -1; j < 2; j += 2)
                {
                    if (x + i < 9 && x + i > 0 && y + j < 9 && y + j > 0) { 
                        if (!GameBoard.ContainsKey((x + i, y + j)))
                        {
                            newMoves.Add((x + i, y + j));
                        }
                        else if (GameBoard[(x + i, y + j)].Color != piece.Color)
                        {
                            newMoves.Add((x + i, y + j));
                        }
                    }

                    if (x + j < 9 && x + j > 0 && y + i < 9 && y + i > 0)
                    {
                        if (!GameBoard.ContainsKey((x + j, y + i)))
                        {
                            newMoves.Add((x + j, y + i));
                        }
                        else if (GameBoard[(x + j, y + i)].Color != piece.Color)
                        {
                            newMoves.Add((x + j, y + i));
                        }
                    }

                }
            }

            return newMoves;
        }

        private HashSet<(int, int)> GetPossibleMovesBishop(int x, int y, ChessPiece piece)
        {
            HashSet<(int, int)> newMoves = new();

            // 4 nested for loops iterate over the bishop's 4 diagonal directions
            for (int g = -1; g < 2; g += 2)
            {
                for (int i = x + g; i < 9 && i > 0; i += g)
                {
                    for (int h = -1; h < 2; h += 2)
                    {
                        for (int j = y + h; j < 9 && j > 0; j += h)
                        {
                            // If a square is empty, the bishop can move there
                            // If a square has an enemy piece, the bishop can move there, but can't continue any further on the diagonal
                            // If a square has a friendly piece, the bishop can't move there or continue any further on the diagonal
                            if (!GameBoard.ContainsKey((i, j))) {
                                newMoves.Add((i, j));
                            } else if (GameBoard[(i, j)].Color != piece.Color)
                            {
                                newMoves.Add((i, j));
                                break;
                            } else
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return newMoves;
        }

        private HashSet<(int, int)> GetPossibleMovesRook(int x, int y, ChessPiece piece)
        {
            HashSet<(int, int)> newMoves = new();

            // Pretty much the same algorithm as the bishop
            // This time it's split into two separate nested for loops each 2 deep
            // That way we check the 4 cardinal directions rather than 4 diagonal

            for (int g = -1; g < 2; g += 2)
            {
                for (int i = x + g; i < 9 && i > 0; i += g)
                {
                    if (!GameBoard.ContainsKey((i, y)))
                    {
                        newMoves.Add((i, y));
                    }
                    else if (GameBoard[(i, y)].Color != piece.Color)
                    {
                        newMoves.Add((i, y));
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int h = -1; h < 2; h += 2)
            {
                for (int j = y + h; j < 9 && j > 0; j += h)
                {
                    if (!GameBoard.ContainsKey((x, j)))
                    {
                        newMoves.Add((x, j));
                    }
                    else if (GameBoard[(x, j)].Color != piece.Color)
                    {
                        newMoves.Add((x, j));
                        break;
                    }
                    else
                    {
                        break;
                    } 
                }
            }

            return newMoves;
        }

        private HashSet<(int, int)> GetPossibleMovesQueen(int x, int y, ChessPiece piece)
        {
            // A queen is just a bishop plus a rook
            HashSet<(int, int)> diagonalMoves = GetPossibleMovesBishop(x, y, piece);
            HashSet<(int, int)> straightMoves = GetPossibleMovesRook(x, y, piece);

            diagonalMoves.UnionWith(straightMoves);
            return diagonalMoves;
        }

        private HashSet<(int, int)> GetPossibleMovesKing(int x, int y, ChessPiece piece)
        {
            HashSet<(int, int)> newMoves = new();

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (!(i == 0 && j == 0))
                    {
                        if (x + i < 9 && x + i > 0 && y + j < 9 && y + j > 0)
                        {
                            if (!GameBoard.ContainsKey((x + i, y + j)))
                            {
                                newMoves.Add((x + i, y + j));
                            }
                        }
                    }
                }
            }

            // TODO check for castling

            return newMoves;
        }

        private void CheckForCheck()
        {

        }

        private void CheckForMate()
        {
          
        }
        
    }
}