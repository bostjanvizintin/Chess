using System;
using System.Collections.Generic;
using System.Drawing;

namespace ches.Pieces
{
    class Pawn : Piece
    {

        public Pawn(Color color, Point point, Board board) : base(color, point, board)
        {
            m_type = Type.PAWN;
        }

       /* public override Point[] GetAllPossiblePaths()
        {
            List<Point> allPaths = new List<Point>();

            if(this.Color == Color.BLACK)
            {
                if (m_board.GetPieceOnLocation(new Point(this.Location.X, this.Location.Y + 1)) == null)
                {
                    allPaths.Add(new Point((this.Location.X + 1) * 64 - 32, (this.Location.Y + 2) * 64 - 32));
                }
                if (m_board.GetPieceOnLocation(new Point(this.Location.X + 1, this.Location.Y + 1)) != null && m_board.GetPieceOnLocation(new Point(this.Location.X + 1, this.Location.Y + 1)).Color != this.Color)
                {
                    allPaths.Add(new Point((this.Location.X + 2) * 64 - 32, (this.Location.Y + 2) * 64 - 32));
                }
                if (m_board.GetPieceOnLocation(new Point(this.Location.X - 1, this.Location.Y + 1)) != null && m_board.GetPieceOnLocation(new Point(this.Location.X - 1, this.Location.Y + 1)).Color != this.Color)
                {
                    allPaths.Add(new Point((this.Location.X) * 64 - 32, (this.Location.Y + 2) * 64 - 32));
                }
            }
            else
            {
                if (m_board.GetPieceOnLocation(new Point(this.Location.X, this.Location.Y - 1)) == null)
                {
                    allPaths.Add(new Point((this.Location.X + 1) * 64 - 32, (this.Location.Y) * 64 - 32));
                }
                if (m_board.GetPieceOnLocation(new Point(this.Location.X + 1, this.Location.Y - 1)) != null && m_board.GetPieceOnLocation(new Point(this.Location.X + 1, this.Location.Y - 1)).Color != this.Color)
                {
                    allPaths.Add(new Point((this.Location.X + 2) * 64 - 32, (this.Location.Y) * 64 - 32));
                }
                if (m_board.GetPieceOnLocation(new Point(this.Location.X - 1, this.Location.Y - 1)) != null && m_board.GetPieceOnLocation(new Point(this.Location.X - 1, this.Location.Y - 1)).Color != this.Color)
                {
                    allPaths.Add(new Point((this.Location.X) * 64 - 32, (this.Location.Y)* 64 - 32));
                }
            }
            return allPaths.ToArray();
        }*/

        public override bool ValidateMove(int x, int y)
        {
            if(IzvenBoarda(x, y))
                return false;

            if(Math.Abs(x-this.Location.X) > 1)
                return false;
            if(Math.Abs(y-this.Location.Y) > 1)
                return false;

            if(this.m_color == Color.BLACK)
            {
                if(y <= this.Location.Y)
                {
                    return false;
                }
                else
                {
                    Piece pieceOnXY = m_board.GetPieceOnLocation(new Point(x,y));
                    if(this.Location.X == x && this.Location.Y + 1 == y && pieceOnXY != null)
                    {
                        return false;
                    }
                    else if (this.Location.X + 1 == x && this.Location.Y + 1 == y && (pieceOnXY == null || pieceOnXY.Color == this.Color))
                    {
                        return false;
                    }
                    else if (this.Location.X - 1 == x && this.Location.Y + 1 == y && (pieceOnXY == null || pieceOnXY.Color == this.Color))
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (y >= this.Location.Y)
                {
                    return false;
                }
                else
                {
                    Piece pieceOnXY = m_board.GetPieceOnLocation(new Point(x, y));
                    if (this.Location.X == x && this.Location.Y - 1 == y && pieceOnXY != null)
                    {
                        return false;
                    }
                    else if (this.Location.X + 1 == x && this.Location.Y - 1 == y && (pieceOnXY == null || pieceOnXY.Color == this.Color))
                    {
                        return false;
                    }
                    else if (this.Location.X - 1 == x && this.Location.Y - 1 == y && (pieceOnXY == null || pieceOnXY.Color == this.Color))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
