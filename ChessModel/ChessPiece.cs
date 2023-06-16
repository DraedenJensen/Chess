namespace ChessModel
{
    public class ChessPiece
    {
        // 1 for white, -1 for black
        public int Color { get; protected set; }

        // String will always be exact piece name (king, queen, rook, bishop, knight, or pawn)
        public string Type { get; protected set; }

        public bool Captured { get; set; }

        public HashSet<(int, int)> AvailableMoves { get; set; }

        /// <summary>
        /// Creates a new instance of the ChessPiece class, given defining parameters
        /// </summary>
        public ChessPiece(int color, string type, bool captured) 
        {
            Color = color;
            Type = type;
            Captured = captured;
        }
    }
}
