using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ches.Pieces
{
    
    abstract class Piece
    {
        public static int WIDTH = 64;
        public static int HEIGHT = 64;


        protected Color m_color;
        protected Type m_type;
        protected Board m_board;

        protected Point m_location;

        public Piece(Color color, Point point, Board board)
        {
            m_color = color;
            m_location = point;
            m_board = board;
        }

        public void Move(int x, int y)
        {
            if (m_board.GetPieceOnLocation(new Point(x, y)) != null)
                m_board.DeletePiece(new Point(x, y));

            this.Location = new Point(x, y);
        }

        abstract public bool ValidateMove(int x, int y);

        public Point[] GetAllPossiblePaths()
        {
            List<Point> allPaths = new List<Point>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (ValidateMove(i, j))
                        allPaths.Add(new Point((i + 1) * 64 - 32, (j + 1) * 64 - 32));
                }
            }

            return allPaths.ToArray();
        }

        public bool IzvenBoarda(int x, int y)
        {
            if(x > 7 || y > 7 || x < 0 || y < 0)
                return true;
            return false;
        }

        public Point Location { get { return m_location; } set { m_location = value; } }

        public Color Color { get { return m_color; } }

        public Type Type { get { return m_type; } }
    }
}
