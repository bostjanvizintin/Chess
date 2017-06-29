using ches.Pieces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ches
{
    class Update
    {
        private Board board;
        private Piece selectedPiece;

        public Update(Board board)
        {
            this.board = board;
        }

        public void Clicked(object sender, MouseEventArgs e)
        {
            int x = e.X / 64;
            int y = e.Y / 64;
            Console.WriteLine("Clicked on X:{0}, Y:{1}", x ,y);

            if (selectedPiece == null)
            {
                selectedPiece = board.GetPieceOnLocation(new Point(x,y));

                if(selectedPiece != null && selectedPiece.Color != board.Turn)
                {
                    selectedPiece = null;
                }
            }
            else
            {
                if(!selectedPiece.Location.Equals(new Point(x, y)) && selectedPiece.ValidateMove(x, y))
                {
                    selectedPiece.Move(x, y);
                    board.NextPlayer();
                }
                selectedPiece = null;
            }
        }

        public Piece SelectedPiece { get { return selectedPiece; } }
    }
}
