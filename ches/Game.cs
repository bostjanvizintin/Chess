using System.Drawing;
using System.Windows.Forms;

namespace ches
{
    class Game
    {
        public const int CANVAS_HEIGHT = 512;
        public const int CANVAS_WIDTH = 512;

        private GEngine gEngine;

        private Board board;
        private Update update;

        public Game()
        {
            
        }

        public void startGraphics(Graphics g)
        {
            gEngine = new GEngine(g, this);
            gEngine.init();
        }

        public void stopGame()
        {
            gEngine.stop();
        }

        public void StartGame()
        {
            board = new Board();
            update = new Update(board);
        }

        public void MouseClicked(object sender, MouseEventArgs e)
        {
            update.Clicked(sender, e);
            gEngine.init();
        }

        public Board Board { get { return board; } }

        public Update Update { get { return update; } }



    }
}
