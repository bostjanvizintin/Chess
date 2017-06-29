using System;
using System.Drawing;

namespace ches.Pieces
{
    class Rook : Piece
    {
        public Rook(Color color, Point point, Board board) : base(color, point, board)
        {
            m_type = Type.ROOK;
        }

        public override Point[] GetAllPossiblePaths()
        {
            return new Point[] { };
        }

        public override bool ValidateMove(int x, int y)
        {
            if(IzvenBoarda(x, y))
                return false;

            if((x != this.Location.X) == (y != this.Location.Y))
            {
                return false;
            }

            if(x < this.Location.X)
            {
                int tmpx = this.Location.X - 1;

                while(tmpx != x)
                {
                    if(m_board.GetPieceOnLocation(new Point(tmpx--, y)) != null)
                    {
                        return false;
                    }
                }
            }
            else if (x > this.Location.X)
            {
                int tmpx = this.Location.X + 1;

                while(tmpx != x)
                {
                    if(m_board.GetPieceOnLocation(new Point(tmpx++, y)) != null)
                    {
                        return false;
                    }
                }
            }
            else if (y < this.Location.Y)
            {
                int tmpy = this.Location.Y - 1;

                while(tmpy != y)
                {
                    if(m_board.GetPieceOnLocation(new Point(x, tmpy--)) != null)
                    {
                        return false;
                    }
                }
            }
            else if (y > this.Location.Y)
            {
                int tmpy = this.Location.Y +1;

                while(tmpy !=y)
                {
                    if(m_board.GetPieceOnLocation(new Point(x, tmpy++)) != null)
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
