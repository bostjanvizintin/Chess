using ches.Pieces;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;

namespace ches
{
    class GEngine
    {

        private Graphics drawHandle;
        private Thread renderThread;
        private Game game;

        public GEngine(Graphics g, Game game)
        {
            this.game = game;
            drawHandle = g;
        }

        public void init()
        {
            renderThread = new Thread(new ThreadStart(render));
            renderThread.Start();
        }


        public void render()
        {

            if (game.Board.CheckForCheckMate())
            {
                game.stopGame();
                game.StartGame();
            }

            int framesRendered = 0;
            long startTime = Environment.TickCount;

            Bitmap frame = new Bitmap(Game.CANVAS_WIDTH, Game.CANVAS_HEIGHT);
            Graphics frameGraphics = Graphics.FromImage(frame);

           // while(true)
           // {
                frameGraphics.DrawImage(Resources.Board, 0, 0, Game.CANVAS_WIDTH, Game.CANVAS_HEIGHT);

                foreach (Piece piece in game.Board.Pieces.ToArray())
                {
                    Bitmap res = null;
                    switch(piece.Type)
                    {
                        case Pieces.Type.BISHOP:
                            if(piece.Color == Pieces.Color.WHITE)
                                res = Resources.WhiteBishop;
                            else
                                res = Resources.BlackBishop;
                            break;
                        case Pieces.Type.KING:
                            if (piece.Color == Pieces.Color.WHITE)
                                res = Resources.WhiteKing;
                            else
                                res = Resources.BlackKing;
                            break;
                        case Pieces.Type.KNIGHT:
                            if (piece.Color == Pieces.Color.WHITE)
                                res = Resources.WhiteKnight;
                            else
                                res = Resources.BlackKnight;
                            break;
                        case Pieces.Type.PAWN:
                            if (piece.Color == Pieces.Color.WHITE)
                                res = Resources.WhitePawn;
                            else
                                res = Resources.BlackPawn;
                            break;
                        case Pieces.Type.QUEEN:
                            if (piece.Color == Pieces.Color.WHITE)
                                res = Resources.WhiteQueen;
                            else
                                res = Resources.BlackQueen;
                            break;
                        case Pieces.Type.ROOK:
                            if (piece.Color == Pieces.Color.WHITE)
                                res = Resources.WhiteRook;
                            else
                                res = Resources.BlackRook;
                            break;

                    }
                    frameGraphics.DrawImage(res, piece.Location.X * Piece.WIDTH, piece.Location.Y * Piece.HEIGHT, Piece.WIDTH, Piece.HEIGHT);
                }

                foreach (Piece piece in game.Board.Pieces.ToArray())
                {
                    //Draw dot on selected piece
                    if (game.Update.SelectedPiece != null && game.Update.SelectedPiece.Equals(piece))
                    {
                        frameGraphics.FillEllipse(new SolidBrush(System.Drawing.Color.Red), game.Board.GetPieceOnLocation(new Point(piece.Location.X, piece.Location.Y)).Location.X * 64 + 25, game.Board.GetPieceOnLocation(new Point(piece.Location.X, piece.Location.Y)).Location.Y * 64 + 25, 15, 15);

                        //Draw all possible paths
                        //GraphicsPath graphPath = new GraphicsPath();

                        foreach (Point point in piece.GetAllPossiblePaths())
                        {
                            //graphPath.AddLine(game.Board.GetPieceOnLocation(new Point(piece.Location.X, piece.Location.Y)).Location.X * 64 + 32, game.Board.GetPieceOnLocation(new Point(piece.Location.X, piece.Location.Y)).Location.Y * 64 + 32, point.X, point.Y);
                            frameGraphics.FillEllipse(new SolidBrush(System.Drawing.Color.Green), point.X - 7, point.Y - 7, 15, 15);
                        }

                        //Pen pen = new Pen(System.Drawing.Color.Green, 3);
                        //frameGraphics.DrawPath(pen, graphPath);
                    }
                }

                drawHandle.DrawImage(frame, 0, 0);


                framesRendered++;
                if(Environment.TickCount >= startTime + 1000)
                {
                    //Console.WriteLine("GEngine: " + framesRendered + " fps");
                    framesRendered = 0;
                    startTime = Environment.TickCount;
                }
          //  }
        }

        public void stop()
        {
            Bitmap frame = new Bitmap(Game.CANVAS_WIDTH, Game.CANVAS_HEIGHT);
            Graphics frameGraphics = Graphics.FromImage(frame);
            frameGraphics.DrawString("GAME OVER", new Font(FontFamily.GenericSansSerif, 18), new SolidBrush(System.Drawing.Color.Black), new Point(150, 200));
            frameGraphics.DrawString("CLICK ON SCREEN FOR NEW GAME", new Font(FontFamily.GenericSansSerif, 18), new SolidBrush(System.Drawing.Color.Black), new Point(50, 250));
            drawHandle.DrawImage(frame, 0, 0);
            renderThread.Abort();
        }
    }
}
