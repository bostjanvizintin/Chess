using System;
using System.Collections.Generic;
using System.Drawing;

namespace ches.Pieces
{
    class Queen : Piece
    {
        public Queen(Color color, Point point, Board board) : base(color, point, board)
        {
            m_type = Type.QUEEN;
        }

        public override bool ValidateMove(int x, int y)
        {
            if(IzvenBoarda(x, y))
                return false;

            if(!(this.Location.X == x || this.Location.Y == y || ((Math.Abs(this.Location.X - x)) == (Math.Abs(this.Location.Y - y)))))
            {
                return false;
            }
            
            //Moving west
            if(this.Location.X > x && this.Location.Y == y)
            {
                int tmpx = this.Location.X - 1;

                while (tmpx != x)
                {
                    if(m_board.GetPieceOnLocation(new Point(tmpx--, y)) != null)
                    {
                        return false;
                    }
                }
            }

            //Moving north west
            else if(this.Location.X > x && this.Location.Y > y)
            {
                int tmpx = this.Location.X - 1;
                int tmpy = this.Location.Y - 1;

                while(tmpx != x && tmpy != y)
                {
                    if(m_board.GetPieceOnLocation(new Point(tmpx--, tmpy--)) != null)
                    {
                        return false;
                    }
                }
            }

            //Moving north
            else if(this.Location.X == x && this.Location.Y > y)
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

            //Moving north east
            else if(this.Location.X < x && this.Location.Y > y)
            {
                int tmpx = this.Location.X + 1;
                int tmpy = this.Location.Y - 1;

                while(tmpx != x && tmpy != y)
                {
                    if(m_board.GetPieceOnLocation(new Point(tmpx++, tmpy--)) != null)
                    {
                        return false;
                    }
                }
            }

            //Moving east
            else if(this.Location.X < x && this.Location.Y == y)
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

            //Moving south east
            else if(this.Location.X < x && this.Location.Y < y)
            {
                int tmpx = this.Location.X + 1;
                int tmpy = this.Location.Y + 1;

                while(tmpx != x && tmpy != y)
                {
                    if(m_board.GetPieceOnLocation(new Point(tmpx++, tmpy++)) != null)
                    {
                        return false;
                    }
                }
            }

            //Moving south
            else if(this.Location.X == x && this.Location.Y < y)
            {
                int tmpy = this.Location.Y + 1;

                while(tmpy != y)
                {
                    if(m_board.GetPieceOnLocation(new Point(x, tmpy++)) != null)
                    {
                        return false;
                    }
                }
            }

            //Moving south west
            else if(this.Location.X > x && this.Location.Y < y)
            {
                int tmpx = this.Location.X - 1;
                int tmpy = this.Location.Y + 1;

                while(tmpx != x && tmpy != y)
                {
                    if(m_board.GetPieceOnLocation(new Point(tmpx--, tmpy++)) != null)
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
