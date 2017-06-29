using System;
using System.Collections.Generic;
using System.Drawing;

namespace ches.Pieces
{
    class King : Piece
    {
        public King(Color color, Point point, Board board) : base(color, point, board)
        {
            m_type = Type.KING;
        }

        public bool CheckForCheck(int x, int y)
        {
            int tmpx = this.Location.X;
            int tmpy = this.Location.Y;

            this.Location = new Point(x, y);

            foreach (Piece piece in m_board.Pieces)
            {
                if(piece.Type != Type.KING && piece.Color != this.Color && piece.ValidateMove(x, y))
                {
                    this.Location = new Point(tmpx, tmpy);
                    return true;
                }
            }
            this.Location = new Point(tmpx, tmpy);
            return false;
        }

        public override bool ValidateMove(int x, int y)
        {
            if(CheckForCheck(x, y))
                return false;
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
