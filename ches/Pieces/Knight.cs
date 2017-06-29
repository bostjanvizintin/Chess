using System;
using System.Collections.Generic;
using System.Drawing;

namespace ches.Pieces
{
    class Knight : Piece
    {
        public Knight(Color color, Point point, Board board) : base(color, point, board)
        {
            m_type = Type.KNIGHT;
        }

       /* public override Point[] GetAllPossiblePaths()
        {
            List<Point> allPaths = new List<Point>();

            if (m_board.GetPieceOnLocation(new Point(this.Location.X + 2, this.Location.Y - 1)) == null || (m_board.GetPieceOnLocation(new Point(this.Location.X + 2, this.Location.Y - 1)) != null && m_board.GetPieceOnLocation(new Point(this.Location.X + 2, this.Location.Y - 1)).Color != this.Color))
            {
                if (this.Location.X + 2 < 8 && this.Location.Y - 1 >= 0)
                {
                    allPaths.Add(new Point(((this.Location.X + 3) * 64 - 32), (this.Location.Y) * 64 - 32));
                }
            }
            if (m_board.GetPieceOnLocation(new Point(this.Location.X + 2, this.Location.Y + 1)) == null || (m_board.GetPieceOnLocation(new Point(this.Location.X + 2, this.Location.Y + 1)) != null && m_board.GetPieceOnLocation(new Point(this.Location.X + 2, this.Location.Y + 1)).Color != this.Color))
            {
                if (this.Location.X + 2 < 8 && this.Location.Y + 1 < 8)
                {
                    allPaths.Add(new Point(((this.Location.X + 3) * 64 - 32), (this.Location.Y + 2) * 64 - 32));
                }
            }
            if (m_board.GetPieceOnLocation(new Point(this.Location.X - 2, this.Location.Y - 1)) == null || (m_board.GetPieceOnLocation(new Point(this.Location.X - 2, this.Location.Y - 1)) != null && m_board.GetPieceOnLocation(new Point(this.Location.X - 2, this.Location.Y - 1)).Color != this.Color))
            {
                if (this.Location.X - 2 >= 0 && this.Location.Y - 1 >= 0)
                {
                    allPaths.Add(new Point(((this.Location.X - 1) * 64 - 32), (this.Location.Y) * 64 - 32));
                }
            }
            if (m_board.GetPieceOnLocation(new Point(this.Location.X - 2, this.Location.Y + 1)) == null || (m_board.GetPieceOnLocation(new Point(this.Location.X - 2, this.Location.Y + 1)) != null && m_board.GetPieceOnLocation(new Point(this.Location.X - 2, this.Location.Y + 1)).Color != this.Color))
            {
                if (this.Location.X - 2 >= 0 && this.Location.Y + 1 < 8)
                {
                    allPaths.Add(new Point(((this.Location.X - 1) * 64 - 32), (this.Location.Y + 2) * 64 - 32));
                }
            }
            if (m_board.GetPieceOnLocation(new Point(this.Location.X + 1, this.Location.Y + 2)) == null || (m_board.GetPieceOnLocation(new Point(this.Location.X + 1, this.Location.Y + 2)) != null && m_board.GetPieceOnLocation(new Point(this.Location.X + 1, this.Location.Y + 2)).Color != this.Color))
            {
                if (this.Location.X + 1 < 8 && this.Location.Y + 2 < 8)
                {
                    allPaths.Add(new Point(((this.Location.X + 2) * 64 - 32), (this.Location.Y + 3) * 64 - 32));
                }
            }
            if (m_board.GetPieceOnLocation(new Point(this.Location.X - 1, this.Location.Y + 2)) == null || (m_board.GetPieceOnLocation(new Point(this.Location.X - 1, this.Location.Y + 2)) != null && m_board.GetPieceOnLocation(new Point(this.Location.X - 1, this.Location.Y + 2)).Color != this.Color))
            {
                if (this.Location.X - 1 >= 0 && this.Location.Y + 2 < 8)
                {
                    allPaths.Add(new Point(((this.Location.X) * 64 - 32), (this.Location.Y + 3) * 64 - 32));
                }
            }
            if (m_board.GetPieceOnLocation(new Point(this.Location.X + 1, this.Location.Y - 2)) == null || (m_board.GetPieceOnLocation(new Point(this.Location.X + 1, this.Location.Y - 2)) != null && m_board.GetPieceOnLocation(new Point(this.Location.X + 1, this.Location.Y - 2)).Color != this.Color))
            {
                if (this.Location.X + 1 < 8 && this.Location.Y - 2 >= 0)
                {
                    allPaths.Add(new Point(((this.Location.X + 2) * 64 - 32), (this.Location.Y - 1) * 64 - 32));
                }
            }
            if (m_board.GetPieceOnLocation(new Point(this.Location.X - 1, this.Location.Y - 2)) == null || (m_board.GetPieceOnLocation(new Point(this.Location.X - 1, this.Location.Y - 2)) != null && m_board.GetPieceOnLocation(new Point(this.Location.X - 1, this.Location.Y - 2)).Color != this.Color))
            {
                if (this.Location.X - 1 >= 0 && this.Location.Y - 2 >= 0)
                {
                    allPaths.Add(new Point(((this.Location.X) * 64 - 32), (this.Location.Y - 1) * 64 - 32));
                }
            }

            return allPaths.ToArray();
        }*/

        public override bool ValidateMove(int x, int y)
        {
            if(IzvenBoarda(x, y))
                return false;

            if(!((this.Location.X == x + 2 && this.Location.Y == y - 1) ||//
               (this.Location.X == x + 2 && this.Location.Y == y + 1) ||//
               (this.Location.X == x - 2 && this.Location.Y == y - 1) ||//
               (this.Location.X == x - 2 && this.Location.Y == y + 1) ||//
               (this.Location.X == x + 1 && this.Location.Y == y + 2) ||//
               (this.Location.X == x - 1 && this.Location.Y == y + 2) ||//
               (this.Location.X == x + 1 && this.Location.Y == y - 2) ||//
               (this.Location.X == x - 1 && this.Location.Y == y - 2)))//
                return false;

            if(!(m_board.GetPieceOnLocation(new Point(x, y)) == null || m_board.GetPieceOnLocation(new Point(x, y)).Color != this.Color))
                return false;

            return true;

        }
    }
}
