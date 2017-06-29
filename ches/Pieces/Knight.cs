using System;
using System.Drawing;

namespace ches.Pieces
{
    class Knight : Piece
    {
        public Knight(Color color, Point point, Board board) : base(color, point, board)
        {
            m_type = Type.KNIGHT;
        }

        public override Point[] GetAllPossiblePaths()
        {
            return new Point[] { };
        }

        public override bool ValidateMove(int x, int y)
        {
            if(IzvenBoarda(x, y))
                return false;

            if(!((this.Location.X == x+2 && this.Location.Y == y-1) ||
               (this.Location.X == x+2 && this.Location.Y == y+1) ||
               (this.Location.X == x-2 && this.Location.Y == y-1) ||
               (this.Location.X == x-2 && this.Location.Y == y+1) ||
               (this.Location.X == x+1 && this.Location.Y == y+2) ||
               (this.Location.X == x-1 && this.Location.Y == y+2) ||
               (this.Location.X == x+1 && this.Location.Y == y-2) ||
               (this.Location.X == x-1 && this.Location.Y == y-2)))
                return false;

            if(!(m_board.GetPieceOnLocation(new Point(x, y)) == null || m_board.GetPieceOnLocation(new Point(x, y)).Color != this.Color))
                return false;

            return true;

        }
    }
}
