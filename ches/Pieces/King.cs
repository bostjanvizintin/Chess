using System;
using System.Drawing;

namespace ches.Pieces
{
    class King : Piece
    {
        public King(Color color, Point point, Board board) : base(color, point, board)
        {
            m_type = Type.KING;
        }

        public override Point[] GetAllPossiblePaths()
        {
            return new Point[] { };
        }

        public override bool ValidateMove(int x, int y)
        {
            if(IzvenBoarda(x, y))
                return false;

            if(Math.Abs(this.Location.X - x) > 1 || Math.Abs(this.Location.Y - y) > 1)
                return false;

            if(m_board.GetPieceOnLocation(new Point(x, y)) != null && m_board.GetPieceOnLocation(new Point(x, y)).Color == this.Color)
                return false;

            return true;
        }
    }
}
