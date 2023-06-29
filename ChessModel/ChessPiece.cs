namespace ChessModels
{
    public class ChessPiece
    {
        // 1 for white, -1 for black
        public int Color { get; protected set; }

        // String will always be exact piece name (king, queen, rook, bishop, knight, or pawn)
        public string Type { get; protected set; }

        public bool Captured { get; set; }

        public bool HasMoved { get; set; }

        public HashSet<(int, int)> AvailableMoves { get; set; }

        // List of moves a piece would be able to move to, but are blocked by a piece they can't capture
        public HashSet<(int, int)> BlockedMoves { get; set; }

        // List of moves a piece would be able to move to, but can't because that player is in check
        public HashSet<(int, int)> BlockedMovesFromCheck { get; set; }

        // These hash sets are only filled if the piece is a bishop, rook, or queen who is on the same relevant row or diagonal as the enemy king
        // Item 1 is the squares of all pieces between the piece and the enemy king
        // Item 2 is all squares between the piece and the enemy king (including all those in Item 1)
        // Item 3 is the square behind the king, which the king can't move to to escape check
        public (HashSet<(int, int)>, HashSet<(int, int)>, HashSet<(int, int)>) PotentialLineOfCheck { get; set; }

        /// <summary>
        /// Creates a new instance of the ChessPiece class, given defining parameters
        /// </summary>
        public ChessPiece(int color, string type) 
        {
            Color = color;
            Type = type;
            
            Captured = false;
            HasMoved = false;
            AvailableMoves = new();
            BlockedMoves = new();
            BlockedMovesFromCheck = new();

            PotentialLineOfCheck = (new HashSet<(int, int)>(), new HashSet<(int, int)>(), new HashSet<(int, int)>());
        }
    }
}
