namespace ChessModel
{
    public class Chessboard
    {
        public Dictionary<(int, int), ChessPiece> GameBoard { get; protected set; }
        public HashSet<ChessPiece> CapturedPieces;

        private bool whiteInCheck;
        private bool blackInCheck;

        private int turn;

        /// <summary>
        /// Constructor which initializes all pieces and values.
        /// </summary>
        public Chessboard()
        {
            GameBoard = new();
            CapturedPieces = new();
            
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

            UpdateAllPiecesPossibleMoves();
        }
        
        /// <summary>
        /// Changes the location of a given piece, then updates the state of the game board accordingly
        /// </summary>
        /// <param name="oldPosition">Current position of the piece to move</param>
        /// <param name="newPosition">New position to move this piece to</param>
        /// <returns>True if the move was successful, false otherwise</returns>
        public bool MovePiece((int, int) oldPosition, (int, int) newPosition)
        {
            if (UpdateCoordinates(oldPosition, newPosition))
            {
                turn++;
                UpdateAllPiecesPossibleMoves();
                return true;

                //TODO these haven't been implemented and I'm not entirely sure how they'll end up conveying their results
                //CheckForCheck();
                //CheckForMate();
            }

            return false;
        }

        /// <summary>
        /// Private helper method which changes the coordinates of a piece being moved, after ensuring that the desired move
        /// is allowed
        /// </summary>
        /// <param name="oldPosition">Current position of the piece to move</param>
        /// <param name="newPosition">New position we're moving this piece to</param>
        /// <returns>
        /// True if the move is allowed, and was completed. Otherwise, nothing was changed on the board, so the method 
        /// returns false
        /// </returns>
        private bool UpdateCoordinates((int, int) oldPosition, (int, int) newPosition)
        {
            ChessPiece piece = GameBoard[oldPosition];

            if (piece.AvailableMoves.Contains(newPosition))
            {
                GameBoard.Remove(oldPosition);

                if (GameBoard.ContainsKey(newPosition))
                {
                    CapturedPieces.Add(GameBoard[newPosition]);
                    GameBoard[newPosition] = piece;
                } else
                {
                    GameBoard.Add(newPosition, piece);
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// Private helper method which updates the set of possible moves for all pieces on the board. This method is called for
        /// every piece at the start of the game, then updated after every move
        /// </summary>
        private void UpdateAllPiecesPossibleMoves()
        {
            foreach (var entry in GameBoard)
            {
                //TODO deal with moving into check

                int x = entry.Key.Item1;
                int y = entry.Key.Item2;
                ChessPiece piece = entry.Value;

                switch (piece.Type)
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
        }

        /// <summary>
        /// Private helper method to retrieve possible moves for a given pawn
        /// </summary>
        /// <param name="x">File of this piece</param>
        /// <param name="y">Rank of this piece</param>
        /// <param name="piece">This piece iself</param>
        /// <returns>The updated set of available moves for this piece</returns>
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

        /// <summary>
        /// Private helper method to retrieve possible moves for a given knight
        /// </summary>
        /// <param name="x">File of this piece</param>
        /// <param name="y">Rank of this piece</param>
        /// <param name="piece">This piece iself</param>
        /// <returns>The updated set of available moves for this piece</returns>
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

        /// <summary>
        /// Private helper method to retrieve possible moves for a given bishop
        /// </summary>
        /// <param name="x">File of this piece</param>
        /// <param name="y">Rank of this piece</param>
        /// <param name="piece">This piece iself</param>
        /// <returns>The updated set of available moves for this piece</returns>
        private HashSet<(int, int)> GetPossibleMovesBishop(int x, int y, ChessPiece piece)
        {
            HashSet<(int, int)> newMoves = new();

            BishopHelper(newMoves, x, y, piece, 1, 1);
            BishopHelper(newMoves, x, y, piece, 1, -1);
            BishopHelper(newMoves, x, y, piece, -1, 1);
            BishopHelper(newMoves, x, y, piece, -1, -1);

            return newMoves;
        }

        /// <summary>
        /// Private helper method used for determining the available moves for a bishop. During each bishop calculation, 
        /// this method will be called 4 times, each one expanding out in 1 of the 4 diagonal directions from the bishop's
        /// current position
        /// </summary>
        /// <param name="xMultiplier">Always either 1 or -1, determines which horizontal direction we're expanding in</param>
        /// <param name="yMultiplier">Always either 1 or -1, determines which vertical direction we're expanding in</param>
        private void BishopHelper(HashSet<(int, int)> newMoves, int x, int y, ChessPiece piece, int xMultiplier, int yMultiplier)
        {
            for (int i = 1; i < 8; i++)
            {
                int xi = x + xMultiplier * i;
                int yi = y + yMultiplier * i;

                if (xi > 0 && xi < 9 && yi > 0 && yi < 9)
                {
                    // Now we're inside the innermost for loop, so we've reached one individual square to be assessed
                    
                    // If a square is empty, the bishop can move there
                    // If a square has an enemy piece, the bishop can move there, but can't continue any further on the diagonal
                    // If a square has a friendly piece, the bishop can't move there or continue any further on the diagonal
                    if (!GameBoard.ContainsKey((xi, yi)))
                    {
                        newMoves.Add((xi, yi));
                    }
                    else if (GameBoard[(xi, yi)].Color != piece.Color)
                    {
                        newMoves.Add((xi, yi));
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Private helper method to retrieve possible moves for a given rook
        /// </summary>
        /// <param name="x">File of this piece</param>
        /// <param name="y">Rank of this piece</param>
        /// <param name="piece">This piece iself</param>
        /// <returns>The updated set of available moves for this piece</returns>
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

        /// <summary>
        /// Private helper method to retrieve possible moves for a given queen
        /// </summary>
        /// <param name="x">File of this piece</param>
        /// <param name="y">Rank of this piece</param>
        /// <param name="piece">This piece iself</param>
        /// <returns>The updated set of available moves for this piece</returns>
        private HashSet<(int, int)> GetPossibleMovesQueen(int x, int y, ChessPiece piece)
        {
            // A queen is just a bishop plus a rook
            HashSet<(int, int)> diagonalMoves = GetPossibleMovesBishop(x, y, piece);
            HashSet<(int, int)> straightMoves = GetPossibleMovesRook(x, y, piece);

            diagonalMoves.UnionWith(straightMoves);
            return diagonalMoves;
        }

        /// <summary>
        /// Private helper method to retrieve possible moves for a given king
        /// </summary>
        /// <param name="x">File of this piece</param>
        /// <param name="y">Rank of this piece</param>
        /// <param name="piece">This piece iself</param>
        /// <returns>The updated set of available moves for this piece</returns>
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