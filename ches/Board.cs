using ches.Pieces;
using System.Collections.Generic;
using System.Drawing;

namespace ches
{
    class Board
    {
        List<Piece> m_board = new List<Piece>();
        Pieces.Color turn = ches.Pieces.Color.WHITE;

        public Board()
        {

            #region StartPosition


            //Set BLACK pieces
            //set pawns
            for (int i = 0; i < 8; i++)
            {
                m_board.Add(new Pawn(ches.Pieces.Color.BLACK, new Point(i, 1), this)); 
            }

            //set king queen
            m_board.Add(new King(ches.Pieces.Color.BLACK, new Point(4, 0), this));
            m_board.Add(new Queen(ches.Pieces.Color.BLACK, new Point(3, 0), this));

            //set rooks
            m_board.Add(new Rook(ches.Pieces.Color.BLACK, new Point(0, 0), this));
            m_board.Add(new Rook(ches.Pieces.Color.BLACK, new Point(7, 0), this));

            //set bishop
            m_board.Add(new Bishop(ches.Pieces.Color.BLACK, new Point(2, 0), this));
            m_board.Add(new Bishop(ches.Pieces.Color.BLACK, new Point(5, 0), this));

            //set knight
            m_board.Add(new Knight(ches.Pieces.Color.BLACK, new Point(1, 0), this));
            m_board.Add(new Knight(ches.Pieces.Color.BLACK, new Point(6, 0), this));

            //Set WHITE pieces
            //set pawns
            for (int i = 0; i < 8; i++)
            {
                m_board.Add(new Pawn(ches.Pieces.Color.WHITE, new Point(i, 6), this));
            }

            //set king queen
            m_board.Add(new King(ches.Pieces.Color.WHITE, new Point(4, 7), this));
            m_board.Add(new Queen(ches.Pieces.Color.WHITE, new Point(3, 7), this));

            //set rooks
            m_board.Add(new Rook(ches.Pieces.Color.WHITE, new Point(7, 7), this));
            m_board.Add(new Rook(ches.Pieces.Color.WHITE, new Point(0, 7), this));

            //set bishop
            m_board.Add(new Bishop(ches.Pieces.Color.WHITE, new Point(2, 7), this));
            m_board.Add(new Bishop(ches.Pieces.Color.WHITE, new Point(5, 7), this));

            //set knight
            m_board.Add(new Knight(ches.Pieces.Color.WHITE, new Point(1, 7), this));
            m_board.Add(new Knight(ches.Pieces.Color.WHITE, new Point(6, 7), this));


            #endregion
        }

        internal void DeletePiece(Point point)
        {
            foreach (Piece piece in Pieces)
            {
                if(piece.Location.Equals(point))
                {
                    Pieces.Remove(piece);
                    return;
                }
            }
        }



        public void NextPlayer()
        {
            if(turn == ches.Pieces.Color.WHITE)
                turn = ches.Pieces.Color.BLACK;
            else
                turn = ches.Pieces.Color.WHITE;
        }

        public Piece GetPieceOnLocation(Point p)
        {
            foreach (Piece piece in Pieces)
            {
                if (piece.Location.Equals(p))
                {
                    return piece;
                }
            }
            return null;
        }

        public List<Piece> Pieces { get { return m_board; } }

        public ches.Pieces.Color Turn { get { return turn; } }

    }
}
