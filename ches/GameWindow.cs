using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ches
{
    public partial class GameWindow : Form
    {
        private Game game = new Game();

        public GameWindow()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = canvas.CreateGraphics();
            game.startGraphics(g);
        }

        private void GameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.stopGame();
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            game.StartGame();
            //AllocConsole();
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            game.MouseClicked(sender, e);
        }

        /*
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        */
     
    }
}
