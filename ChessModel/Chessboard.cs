using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Xml;

namespace ChessModels
{
    public class Chessboard
    {
        public Dictionary<(int, int), ChessPiece> GameBoard { get; protected set; }
        public HashSet<ChessPiece> CapturedPieces { get; protected set; }

        private int inCheck;
        // Empty until a king is in check, then the piece attacking the king is put in here
        // Rare cases exist where multiple pieces are attacking the king's current position, which is why this is a HashSet
        private HashSet<(int, int)> attacker;

        private Dictionary<int, (int, int)> enemyKingLocations;

        private int turn;

        /// <summary>
        /// Constructor which initializes all pieces and values.
        /// </summary>
        public Chessboard()
        {
            GameBoard = new();
            CapturedPieces = new();
            
            enemyKingLocations = new();
            enemyKingLocations.Add(-1, (5, 1));
            enemyKingLocations.Add(1, (5, 8));

            inCheck = 0;
            attacker = new();

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
                UpdatePossibleMoves(entry.Key.Item1, entry.Key.Item2, entry.Value);
            }
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
                inCheck = 0;
                attacker.Clear();

                foreach (ChessPiece piece in GameBoard.Values)
                {
                    foreach ((int, int) move in piece.BlockedMovesFromCheck)
                    {
                        piece.AvailableMoves.Add(move);
                    }
                    piece.BlockedMovesFromCheck.Clear();
                }

                if ((GameBoard[newPosition].Type == "king"))
                {
                    switch (GameBoard[newPosition].Color)
                    {
                        case -1:
                            enemyKingLocations[1] = newPosition;
                            break;
                        case 1:
                            enemyKingLocations[-1] = newPosition;
                            break;
                    }
                }
                turn++;

                foreach (var entry in GameBoard)
                {
                    if (entry.Value.Type == "bishop" || entry.Value.Type == "queen")
                    {
                        UpdateCheckLinesDiagonal(entry.Key.Item1, entry.Key.Item2, entry.Value);
                        foreach ((int, int) piece in entry.Value.PotentialLineOfCheck.Item1)
                        {
                            UpdatePossibleMoves(piece.Item1, piece.Item2, GameBoard[(piece.Item1, piece.Item2)]);
                        }
                    }

                    if (entry.Value.Type == "rook" || entry.Value.Type == "queen")
                    {
                        UpdateCheckLinesStraight(entry.Key.Item1, entry.Key.Item2, entry.Value);
                        foreach ((int, int) piece in entry.Value.PotentialLineOfCheck.Item1)
                        {
                            UpdatePossibleMoves(piece.Item1, piece.Item2, GameBoard[(piece.Item1, piece.Item2)]);
                        }
                    }
                    
                    if (entry.Value.AvailableMoves.Contains(oldPosition) || entry.Value.BlockedMoves.Contains(oldPosition) ||
                        entry.Value.AvailableMoves.Contains(newPosition) || entry.Value.BlockedMoves.Contains(newPosition))
                    {
                        UpdatePossibleMoves(entry.Key.Item1, entry.Key.Item2, entry.Value);
                    }
                }
                foreach (var entry in GameBoard)
                {
                    if (entry.Value.Type == "pawn")
                    {
                        for (int i = -1; i < 2; i += 2)
                        {
                            (int, int) move = (entry.Key.Item1 + i, entry.Key.Item2 + entry.Value.Color);
                            if (GameBoard[enemyKingLocations[entry.Value.Color]].AvailableMoves.Remove(move))
                            {
                                GameBoard[enemyKingLocations[entry.Value.Color]].BlockedMovesFromCheck.Add(move);
                            }
                        }
                        continue;
                    }
                    foreach ((int, int) move in entry.Value.AvailableMoves)
                    {
                        try
                        {
                            if (GameBoard[enemyKingLocations[entry.Value.Color]].AvailableMoves.Remove(move))
                            {
                                GameBoard[enemyKingLocations[entry.Value.Color]].BlockedMovesFromCheck.Add(move);
                            }
                        }
                        catch (KeyNotFoundException) { }
                    }
                    foreach ((int, int) move in entry.Value.BlockedMoves)
                    {
                        try
                        {
                            if (GameBoard[enemyKingLocations[entry.Value.Color]].AvailableMoves.Remove(move))
                            {
                                GameBoard[enemyKingLocations[entry.Value.Color]].BlockedMovesFromCheck.Add(move);
                            }
                        }
                        catch (KeyNotFoundException) { }
                    }
                    foreach ((int, int) move in entry.Value.BlockedMovesFromCheck)
                    {
                        try
                        {
                            if (GameBoard[enemyKingLocations[entry.Value.Color]].AvailableMoves.Remove(move))
                            {
                                GameBoard[enemyKingLocations[entry.Value.Color]].BlockedMovesFromCheck.Add(move);
                            }
                        }
                        catch (KeyNotFoundException) { }
                    }

                    if (attacker.Contains(entry.Key))
                    {
                        try
                        {
                            if (GameBoard[enemyKingLocations[entry.Value.Color]].AvailableMoves.Remove(entry.Value.PotentialLineOfCheck.Item3.ToArray()[0]))
                            {
                                GameBoard[enemyKingLocations[entry.Value.Color]].BlockedMovesFromCheck.Add(entry.Value.PotentialLineOfCheck.Item3.ToArray()[0]);
                            }
                        }
                        catch (IndexOutOfRangeException) { }
                    }
                }
               
                CheckForCheck();

                return true;

                //TODO these haven't been implemented and I'm not entirely sure how they'll end up conveying their results
                //CheckForCheck();
                //CheckForMate();
            }

            return false;
        }

        /// <summary>
        /// Private helper method which updates the potential lines of check of a bishop or queen
        /// </summary>
        private void UpdateCheckLinesDiagonal(int x, int y, ChessPiece piece)
        {
            piece.PotentialLineOfCheck.Item1.Clear();
            piece.PotentialLineOfCheck.Item2.Clear();
            piece.PotentialLineOfCheck.Item3.Clear();

            (int, int) enemyKingLocation = enemyKingLocations[piece.Color];

            int xDistance = enemyKingLocation.Item1 - x;
            int yDistance = enemyKingLocation.Item2 - y;
            int xMultiplier = -1;
            int yMultiplier = -1;

            if (Math.Abs(xDistance) == Math.Abs(yDistance))
            {
                if (xDistance > 0)
                {
                    xMultiplier = 1;
                }

                if (yDistance > 0)
                {
                    yMultiplier = 1;
                }
                piece.PotentialLineOfCheck.Item3.Add((enemyKingLocation.Item1 + xMultiplier, enemyKingLocation.Item2 + yMultiplier));
                for (int i = 1; i < Math.Abs(xDistance); i++)
                {
                    int xi = x + xMultiplier * i;
                    int yi = y + yMultiplier * i;

                    piece.PotentialLineOfCheck.Item2.Add((xi, yi));
                    if (GameBoard.ContainsKey((xi, yi)))
                    {
                        piece.PotentialLineOfCheck.Item1.Add((xi, yi));
                    }
                }
            }
        }

        /// <summary>
        /// Private helper method which updates the potential lines of check of a rook or queen
        /// </summary>
        public void UpdateCheckLinesStraight(int x, int y, ChessPiece piece)
        {
            if (piece.Type == "queen" && piece.PotentialLineOfCheck.Item3.Count() > 0)
            {
                return;
            }

            piece.PotentialLineOfCheck.Item1.Clear();
            piece.PotentialLineOfCheck.Item2.Clear();
            piece.PotentialLineOfCheck.Item3.Clear();

            (int, int) enemyKingLocation = enemyKingLocations[piece.Color];

            if (x == enemyKingLocation.Item1)
            {
                int start = y;
                int end = enemyKingLocation.Item2;

                if (y > enemyKingLocation.Item2)
                {
                    start = enemyKingLocation.Item2;
                    end = y;
                    piece.PotentialLineOfCheck.Item3.Add((x, enemyKingLocation.Item2 - 1));
                } 
                else
                {
                    piece.PotentialLineOfCheck.Item3.Add((x, enemyKingLocation.Item2 + 1));
                }

                for (int i = start + 1; i < end; i++)
                {
                    piece.PotentialLineOfCheck.Item2.Add((x, i));
                    if (GameBoard.ContainsKey((x, i)))
                    {
                        piece.PotentialLineOfCheck.Item1.Add((x, i));
                    }
                }
            } 
            else if (y == enemyKingLocation.Item2)
            {
                int start = x;
                int end = enemyKingLocation.Item1;

                if (x > enemyKingLocation.Item1)
                {
                    start = enemyKingLocation.Item1;
                    end = x;
                    piece.PotentialLineOfCheck.Item3.Add((enemyKingLocation.Item1 - 1, y));
                }
                else
                {
                    piece.PotentialLineOfCheck.Item3.Add((enemyKingLocation.Item1 + 1, y));
                }

                for (int i = start + 1; i < end; i++)
                {
                    piece.PotentialLineOfCheck.Item2.Add((i, y));
                    if (GameBoard.ContainsKey((i, y)))
                    {
                        piece.PotentialLineOfCheck.Item1.Add((i, y));
                    }
                }
            }
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
            ChessPiece piece;

            try
            {
                piece = GameBoard[oldPosition];
            }
            catch (KeyNotFoundException)
            {
                return false;
            }

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
        private void UpdatePossibleMoves(int x, int y, ChessPiece piece)
        {
            HashSet<(int, int)> availableMoves = new();
            HashSet<(int, int)> blockedMoves = new();

            switch (piece.Type)
            {
                case "pawn":
                    availableMoves = GetPossibleMovesPawn(x, y, piece, out blockedMoves);
                    break;
                case "knight":
                    availableMoves = GetPossibleMovesKnight(x, y, piece, out blockedMoves);
                    break;
                case "bishop":
                    availableMoves = GetPossibleMovesBishop(x, y, piece, out blockedMoves);
                    break;
                case "rook":
                    availableMoves = GetPossibleMovesRook(x, y, piece, out blockedMoves);
                    break;
                case "queen":
                    availableMoves = GetPossibleMovesQueen(x, y, piece, out blockedMoves);
                    break;
                case "king":
                    availableMoves = GetPossibleMovesKing(x, y, piece, out blockedMoves);
                    break;
            }

            // Stop from moving into check
            foreach (var entry in GameBoard)
            {
                if (entry.Value.Color != piece.Color && entry.Value.PotentialLineOfCheck.Item1.Count == 1 && entry.Value.PotentialLineOfCheck.Item1.Contains((x, y)))
                {
                    foreach ((int, int) move in availableMoves)
                    {
                        if (!(entry.Value.PotentialLineOfCheck.Item2.Contains(move)))
                        {
                            if (move != entry.Key)
                            {
                                availableMoves.Remove(move);
                                piece.BlockedMovesFromCheck.Add(move);
                            }
                        }
                    }
                }
            }

            if (availableMoves.Contains(enemyKingLocations[piece.Color]))
            {
                attacker.Add((x, y));
                switch (piece.Color)
                {
                    case -1:
                        inCheck = 1;
                        break;
                    case 1:
                        inCheck = -1;
                        break;
                }
            }

            piece.AvailableMoves = availableMoves;
            piece.BlockedMoves = blockedMoves;
        }

        /// <summary>
        /// Private helper method to retrieve possible moves for a given pawn
        /// </summary>
        /// <param name="x">File of this piece</param>
        /// <param name="y">Rank of this piece</param>
        /// <param name="piece">This piece iself</param>
        /// <returns>The updated set of available moves for this piece</returns>
        private HashSet<(int, int)> GetPossibleMovesPawn(int x, int y, ChessPiece piece, out HashSet<(int, int)> blockedMoves)
        {
            int color = piece.Color;

            HashSet<(int, int)> newMoves = new();
            blockedMoves = new();

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
            else
            {
                blockedMoves.Add((x, y + color));
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
                    else
                    {
                        blockedMoves.Add((x + i, y + color));
                    }
                }
                else
                {
                    blockedMoves.Add((x + i, y + color));
                }
            }

            // Check for starting double move
            if ((color == -1 && y == 7) || (color == 1 && y == 2))
            {
                if (!GameBoard.ContainsKey((x, y + color * 2)))
                {
                    newMoves.Add((x, y + color * 2));
                } else
                {
                    blockedMoves.Add((x, y + color * 2));
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
        private HashSet<(int, int)> GetPossibleMovesKnight(int x, int y, ChessPiece piece, out HashSet<(int, int)> blockedMoves)
        {
            HashSet<(int, int)> newMoves = new();
            blockedMoves = new();

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
                        else
                        {
                            blockedMoves.Add((x + i, y + j));
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
                        else
                        {
                            blockedMoves.Add((x + j, y + i));
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
        private HashSet<(int, int)> GetPossibleMovesBishop(int x, int y, ChessPiece piece, out HashSet<(int, int)> blockedMoves)
        {
            HashSet<(int, int)> newMoves = new();
            blockedMoves = new();

            BishopHelper(newMoves, x, y, piece, 1, 1, blockedMoves);
            BishopHelper(newMoves, x, y, piece, 1, -1, blockedMoves);
            BishopHelper(newMoves, x, y, piece, -1, 1, blockedMoves);
            BishopHelper(newMoves, x, y, piece, -1, -1, blockedMoves);

            return newMoves;
        }

        /// <summary>
        /// Private helper method used for determining the available moves for a bishop. During each bishop calculation, 
        /// this method will be called 4 times, each one expanding out in 1 of the 4 diagonal directions from the bishop's
        /// current position
        /// </summary>
        /// <param name="xMultiplier">Always either 1 or -1, determines which horizontal direction we're expanding in</param>
        /// <param name="yMultiplier">Always either 1 or -1, determines which vertical direction we're expanding in</param>
        private void BishopHelper(HashSet<(int, int)> newMoves, int x, int y, ChessPiece piece, int xMultiplier, int yMultiplier, HashSet<(int, int)> blockedMoves)
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
                        blockedMoves.Add((xi, yi));
                        break;
                    }
                } 
                else
                {
                    break;
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
        private HashSet<(int, int)> GetPossibleMovesRook(int x, int y, ChessPiece piece, out HashSet<(int, int)> blockedMoves)
        {
            HashSet<(int, int)> newMoves = new();
            blockedMoves = new();

            // Pretty much the same algorithm as the bishop
            // This time it's split into two separate nested for loops each 2 deep
            // That way we check the 4 cardinal directions rather than 4 diagonal
            for (int g = -1; g < 2; g += 2)
            {
                for (int i = x + g; i < 9 && i > 0; i += g)
                {
                    if (i > 0 && i < 9)
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
                            blockedMoves.Add((i, y));
                            break;
                        }
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
                    if (j > 0 && j < 9)
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
                            blockedMoves.Add((x, j));
                            break;
                        }
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
        private HashSet<(int, int)> GetPossibleMovesQueen(int x, int y, ChessPiece piece, out HashSet<(int, int)> blockedMoves)
        {
            blockedMoves = new();
            HashSet<(int, int)> blockedStraights = new();

            // A queen is just a bishop plus a rook
            HashSet<(int, int)> diagonalMoves = GetPossibleMovesBishop(x, y, piece, out blockedMoves);
            HashSet<(int, int)> straightMoves = GetPossibleMovesRook(x, y, piece, out blockedStraights);

            diagonalMoves.UnionWith(straightMoves);
            blockedMoves.UnionWith(blockedStraights);

            return diagonalMoves;
        }

        /// <summary>
        /// Private helper method to retrieve possible moves for a given king
        /// </summary>
        /// <param name="x">File of this piece</param>
        /// <param name="y">Rank of this piece</param>
        /// <param name="piece">This piece iself</param>
        /// <returns>The updated set of available moves for this piece</returns>
        private HashSet<(int, int)> GetPossibleMovesKing(int x, int y, ChessPiece piece, out HashSet<(int, int)> blockedMoves)
        {
            HashSet<(int, int)> newMoves = new();
            blockedMoves = new();

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
                            else if (GameBoard[(x + i, y + j)].Color != piece.Color)
                            {
                                newMoves.Add((x + i, y + j));
                            } 
                            else
                            {
                                blockedMoves.Add((x + i, y + j));
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
            if (inCheck != 0)
            {
                foreach (ChessPiece piece in GameBoard.Values)
                {
                    if (piece.Color == inCheck && piece.Type != "king")
                    {
                        if (attacker.Count > 1)
                        {
                            foreach ((int, int) move in piece.AvailableMoves)
                            {
                                piece.BlockedMovesFromCheck.Add(move);
                            }
                            piece.AvailableMoves.Clear();
                        }
                        else
                        {
                            (int, int) attackerPosition = attacker.ToList()[0];
                            foreach ((int, int) move in piece.AvailableMoves)
                            {
                                if (!GameBoard[attackerPosition].PotentialLineOfCheck.Item2.Contains(move))
                                {
                                    if (move != attackerPosition)
                                    {
                                        piece.AvailableMoves.Remove(move);
                                        piece.BlockedMovesFromCheck.Add(move);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void CheckForMate()
        {
          
        }
    }
}