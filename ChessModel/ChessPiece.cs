﻿namespace ChessModels
{
    public class ChessPiece
    {
        // 1 for white, -1 for black
        public int Color { get; protected set; }

        // String will always be exact piece name (king, queen, rook, bishop, knight, or pawn)
        public string Type { get; protected set; }

        public bool Captured { get; set; }

        public HashSet<(int, int)> AvailableMoves { get; set; }

        // List of moves a piece would be able to move to, but are blocked by a piece they can't capture
        public HashSet<(int, int)> BlockedMoves { get; set; }

        // These hash sets are only filled if the piece is a bishop, rook, or queen who is on the same relevant row or diagonal as the enemy king
        // Item 1 is the squares of all pieces between the piece and the enemy king
        // Item 2 is all squares between the piece and the enemy king (including all those in Item 1)
        public (HashSet<(int, int)>, HashSet<(int, int)>) PotentialLineOfCheck { get; set; }

        /// <summary>
        /// Creates a new instance of the ChessPiece class, given defining parameters
        /// </summary>
        public ChessPiece(int color, string type, bool captured) 
        {
            Color = color;
            Type = type;
            Captured = captured;

            AvailableMoves = new();
            BlockedMoves = new();

            PotentialLineOfCheck = (new HashSet<(int, int)>(), new HashSet<(int, int)>());
        }
    }
}
