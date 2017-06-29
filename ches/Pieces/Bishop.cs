using System;
using System.Drawing;

namespace ches.Pieces
{
    class Bishop : Piece
    {
        public Bishop(Color color, Point point, Board board) : base(color, point, board)
        {
            m_type = Type.BISHOP;
        }

        public override Point[] GetAllPossiblePaths()
        {
            return new Point[] { };
        }

        public override bool ValidateMove(int x, int y)
        {
            if(IzvenBoarda(x, y))
                return false;

            if((this.Location.X == x || this.Location.Y == y) || !(Math.Abs(this.Location.X - x) == Math.Abs(this.Location.Y - y)))
                return false;

            if(this.Location.X < x && this.Location.Y > y)
            {
                int tmpx = this.Location.X + 1;
                int tmpy = this.Location.Y - 1;

                while(x != tmpx && y != tmpy)
                {
                    if(m_board.GetPieceOnLocation(new Point(tmpx++, tmpy--)) != null)
                    {
                        return false;
                    }
                }
            }
            else if(this.Location.X < x && this.Location.Y < y)
            {
                int tmpx = this.Location.X + 1;
                int tmpy = this.Location.Y + 1;

                while (x != tmpx && y != tmpy)
                {
                    if (m_board.GetPieceOnLocation(new Point(tmpx++, tmpy++)) != null)
                    {
                        return false;
                    }
                }
            }
            else if(this.Location.X > x && this.Location.Y < y)
            {
                int tmpx = this.Location.X - 1;
                int tmpy = this.Location.Y + 1;

                while (x != tmpx && y != tmpy)
                {
                    if (m_board.GetPieceOnLocation(new Point(tmpx--, tmpy++)) != null)
                    {
                        return false;
                    }
                }
            }
            else if(this.Location.X > x && this.Location.Y > y)
            {
                int tmpx = this.Location.X - 1;
                int tmpy = this.Location.Y - 1;

                while (x != tmpx && y != tmpy)
                {
                    if (m_board.GetPieceOnLocation(new Point(tmpx--, tmpy--)) != null)
                    {
                        return false;
                    }
                }
            }
            if (m_board.GetPieceOnLocation(new Point(x, y)) != null && m_board.GetPieceOnLocation(new Point(x, y)).Color == this.Color)
            {
                return false;
            }
            return true;
        }
    }
}
